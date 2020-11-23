using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Déclarer une variable pour la vitesse de l'ennemi
    private float speed = 3.5f;

    //Déclarer une variable pour le script de PlayerController
    private PlayerController playerControllerScript;
    
    void Start()
    {
        //Obtenir les données en lien avec le joueur disponibles dans le script de playerController
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ce qui se passe si le Game Over du script PlayerController est Faux
        if (playerControllerScript.gameOver == false ) { 
            //Permet de faire avancer l'ennemi en se basant sur la valeur de l'axe des z
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        //Ce qui se passe si le Game Over du script PlayerController est Vrai
        else if (playerControllerScript.gameOver == true ) { 
            //Permet de stopper le déplacement de l'ennemi dû à la vitesse de déplacement de zéro
            transform.Translate(Vector3.forward * Time.deltaTime * 0);
        }
    }
}
