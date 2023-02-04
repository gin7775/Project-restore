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

    public GameObject[] inactiveHouseGameObjects;
    public GameObject[] inactiveCriptGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        lucesCasa = 5;
        lucesCripta = 5;
        lucesIglesia = 5;
        if (GameObject.FindGameObjectsWithTag("luzIglesia") != null)
        {
            lucesIglesia = GameObject.FindGameObjectsWithTag("luzIglesia").Length;
        }
        isCollectedLucesCasa = false;
        isCollectedLucesCripta = false;
        isCollectedLucesIglesia = false;
    }

    void Update()
    {
        if (isCollectedLucesIglesia)
        {
            if (GameObject.FindGameObjectsWithTag("luzCasa") != null)
            {
                inactiveHouseGameObjects = GameObject.FindGameObjectsWithTag("luzCasa");
                foreach (GameObject gameObject in inactiveHouseGameObjects)
                {
                    Debug.Log(gameObject.GetComponent<Transform>().position);
                    gameObject.SetActive(true);
                }
                lucesCasa = GameObject.FindGameObjectsWithTag("luzCasa").Length;
            }
        }

        if (isCollectedLucesCasa)
        {
            if (GameObject.FindGameObjectsWithTag("luzCripta") != null)
            {
                lucesCripta = GameObject.FindGameObjectsWithTag("luzCripta").Length;
                foreach (GameObject gameObject in inactiveCriptGameObjects)
                {
                    gameObject.SetActive(true);
                }
            }
        }

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
        Debug.Log("isCollectedLucesCasa " + isCollectedLucesIglesia);
    }

    private void finishCripta()
    {
        Debug.Log("isCollectedLucesCripta " + isCollectedLucesIglesia);
    }

    private void finishIglesia()
    {
        Debug.Log("isCollectedLucesIglesia " + isCollectedLucesIglesia);
    }
}
