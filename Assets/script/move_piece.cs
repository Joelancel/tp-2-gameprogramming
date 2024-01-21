using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject piecePrefab;
    public float spawnInterval = 10f;
    public float moveSpeed = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPiece();
            timer = 0f;
        }

        MovePieces();
    }

    void SpawnPiece()
    {
        GameObject piece = Instantiate(piecePrefab, transform.position, Quaternion.identity);
        Destroy(piece, 10f); // Supprimer la pièce après 10 secondes (ajuster selon vos besoins)
    }

    void MovePieces()
    {
        GameObject[] pieces = GameObject.FindGameObjectsWithTag("Piece");

        foreach (GameObject piece in pieces)
        {
            piece.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            // Vérifier si la pièce est hors de l'écran
            if (piece.transform.position.x < -15f)
            {
                Destroy(piece);
            }
        }
    }
}