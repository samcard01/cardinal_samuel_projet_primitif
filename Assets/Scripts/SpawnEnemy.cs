using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
   //Déclarer un GameObject public pour déterminer quel élément va spawner, ici, le prefab d'ennemi
    public GameObject enemyPrefab;

    void Start()
    {
        //Pour la première vague d'ennemis: Déterminer les paramètres de la fonction InvokeRepeating("Nom de la fonction", délai, intervalle de répétition);
        InvokeRepeating("SpawnEnemiesFirstWave", 2 , 5);
        //Pour la deuxième vague d'ennemis: Déterminer les paramètres de la fonction InvokeRepeating("Nom de la fonction", délai, intervalle de répétition);
        InvokeRepeating("SpawnEnemiesSecondWave", 10 , 2);
    }

    void Update()
    {
 
    }

    //Déclaration de la fonction pour la première vague d'instantiation du prefab d'ennemi
     void SpawnEnemiesFirstWave()
    {
        //Déclarer une variable pour la position de spawn
        Vector3 spawnPos = new Vector3 (Random.Range(-4.5f,4.5f), 0.5f, 0);

        //Va chercher le prefab d'ennemi, Déterminer la position quand il spawn sur l'axe des x, y et z et sa position de rotation quand il spawn
        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);

        
    }

    //Déclaration de la fonction pour la deuxième vague d'instantiation du prefab d'ennemi
    void SpawnEnemiesSecondWave()
    {
        //Déclarer une variable pour la position de spawn
        Vector3 spawnPos = new Vector3 (Random.Range(-5f,5f), 0.5f, 0);
        
        //Va chercher le prefab d'ennemi, Déterminer la position quand il spawn sur l'axe des x, y et z et sa position de rotation quand il spawn
        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }
    
}
