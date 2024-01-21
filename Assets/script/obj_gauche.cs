using UnityEngine;

public class DeplacementEtSpawn : MonoBehaviour
{
    public float vitesse = 2.0f;  // Vitesse de déplacement
    public float tempsDebut = 5.0f;  // Temps minimum pour apparaître
    public float tempsFin = 15.0f;   // Temps maximum pour apparaître

    void Start()
    {
        // Démarrer le mouvement après un certain délai
        Invoke("DeplacerObjet", Random.Range(tempsDebut, tempsFin));
    }

    void Update()
    {
        // Déplacer l'objet vers la droite
        transform.Translate(Vector3.right * vitesse * Time.deltaTime);
    }

    void DeplacerObjet()
    {
        // Réinitialiser la position de l'objet à gauche
        transform.position = new Vector3(-10f, 0f, 0f);

        // Démarrer le mouvement après un certain délai
        Invoke("DeplacerObjet", Random.Range(tempsDebut, tempsFin));
    }
}