using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //dis line for git test
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float smoothSpeed = 1f;
    [SerializeField] private float RotationSpeed;


    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(44, 90, 0);
        offset = new Vector3(-7f, 4f, 60.5f);
        //Vector3 desiredPosition = target.position + offset;
        Vector3 desiredPosition = new Vector3(target.position.x, 7, 0) + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;
    }

    //private void FixedUpdate()
    //{
    //    HandleTranslation();
    //    HandleRotation();
    //}

    //private void HandleRotation()
    //{
    //    var direction = target.position - transform.position;
    //    var rotation = Quaternion.LookRotation(direction, Vector3.up);
    //    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
    //}

    //public void HandleTranslation()
    //{
    //    var targetPosition = target.TransformPoint(offset);
    //    transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);

    //}
}
