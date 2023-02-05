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
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "luzCasa")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Explosion");
            //Destroy(other.gameObject.GetComponentInChildren<Transform>().gameObject);
            Debug.Log("Hey, lo tienes luzCasa");
        }

        if (other.gameObject.tag == "luzCripta")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Explosion");
            //Destroy(other.gameObject.GetComponentInChildren<Transform>().gameObject);
            Debug.Log("Hey, lo tienes luzCripta");
        }

        if (other.gameObject.tag == "luzIglesia")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Explosion");
            //Destroy(other.gameObject.GetComponentInParent<Transform>().parent.gameObject);
            Debug.Log("Hey, lo tienes luzIglesia");
        }

       
    }

}
