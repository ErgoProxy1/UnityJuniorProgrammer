using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool usePhysics = false;

    private readonly float maxSpeed = 30f;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(usePhysics)
        {
            PhysicsMovement();
        }
        else
        {
            TransformMovement();
        }

    }

    void TransformMovement()
    {
        float speed = 0.35f;
        float turnSpeed = 1.5f;
        float speedInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * speed * speedInput);
        transform.Rotate(Vector3.up, turnSpeed * turnInput);
    }

    void PhysicsMovement()
    {
        float acceleration = 25f;
        float rotationSpeed = 30000f;
        bool isW = Input.GetKey(KeyCode.W);
        bool isS = Input.GetKey(KeyCode.S);
        // Move the vehicle forward
        if (isW || isS)
        {
            int invert = isS ? -1 : 1;

            if (rb.linearVelocity.z < maxSpeed)
            {
                rb.AddForce(transform.forward * acceleration * invert * rb.mass);
            }
            else
            {
                rb.linearVelocity = rb.linearVelocity;
            }
            // Rotate vehicle if its moving
            bool isD = Input.GetKey(KeyCode.D);
            bool isA = Input.GetKey(KeyCode.A);
            if (isD || isA)
            {
                int rotation = 1;
                if (isA && !isD) rotation = -1;
                else if (isD && isA) rotation = 0;
                //transform.Rotate(0, rotation * rotationSpeed * invert, 0);
                rb.AddTorque(transform.up * rotation * rotationSpeed * invert);
                print("torque " + transform.up * rotation * rotationSpeed * invert);
            }
        }
    }
}
