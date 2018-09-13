using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 20;
    public float QBPower = 120;
    private Vector3 direction;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var forward = this.transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;
        var right = this.transform.TransformDirection(Vector3.right) * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(forward, ForceMode.VelocityChange);
            direction = forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-forward, ForceMode.VelocityChange);
            direction = -forward;
        }
        else
        {
            direction = forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(right, ForceMode.VelocityChange);
            direction = right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-right, ForceMode.VelocityChange);
            direction = -right;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(direction * QBPower, ForceMode.Impulse);
        }
    }
}