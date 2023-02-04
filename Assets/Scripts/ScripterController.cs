using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class ScripterController : MonoBehaviour
{
    public float fuegoFatuoContainer;
    public GameManager gameManager;

    private void Start()
    {
        fuegoFatuoContainer = 6;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "luzCasa")
        {
            gameManager.collectarLuzCasa();
            Destroy(other.gameObject.GetComponentInParent<Transform>().parent.gameObject);
            Debug.Log("Hey, lo tienes luzCasa");
        }

        if (other.gameObject.tag == "luzCripta")
        {
            gameManager.collectarLuzCripta();
            Destroy(other.gameObject.GetComponentInParent<Transform>().parent.gameObject);
            Debug.Log("Hey, lo tienes luzCripta");
        }

        if (other.gameObject.tag == "luzIglesia")
        {
            gameManager.collectarLuzIglesia();
            Destroy(other.gameObject.GetComponentInParent<Transform>().parent.gameObject);
            Debug.Log("Hey, lo tienes luzIglesia");
        }

        if (other.gameObject.tag == "fatuo")
        {
            fuegoFatuoContainer += 1;
            Destroy(other.gameObject.GetComponentInParent<Transform>().parent.gameObject);
            Debug.Log("Hey, lo tienes fatuo " + fuegoFatuoContainer);
        }
    }

}
