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
    public GameObject[] inactiveChurchGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        lucesCasa = 5;
        lucesCripta = 5;
        lucesIglesia = 5;
        isCollectedLucesCasa = false;
        isCollectedLucesCripta = false;
        isCollectedLucesIglesia = false;

        lucesCripta = activateChildCount(inactiveCriptGameObjects);
    }

    void Update()
    {

        if (isCollectedLucesCripta)
        {
            lucesIglesia = activateChildCount(inactiveChurchGameObjects);
        }

        if (isCollectedLucesIglesia)
        {
            lucesCasa = activateChildCount(inactiveHouseGameObjects);
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

        if (lucesCasa <= 0 && !isCollectedLucesCasa)
        {
            isCollectedLucesCasa = true;
            finishCasa();
        }

    }
    private int activateChildCount(GameObject[] array)
    {
        int contador = 0;
        Debug.Log("lenght " + array.Length);
        foreach (GameObject go in array)
        {
            if (go != null) {
                Debug.Log("lenght " + array.Length);
                contador = array.Length;
                Debug.Log("contador " + contador);
                go.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        return contador;
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
