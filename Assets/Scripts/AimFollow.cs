using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimFollow : MonoBehaviour
{

    private GameObject followTarget;
    private Vector3 offset;

    void Awake()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player").transform.Find("FollowTarget").gameObject;
    }

    void Start()
    {
        offset = this.transform.position - followTarget.transform.position;
    }

    void Update()
    {
        this.transform.position = followTarget.transform.position + offset;
    }
}