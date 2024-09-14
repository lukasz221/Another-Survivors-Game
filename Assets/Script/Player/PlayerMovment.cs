using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }

    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        moveInput = new Vector3(direction.x, 0, direction.y);
        moveVelocity = moveInput * speed;
    }
}
