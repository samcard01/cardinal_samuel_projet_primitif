using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //Créer une variable pour la vitesse de déplacement du projectile
    private float speed = 12;

    void Start()
    {
        
    }

    void Update()
    {
        //Permet de faire avancer vers l'avant le projectile en se basant sur la valeur de l'axe des z
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
