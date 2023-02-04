using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //private int fatuoCasa;
    //private int fatuoCripta;
    [SerializeField] int lucesIglesia;
    [SerializeField] int fatuoIglesia;

    //private bool isCollectedfatuoCasa;
    //private bool isCollectedfatuoCripta;
    [SerializeField] bool isCollectedLucesIglesia;

    // Start is called before the first frame update
    void Start()
    {
        lucesIglesia = 0;
        fatuoIglesia = 0;
        if (GameObject.FindGameObjectsWithTag("luzIglesia") != null)
        {
            lucesIglesia = GameObject.FindGameObjectsWithTag("luzIglesia").Length;
        }
        if (GameObject.FindGameObjectsWithTag("fatuoIglesia") != null)
        {
            fatuoIglesia = GameObject.FindGameObjectsWithTag("fatuoIglesia").Length;
        }
        isCollectedLucesIglesia = false;
    }

    void Update()
    {
        if (lucesIglesia <= 0 && !isCollectedLucesIglesia)
        {
            isCollectedLucesIglesia = true;
            finishIglesia();
        }

    }

    public void collectarFatuoIglesia()
    {
        fatuoIglesia--;
    }

    public void collectarLuzIglesia()
    {
        lucesIglesia--;
    }

    private void finishIglesia()
    {
        Debug.Log("isCollectedLucesIglesia " + isCollectedLucesIglesia);
    }
}
