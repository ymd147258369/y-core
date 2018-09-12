using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    public float sensitivity = 1.0f;
    public bool reverseX = true;
    public float clampAngle = 60;
    private GameObject followTarget;

    private float newX = 0.0f;

    void Awake()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player").transform.FindChild("FollowTarget").gameObject; ;
    }


    void Update()
    {
        var mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        mouseY *= reverseX ? -1 : 1;
        var nowRot = this.transform.eulerAngles;
        newX = nowRot.x + mouseY;
        newX -= newX > 180.0f ? 360.0f : 0.0f;
        newX = Mathf.Abs(newX) > clampAngle ? clampAngle * Mathf.Sign(newX) : newX;
    }

    void LateUpdate()
    {
        this.transform.eulerAngles = new Vector3(newX, followTarget.transform.eulerAngles.y, 0.0f);
    }
}