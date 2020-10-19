using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private LayerMask ground;

    private Inputs inputs;
    private Vector2 direction;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private SpriteRenderer myRenderer;

    private bool IsOnGround = false;

    private void OnEnable()
    {
        inputs = new Inputs();
        inputs.Enable();
        inputs.Perso.Move.performed += OnMovePerformed;
        inputs.Perso.Move.canceled += OnMoveCanceled;
        inputs.Perso.Jump.performed += OnJumpPerformed;

        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();
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
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        direction.y = 0;
      

        if (myRigidbody.velocity.sqrMagnitude < maxSpeed)
            myRigidbody.AddForce(direction*speed);

        var IsRunning = direction.x != 0;
        myAnimator.SetBool("IsRunning", IsRunning);

        if(direction.x < 0)
        {
            myRenderer.flipX = true;
        }
        else if(direction.x > 0)
        {
            myRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if(ground == (ground | (1 << other.gameObject.layer)))
        if(other.gameObject.CompareTag("Ground") == true)
        {
            IsOnGround = true;
            
        }
    }



}
