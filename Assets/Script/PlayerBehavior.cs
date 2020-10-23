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
        inputs.Perso.Move.performed += OnMovePerformed;//quand on appuie sur les inputs de l'action Move de l'action Map player, on lance la fonction OnMovePerformed
        inputs.Perso.Move.canceled += OnMoveCanceled;//quand on arrête d'appuyer sur les inputs de l'action Move de l'action Map player, on lance la fonction OnMoveCanceled
        inputs.Perso.Jump.performed += OnJumpPerformed;//quand on appuie sur les inputs de l'action Jump de l'action Map player, on lance la fonction OnJumpPerformed

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
        direction = obj.ReadValue<Vector2>();

    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        direction = Vector2.zero;

    }

    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
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
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        direction.y = 0;


        if (myRigidbody.velocity.sqrMagnitude < maxSpeed)
        {
            myRigidbody.AddForce(direction * speed);
        }

        var IsRunning = direction.x != 0;
        myAnimator.SetBool("IsRunning", IsRunning);

        var IsJumping = !IsOnGround && myRigidbody.velocity.y > 0;
        myAnimator.SetBool("IsJumping", IsJumping);

        var IsFalling = !IsOnGround && myRigidbody.velocity.y < 0;
        myAnimator.SetBool("IsFalling", IsFalling);
        myAnimator.SetBool("IsGrounding", IsOnGround);

        if (direction.x < 0)
        {
            myRenderer.flipX = true;
        }
        else if(direction.x > 0)
        {
            myRenderer.flipX = false;
        }

        var PlayerGameObject = GameObject.FindWithTag("Player");
        var CollectiblesScript = PlayerGameObject.GetComponent<collectible>();

        ScoreValue = CollectiblesScript.ScoreValue;
        ScoreFinal = CollectiblesScript.ScoreFinal;

    }

    

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        //if(ground == (ground | (1 << other.gameObject.layer)))
        if (other.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            
        }

        if(ScoreValue == ScoreFinal && other.gameObject.CompareTag("Fin"))
        {
            SceneManager.LoadScene("Fin", LoadSceneMode.Single);
            Debug.Log("oh");
        }
    }



}
