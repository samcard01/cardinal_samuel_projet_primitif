using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Déclaration une fonction pour la collision entre un projectile et un ennemi
    private void OnTriggerEnter(Collider other)
    {
        //Détruit le projectile
        Destroy(gameObject);
        
        //Détruit l'ennemi
        Destroy(other.gameObject);
        
    }
}
