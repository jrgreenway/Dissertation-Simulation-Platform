using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
    // This script is attached to the ship object in the Ship scene to control the ship's movement and rotation
{
    public float maxSpeed = 10f;        
    public float acceleration = 2f;    
    public float deceleration = 2f;     
    public float rotationSpeed = 45f;   
    public float rotationSmoothness = 0.1f; 

    private float currentSpeed = 0f;    
    private float targetRotation = 0f;  
    private float currentRotation = 0f; 

    void Start()
    {
        currentRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        HandleInput();
        MoveShip();
        RotateShip();
    }

    void HandleInput()
        // This function handles the ship's movement and rotation based on user input
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }
        else
        {

            currentSpeed = Mathf.Lerp(currentSpeed, 0, deceleration * Time.deltaTime);
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        if (Input.GetKey(KeyCode.A))
        {
            targetRotation += rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            targetRotation -= rotationSpeed * Time.deltaTime;
        }
    }

    void MoveShip()
        // This function moves the ship based on its current speed
    {
        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);
    }

    void RotateShip()
        // This function rotates the ship based on the target rotation
    {
        currentRotation = Mathf.LerpAngle(currentRotation, targetRotation, rotationSmoothness);
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }

    // Properties to access ship data from other scripts
    public float CurrentSpeed => currentSpeed;
    public float CurrentHeading => currentRotation;
    public Vector3 CurrentPosition => transform.position;
}

