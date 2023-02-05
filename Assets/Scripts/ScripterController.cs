using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class ScripterController : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("luzCripta"))
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Explosion");
            //Destroy(other.gameObject.GetComponentInChildren<Transform>().gameObject);
            Debug.Log("Hey, lo tienes luzCripta");
        }

        if (other.gameObject.tag.Equals("luzIglesia"))
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Explosion");
            //Destroy(other.gameObject.GetComponentInParent<Transform>().parent.gameObject);
            Debug.Log("Hey, lo tienes luzIglesia");
        }

        if (other.gameObject.tag.Equals("luzMolino"))
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Explosion");
            //Destroy(other.gameObject.GetComponentInParent<Transform>().parent.gameObject);
            Debug.Log("Hey, lo tienes luzMolino");
        }

        if (other.gameObject.tag.Equals("luzCasa"))
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Explosion");
            //Destroy(other.gameObject.GetComponentInChildren<Transform>().gameObject);
            Debug.Log("Hey, lo tienes luzCasa");
        }

    }

}
