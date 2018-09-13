using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float moveSpeed = 3;
    public float rotateSpeed = 3;
    private GameObject lookTarget;
    private GameObject cameraPositionTarget;

    void Awake()
    {
        lookTarget = GameObject.Find("CameraRotateOrigin").gameObject;
        cameraPositionTarget = lookTarget.transform.FindChild("CameraPositionTarget").gameObject;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var nowPos = this.transform.position;
        var targetPos = cameraPositionTarget.transform.position;
        this.transform.position = Vector3.Lerp(nowPos, targetPos, moveSpeed * Time.deltaTime);

        var thisPos = this.transform.position;
        var followTargetPos = lookTarget.transform.position;
        var vectorToTarget = followTargetPos - thisPos;
        var thisRotate = this.transform.rotation;
        var targetRotate = Quaternion.LookRotation(vectorToTarget);
        var newRotate = Quaternion.Lerp(thisRotate, targetRotate, rotateSpeed * Time.deltaTime).eulerAngles;
        this.transform.eulerAngles = new Vector3(newRotate.x, newRotate.y, newRotate.z);
    }
}