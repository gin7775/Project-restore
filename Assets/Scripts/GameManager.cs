using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int lucesCasa;
    [SerializeField] int lucesCripta;
    [SerializeField] int lucesIglesia;

    [SerializeField] bool isCollectedLucesCasa;
    [SerializeField] bool isCollectedLucesCripta;
    [SerializeField] bool isCollectedLucesIglesia;

    // Start is called before the first frame update
    void Start()
    {
        lucesIglesia = 0;
        if (GameObject.FindGameObjectsWithTag("luzIglesia") != null)
        {
            lucesIglesia = GameObject.FindGameObjectsWithTag("luzIglesia").Length;
        }
        isCollectedLucesIglesia = false;
    }

    void Update()
    {
        if (lucesCasa <= 0 && !isCollectedLucesCasa)
        {
            isCollectedLucesCasa = true;
            finishCasa();
        }

        if (lucesCripta <= 0 && !isCollectedLucesCripta)
        {
            isCollectedLucesCripta = true;
            finishCripta();
        }

        if (lucesIglesia <= 0 && !isCollectedLucesIglesia)
        {
            isCollectedLucesIglesia = true;
            finishIglesia();
        }

        if (isCollectedLucesCasa)
        {
            if (GameObject.FindGameObjectsWithTag("luzCasa") != null)
            {
                lucesCasa = GameObject.FindGameObjectsWithTag("luzCasa").Length;
            }
        }

        if (isCollectedLucesCripta)
        {
            if (GameObject.FindGameObjectsWithTag("luzCripta") != null)
            {
                lucesCripta = GameObject.FindGameObjectsWithTag("luzCripta").Length;
            }
        }

    }

    public void collectarLuzCasa()
    {
        lucesCasa--;
    }

    public void collectarLuzCripta()
    {
        lucesCripta--;
    }

    public void collectarLuzIglesia()
    {
        lucesIglesia--;
    }

    private void finishCasa()
    {
        Debug.Log("isCollectedLucesIglesia " + isCollectedLucesIglesia);
    }

    private void finishCripta()
    {
        Debug.Log("isCollectedLucesIglesia " + isCollectedLucesIglesia);
    }

    private void finishIglesia()
    {
        Debug.Log("isCollectedLucesIglesia " + isCollectedLucesIglesia);
    }
}
