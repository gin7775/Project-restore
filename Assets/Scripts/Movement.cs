using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class MovementCamera : MonoBehaviour
{
    private Transform transform;
    private float horizontalSpeed = 10f;
    private float verticalSpeed = 10f;
    [SerializeField] float speed = 10f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        transform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        horizontalSpeed = 10f;
        verticalSpeed = 10f;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.forward;


        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position - new Vector3(transform.position.x + speed, transform.position.y, transform.position.z)), speed * Time.deltaTime);
            //timeCount = timeCount + Time.deltaTime;
            //transform.position = new Vector3(transform.position.x * Time.deltaTime + 10, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position - new Vector3(transform.position.x - speed, transform.position.y, transform.position.z)), speed * Time.deltaTime);
        }
    }
}
