using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    //PUBLIC VARIABLES SHOULD START WITH CAPITAL LETTERS
    public float MoveSpeed;

    public Transform Orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    [SerializeField] private Rigidbody _rb;

    private void Start()
    {
        //get component is expensive, so use serializefield and scroll it from inspector
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    //Use new input system  
    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;

        _rb.AddForce(moveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);
    }


}
