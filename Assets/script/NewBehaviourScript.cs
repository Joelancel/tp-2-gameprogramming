using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurMouvement : MonoBehaviour
{
    public float forceDeSaut = 6f;
    public int nombreDeSautsMax = 2;
    private int sautsRestants;
    private Rigidbody2D rb;
    private bool estAuSol;
    public float vitesse = 5.0f;  
    void Start()
    {
        // Récupérer le composant Rigidbody2D attaché au GameObject
        rb = GetComponent<Rigidbody2D>();
        sautsRestants = nombreDeSautsMax;
    }

    void Update()
    {
        // Si le joueur est au sol et appuie sur la barre d'espace
        if (estAuSol && Input.GetKeyDown(KeyCode.Space))
        {
            Sauter();
        }
         float deplacementHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * deplacementHorizontal * vitesse * Time.deltaTime);
}
    void Sauter()
    {
        // Ajouter une force vers le haut au Rigidbody2D
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Remettre la vélocité en y à zéro pour éviter des sauts trop puissants
        rb.AddForce(Vector2.up * forceDeSaut, ForceMode2D.Impulse);
        sautsRestants--;

        // Si le joueur a utilisé tous les sauts, désactiver la possibilité de sauter
        if (sautsRestants == 0)
        {
            estAuSol = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si le joueur touche le sol, réinitialiser le nombre de sauts
        if (collision.gameObject.CompareTag("Sol"))
        {
            sautsRestants = nombreDeSautsMax;
            estAuSol = true;
        }
    }
}