using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    //Déclarer une variable pour la limite de déplacement sur l'axe des z du haut
    private float zLimitTop = 10;

    //Déclarer une variable pour la limite de déplacement sur l'axe des z du bas
    private float zLimitBottom = -5;

    void Start()
    {

    }

    void Update()
    {
        //Ce qui arrive si la position du z dépasse la valeur déterminée dans la variable zLimitTop 
        if (transform.position.z > zLimitTop)
        {
            //Détruit le projectile
            Destroy(gameObject);
        }

        //Ce qui arrive si la position du z dépasse la valeur déterminée dans la variable zLimitBottom 
        else if (transform.position.z < zLimitBottom)
        {
            //Détruit le projectile
            Destroy(gameObject);
        }
    }
}
