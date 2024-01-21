using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeplacementObstacle : MonoBehaviour
{
    public float vitesseMin = 7f;
    public float vitesseMax = 15f;
    public float tailleMin = 0.3f;
    public float tailleMax = 1f;
    private string tagJoueur = "tagJoueur";
    private float vitesseDeDeplacement;
    
    void Start()
    {
        // Initialiser la vitesse de manière aléatoire au début
        ChoisirNouvelleVitesse();

        // Initialiser la taille de manière aléatoire au début
        ChoisirNouvelleTaille();
    }

    void Update()
    {
        // Déplacer l'obstacle horizontalement de droite à gauche
        DeplacerDeDroiteAGauche();
    }
      void OnCollisionEnter2D(Collision2D collision)
    {
        // Si la collision se produit avec le joueur, la partie est perdue
        if (collision.gameObject.CompareTag(tagJoueur))
        {
            PartiePerdue();
        }
    }

    void DeplacerDeDroiteAGauche()
    {
        // Calculer la nouvelle position de l'obstacle
        float nouvellePositionX = transform.position.x - (vitesseDeDeplacement * Time.deltaTime);

        // Définir la nouvelle position de l'obstacle
        transform.position = new Vector3(nouvellePositionX, transform.position.y, transform.position.z);

        // Si l'obstacle est sorti de l'écran, le remettre à la position de départ, choisir une nouvelle vitesse et une nouvelle taille
        if (transform.position.x < -15f) // Vous pouvez ajuster cette valeur selon la taille de votre niveau
        {
            RepositionnerObstacle();
            ChoisirNouvelleVitesse();
            ChoisirNouvelleTaille();
        }
    }

    void RepositionnerObstacle()
    {
        // Remettre l'obstacle à la position de départ (côté droit de l'écran)
        float positionInitialeX = 15f; // Vous pouvez ajuster cette valeur selon la taille de votre niveau
        transform.position = new Vector3(positionInitialeX, transform.position.y, transform.position.z);
    }

    void ChoisirNouvelleVitesse()
    {
        // Choisir une nouvelle vitesse aléatoire entre vitesseMin et vitesseMax
        vitesseDeDeplacement = Random.Range(vitesseMin, vitesseMax);
    }

    void ChoisirNouvelleTaille()
    {
        // Choisir une nouvelle taille aléatoire entre tailleMin et tailleMax
        float nouvelleTaille = Random.Range(tailleMin, tailleMax);
        transform.localScale = new Vector3(nouvelleTaille, nouvelleTaille, 1f); // 1f pour la profondeur (Z)
    }

    void PartiePerdue()
    {
        // Charger la scène de partie perdue
        SceneManager.LoadScene("scene_perdu");
    }
}