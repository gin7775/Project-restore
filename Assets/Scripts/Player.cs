using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject targetF,cameraObject;

    // Update is called once per frame
    void Update()
    {
        transform.position = targetF.transform.position;
        transform.rotation = cameraObject.transform.rotation;
    }
}
