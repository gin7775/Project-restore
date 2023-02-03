using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    private Transform transform;
    private float horizontalSpeed;
    private float verticalSpeed;
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
    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, 0, (transform.position.z + 0.1f) * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3((transform.position.x + 0.1f) * Time.deltaTime, 0, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, 0, (transform.position.z - 0.1f) * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3((transform.position.x - 0.1f) * Time.deltaTime, 0, transform.position.z);
        }

    }

}
