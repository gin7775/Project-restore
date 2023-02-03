using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class MovementCamera : MonoBehaviour
{
    public float forwardSpeed, strafeSpeed, hoverSpeed;
    private float activeStrafeSpeed, activeHoverSpeed;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        activeStrafeSpeed = Input.GetAxisRaw("Horizontal") + strafeSpeed;
        activeHoverSpeed = Input.GetAxisRaw("Hover") + hoverSpeed;

        transform.position += transform.forward * forwardSpeed * Time.deltaTime;
    }
}
