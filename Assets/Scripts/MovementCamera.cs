using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;
using Cinemachine;

public class MovementCamera : MonoBehaviour
{
    public float forwardSpeed, strafeSpeed, hoverSpeed, actualHover;
    private float activeStrafeSpeed, activeHoverSpeed, highSpeed, lowSpeed, initialSpeed;
    public float fowardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;
    public float rootLimit, rayDistance = 2;
    public GameObject camara;
    public Transform[] firePos, fatuos;
    public GameObject caster;
    public int fuegoFatuoContainer;
    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    public bool moving = true;

    // Start is called before the first frame update
    void Start()
    {
        fuegoFatuoContainer = 0;
        actualHover = strafeSpeed;
        initialSpeed = forwardSpeed;
        highSpeed = initialSpeed + 5;
        lowSpeed = initialSpeed - 5;
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;

    }

    // Update is called once per frame
    void Update()
    {

        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        //float posRot = -mouseDistance.y * lookRateSpeed * Time.deltaTime;
        float negRot = mouseDistance.x * lookRateSpeed * Time.deltaTime;
        //float posRot = 0;

        // transform.Rotate(posRot, negRot, 0f, Space.Self);

        RaycastHit hit;

        if (moving)
        {
            activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
            activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Vertical") * hoverSpeed, hoverAcceleration * Time.deltaTime);

            transform.position += transform.forward * forwardSpeed * Time.deltaTime;
            transform.position += transform.up * activeHoverSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, Input.GetAxisRaw("Horizontal") * strafeSpeed * 2 * Time.deltaTime);
        }


        Debug.DrawRay(caster.transform.position, caster.transform.up * -1 * rayDistance, Color.red);

        if (Physics.Raycast(caster.transform.position, caster.transform.up * -1, out hit, rayDistance))
        {
            strafeSpeed = 0;
        }
        else
        {
            strafeSpeed = actualHover;
        }

        if (Input.GetKey(KeyCode.Space) && fuegoFatuoContainer > 0)
        {
            forwardSpeed = lowSpeed;
            //Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.FieldOfView = Mathf.Lerp(Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.FieldOfView, 50, 0.02f);

        }

        if (Input.GetKey(KeyCode.LeftShift) && fuegoFatuoContainer > 0)
        {
            forwardSpeed = highSpeed;
            //Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.FieldOfView = Mathf.Lerp(Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.FieldOfView, 70, 0.02f);

        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            //Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.FieldOfView = Mathf.Lerp(Camera.main.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.FieldOfView, 60, 0.02f);
            if (fuegoFatuoContainer > 0)

                if (fuegoFatuoContainer > 0)
                {
                    fuegoFatuoContainer--;
                    Destroy(fatuos[fuegoFatuoContainer].gameObject);

                }
            forwardSpeed = initialSpeed;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fatuo")
        {
            fatuos[fuegoFatuoContainer] = other.transform;
            other.transform.position = firePos[fuegoFatuoContainer].position;
            other.transform.rotation = firePos[fuegoFatuoContainer].rotation;
            fatuos[fuegoFatuoContainer] = other.transform;
            other.transform.SetParent(firePos[fuegoFatuoContainer]);
            fuegoFatuoContainer++;


            Debug.Log("Hey, lo tienes fatuo " + fuegoFatuoContainer);
        }
    }

}
