using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forwardSpeed = 20;
    public GameObject targetF,cameraObject;
    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, targetDistance;

    // Update is called once per frame
    void Update()
    {
        lookInput.x = targetF.transform.position.x;
        lookInput.y = targetF.transform.position.y;

        targetDistance.x = (lookInput.x - transform.position.x) / transform.position.y;
        targetDistance.y = (lookInput.y - transform.position.y) / transform.position.y;

        targetDistance = Vector2.ClampMagnitude(targetDistance, 1f);

        /*transform.position = targetF.transform.position;
        transform.rotation = cameraObject.transform.rotation;*/

        float posRot = -targetDistance.y * lookRateSpeed * Time.deltaTime;
        float negRot = targetDistance.x * lookRateSpeed * Time.deltaTime;

        transform.Rotate(posRot, negRot, 0f, Space.Self);

        transform.position += transform.forward * forwardSpeed * Time.deltaTime;


    }
}
