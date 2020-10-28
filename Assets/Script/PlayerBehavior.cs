using System;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float speed; // on cree une variable modifiable dans l'inspector pour modifier la vitesse du personnage
    [SerializeField] private float maxSpeed;// on cree une variable modifiable dans l'inspector pour modifier la vitesse max du personnage
    [SerializeField] private float JumpForce;// on cree une variable modifiable dans l'inspector pour modifier la force du saut du personnage
    [SerializeField] private LayerMask ground;// on cree une variable modifiable dans l'inspector

    private Inputs inputs;// on cree une variable pour les inputs d'actions du personnage
    private Vector2 direction;// on cree une variable pour la direction du personnage

    private Rigidbody2D myRigidbody;// on cree une variable pour modifier le rigidbody du personnage
    private Animator myAnimator;// on cree une variable pour l'animation du personnage
    private SpriteRenderer myRenderer;// on cree une variable pour modifier le sprite qui va etre affiché pendant les animations

    private bool IsOnGround = false;// on cree une variable booleenne qu'on déclare "faux"

    private int ScoreValue; // on cree une variable pour le score
    private int ScoreFinal;// on cree une variable pour le score final du joueur

    private void OnEnable()
    {
        inputs = new Inputs(); // //on instancie l'input system créé dans Unity
        inputs.Enable(); //on instancie l'input system créé dans Unity
        inputs.Perso.Move.performed += OnMovePerformed;//quand on appuie sur les inputs de l'action Move de l'action Map Perso, on lance la fonction OnMovePerformed
        inputs.Perso.Move.canceled += OnMoveCanceled;//quand on arrête d'appuyer sur les inputs de l'action Move de l'action Map Perso, on lance la fonction OnMoveCanceled
        inputs.Perso.Jump.performed += OnJumpPerformed;//quand on appuie sur les inputs de l'action Jump de l'action Map Perso, on lance la fonction OnJumpPerformed

        /*myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();*/
    }

    private void OnDestroy()
    {
        inputs.Disable(); //on demande de déinstancier l'input system créé dans Unity
    }

    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        direction = obj.ReadValue<Vector2>(); //la variable direction recupère la position (-1, 0 ou 1) des inputs enclenchés

    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        direction = Vector2.zero; //quand on arrête d'appuyer sur les inputs, on fait en sorte que le personnage ne reçoive plus aucune force pour qu'il arrête d'avancer

    }

    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        //si le bool IsOnGround est vrai, on ajoute une force (JumpForce) vers le haut sur le player
        //puis on repasse le booléen a faux pour arrêter d'ajouter la force même si on continue d'enclencher l'input
        if (IsOnGround)
        {
            myRigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            IsOnGround = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        myRigidbody = GetComponent<Rigidbody2D>();//on récupère le Rigidbody2D du Player pour pouvoir agir dessus
        myAnimator = GetComponent<Animator>();// on recupère le composant animator
        myRenderer = GetComponent<SpriteRenderer>();// on recupère le composant sprite renderer
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        direction.y = 0;//on fait en sorte que le Player ne puisse se deplacer que sur l'axe x

        //Tant que la vitesse de déplacement du player n'est pas superieure à maxSpeed, on lui ajoute une force en fonction des inputs enclenchés
        if (myRigidbody.velocity.sqrMagnitude < maxSpeed)
        {
            myRigidbody.AddForce(direction * speed);
        }


        var IsRunning = direction.x != 0;// on lance l'animation isrunning dès que le personnage est en mouvement
        myAnimator.SetBool("IsRunning", IsRunning);

        var IsJumping = !IsOnGround && myRigidbody.velocity.y > 0;//on lance l'animation isjumping et isfalling dès que le personnage est en mouvement sur l'axe y
        myAnimator.SetBool("IsJumping", IsJumping);

        var IsFalling = !IsOnGround && myRigidbody.velocity.y < 0;
        myAnimator.SetBool("IsFalling", IsFalling);
        myAnimator.SetBool("IsGrounding", IsOnGround);

        if (direction.x < 0)//on change l'orientatino du sprite en fonction de sa direction
        {
            myRenderer.flipX = true;
        }
        else if(direction.x > 0)
        {
            myRenderer.flipX = false;
        }

        var PlayerGameObject = GameObject.FindWithTag("Player"); //je cree une variable "PlayerGameObject" dans lequel je lui demande d'aller comparer son tag avec Player
        var CollectiblesScript = PlayerGameObject.GetComponent<collectible>(); //je cree une variable "CollectiblesScript" et je lui demande d'aller chercher sur le perso le component "collectible" qui correspond au script

        ScoreValue = CollectiblesScript.ScoreValue;
        ScoreFinal = CollectiblesScript.ScoreFinal;

    }

    

    private void OnCollisionEnter2D(Collision2D other)
    {

        //si le Player collisionne avec un GameObject qui a le tag "Ground" le booléen IsOnGround passe en true pour que le Player puisse sauter
        if (other.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            
        }

        //si le Player collisionne avec un GameObject qui a le tag "Fin" et que le score final atteint un nombre determiné , on lance la scene "fin"
        if (ScoreValue == ScoreFinal && other.gameObject.CompareTag("Fin"))
        {
            SceneManager.LoadScene("Fin", LoadSceneMode.Single);
            Debug.Log("oh");
        }
    }



}
