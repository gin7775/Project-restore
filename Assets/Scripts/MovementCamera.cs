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
    public float fowardAcceleration = 2.5f, strafeAcceleration=2f, hoverAcceleration=2f;
    public float rootLimit;
    public GameObject camara;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    // Start is called before the first frame update
    void Start()
    {
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
        float negRot = mouseDistance.x* lookRateSpeed *Time.deltaTime;
        float posRot = 0;
       
        transform.Rotate(posRot, negRot, 0f, Space.Self);

        //LimitRoot();

        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed,strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp( activeHoverSpeed,Input.GetAxisRaw("Vertical") * hoverSpeed,hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * forwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);

    }

    public void LimitRoot()
    {

        Vector3 playerEulerAngles = transform.rotation.eulerAngles;
        
        playerEulerAngles.y = (playerEulerAngles.y > 180) ? playerEulerAngles.y - 360 : playerEulerAngles.y;
        playerEulerAngles.y = Mathf.Clamp(playerEulerAngles.y, rootLimit * -1, rootLimit);

        playerEulerAngles.x = (playerEulerAngles.x > 180) ? playerEulerAngles.x - 360 : playerEulerAngles.x;
        playerEulerAngles.x = Mathf.Clamp(playerEulerAngles.x, rootLimit * -1, rootLimit);

        transform.rotation = Quaternion.Euler(playerEulerAngles);
    }

}
