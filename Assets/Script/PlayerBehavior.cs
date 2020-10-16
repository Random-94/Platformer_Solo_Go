using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    private Inputs inputs;
    private Vector2 direction;

    private void OnEnable()
    {
        inputs = new Inputs();
        inputs.Enable();
        inputs.Perso.Move.performed += OnMovePerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        direction = obj.ReadValue<Vector2>();


        Debug.Log(direction);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var MyRigidBody = GetComponent<Rigidbody2D>();
        direction.y = 0;
        //MyRigidBody.MovePosition(direction);
        //MyRigidBody.velocity = direction;
        if (MyRigidBody.velocity.sqrMagnitude < maxSpeed)
        MyRigidBody.AddForce(direction*speed);
    }
}
