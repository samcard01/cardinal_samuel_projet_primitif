using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Déclarer une variable pour obtenir la valeur de l'axe horizontal
    private float horizontalInput;

    //Déclarer une variable pour la vitesse du joueur
    private float speed = 20;

    //Déclarer une variable pour la limite de déplacement sur l'axe des x
    private float xLimit = 4.70f;

    //Déclarer une variable pour la position sur l'axe des y
    private float yPosition = 0.5f;

    //Déclarer une variable pour la position de spawn sur l'axe des x
    private float spawnPosX = 0;

    //Déclarer une variable pour la position de spawn sur l'axe des y
    private float spawnPosY = 0.36f;

    //Déclarer une variable pour la position de spawn sur l'axe des z
    private float spawnPosZ = -1f;

    //Déclarer une variable pour le clip audio du son de projectile
    public AudioClip projectileSound;

    //Déclarer une variable pour la source audio du son de projectile
    private AudioSource playerAudio;

    //Déclarer une variable pour le clip audio du son de Game Over
    public AudioClip gameOverSound;

    //Déclarer un GameObject public pour obtenir le prefab de projectile
    public GameObject projectile;

    //Déclarer un particle system public pour obtenir les particules d'explosion
    public ParticleSystem explosionParticle ;


    void Start()
    {
        //Obtenir la source audio pour l'audio du joueur
         playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Ce qui arrive si le Game Over est égal à Faux
        if ( gameOver == false) {
            //Permet d'obtenir la valeur de l'axe horizontal du joueur
            horizontalInput = Input.GetAxis("Horizontal");

            //Permet de faire avancer le joueur en se basant sur la valeur de l'axe horizontal
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }  

        //Ce qui arrive si le Game Over est égal à Vrai
        else if (gameOver == true) {
            //Permet de stopper le déplacement du joueur dû à la vitesse de déplacement de zéro
            transform.Translate(Vector3.forward * Time.deltaTime * 0);
        } 

        //Ce qui arrive si la position du x dépasse la valeur déterminée dans la variable xLimit du côté gauche
        if ( transform.position.x > xLimit)  {
            //Permet de stopper le déplacement du joueur lorsqu'il atteint la limite établie
            transform.position = new Vector3(xLimit, yPosition, transform.position.z);

        //Ce qui arrive si la position du x dépasse la valeur déterminée dans la variable xLimit du côté droit
        } else if ( transform.position.x < -xLimit)  {
            //Permet de stopper le déplacement du joueur lorsqu'il atteint la limite établie
            transform.position = new Vector3(-xLimit, yPosition, transform.position.z);
        }

        //Ce qui arrive si la touche Space est appuyée
         if (Input.GetKeyDown(KeyCode.Space))
        {
            //Le son de projectile joue une fois au volume déclaré
           playerAudio.PlayOneShot(projectileSound, 10.0f);

           //Va chercher le prefab de projectile, déterminer la position quand il spawn sur l'axe des x, y et z et sa position de rotation quand il spawn
            Instantiate( projectile , transform.position + new Vector3(spawnPosX,spawnPosY,spawnPosZ), transform.rotation );
        }
    }

    //Déclarer un booléen de Game Over
    public bool gameOver = false;

    //Déclaration d'une fonction pour la collision entre un ennemi et le joueur
    void OnCollisionEnter(Collision collision) {

        //Ce qui arrive si le joueur entre en collision avec un ennemi 
        if ( collision.gameObject.CompareTag("EnemyHit") ) {
            
           //Permet de faire apparaitre un message dans la console de Game Over
           Debug.Log("Game Over : Veuillez recommencer une partie pour rejouer");
           
           //Déclare le Game Over comme étant Vrai
            gameOver = true;

            //Le son de Game Over joue une fois au volume déclaré
            playerAudio.PlayOneShot(gameOverSound, 10.0f);

            //Le système de particules s'active et joue 
            explosionParticle.Play();
        } 
    }
}
