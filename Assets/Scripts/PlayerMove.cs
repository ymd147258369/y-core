using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 20;
    public float QBPower = 120;
    public float JumpPower = 120;
    public float AddForceGravity = 100;
    private Vector3 direction;
    private Vector3 forceFowerd;
    private Vector3 forceRight;

    private bool quickBoost = false;
    private bool jump = false;

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


        // 移動の物理演算
        if (forceFowerd != Vector3.zero)
        {
            rb.AddForce(forceFowerd * speed * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (forceRight != Vector3.zero)
        {
            rb.AddForce(forceRight * speed * Time.deltaTime, ForceMode.VelocityChange);
        }

        // クイックブーストの物理演算
        if (quickBoost)
        {
            rb.AddForce(direction * QBPower, ForceMode.Impulse);
            quickBoost = false;
        }

        // ジャンプの物理演算
        if (jump)
        {
            jump = false;
            rb.AddForce(JumpPower * Vector3.up * Time.deltaTime, ForceMode.Impulse);
        }

        // 落下速度を上げるために追加で下方向への力を加える
        rb.AddForce(Vector3.down * AddForceGravity, ForceMode.Acceleration);
    }

    void Update()
    {
        // キー入力の受け取りと値の計算
        // 前後移動
        if (Input.GetKey(KeyCode.W))
        {
            forceFowerd = direction = this.transform.TransformDirection(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            forceFowerd = direction = -this.transform.TransformDirection(Vector3.forward);
        }
        else
        {
            forceFowerd = Vector3.zero;
            direction = this.transform.TransformDirection(Vector3.forward);
        }

        // 左右移動
        if (Input.GetKey(KeyCode.D))
        {
            forceRight = direction = this.transform.TransformDirection(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            forceRight = direction = -this.transform.TransformDirection(Vector3.right);
        }
        else
        {
            forceRight = Vector3.zero;
        }

        // クイックブースト
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            quickBoost = true;
        }

        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce(direction * QBPower, ForceMode.Impulse);
        }

        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }
}