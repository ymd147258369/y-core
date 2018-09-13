using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    public float moveSpeed = 2;
    private GameObject playerObj;
    private Vector3 offset;

    void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Use this for initialization
    void Start()
    {
        offset = this.transform.position - playerObj.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var nowPosition = this.transform.position;
        var targetPosition = playerObj.transform.position + offset;
        var newPos = Vector3.Lerp(nowPosition, targetPosition, moveSpeed * Time.deltaTime);
        this.transform.position = newPos;
    }
}