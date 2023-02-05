using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int lucesCasa;
    [SerializeField] int lucesCripta;
    [SerializeField] int lucesIglesia;
    [SerializeField] int lucesMolino;

    [SerializeField] bool isCollectedLucesCasa;
    [SerializeField] bool isCollectedLucesCripta;
    [SerializeField] bool isCollectedLucesIglesia;
    [SerializeField] bool isCollectedLucesMolino;

    public GameObject[] inactiveHouseGameObjects;
    public GameObject[] inactiveCriptGameObjects;
    public GameObject[] inactiveChurchGameObjects;

    public MusicController musicController;
    

    // Start is called before the first frame update
    void Start()
    {
        lucesCasa = 5;
        lucesCripta = 5;
        lucesIglesia = 5;
        isCollectedLucesCasa = false;
        isCollectedLucesCripta = false;
        isCollectedLucesIglesia = false;
        isCollectedLucesMolino = false;

        musicController = FindObjectOfType<MusicController>();  

        lucesCripta = ActivateChildCount(inactiveCriptGameObjects);
    }

    void Update()
    {
        lucesCripta = ActivateChildCount(inactiveCriptGameObjects);

        if (isCollectedLucesCripta)
        {
            lucesIglesia = ActivateChildCount(inactiveChurchGameObjects);
        }

        if (isCollectedLucesIglesia)
        {
            lucesCasa = ActivateChildCount(inactiveHouseGameObjects);
        }

        if (lucesCripta <= 0 && !isCollectedLucesCripta)
        {
            isCollectedLucesCripta = true;
            FinishCripta();
        }

        if (lucesIglesia <= 0 && !isCollectedLucesIglesia)
        {
            isCollectedLucesIglesia = true;
            FinishIglesia();
        }
        //Hay que meter el molino, las variables creo que están todas.
        if (lucesCasa <= 0 && !isCollectedLucesCasa)
        {
            isCollectedLucesCasa = true;
            FinishCasa();
        }

    }

    private int ActivateChildCount(GameObject[] array)
    {
        int contador = 0;
        foreach (GameObject go in array)
        {
            if (go != null)
            {
                if (go.transform.childCount > 0)
                {
                    contador++;
                    go.transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    contador = go.transform.childCount;
                }
            }
        }
        return contador;
    }

    private void ActivateBuildings(GameObject padre)
    {
        for (int i = 0; i < padre.transform.childCount; i++)
        {
            GameObject auxGO = padre.transform.GetChild(i).gameObject;
            auxGO.SetActive(!auxGO.activeSelf);
        }
    }

    private void FinishCripta() 
    {
        // musicController.CallUnmuteTrack(MusicManager.Instrumentos.Piano);
        ActivateBuildings(GameObject.FindGameObjectWithTag("Mausoleum"));
        Debug.Log("isCollectedLucesCripta " + isCollectedLucesCripta);
    }

    private void FinishIglesia()
    {
        // musicController.CallUnmuteTrack(MusicManager.Instrumentos.Celesta);
        ActivateBuildings(GameObject.FindGameObjectWithTag("Church"));
        Debug.Log("isCollectedLucesIglesia " + isCollectedLucesIglesia);
    }
    private void FinishMolino()
    {
        //musicController.CallUnmuteTrack(MusicManager.Instrumentos.PercInicial);
        ActivateBuildings(GameObject.FindGameObjectWithTag("Windmill"));
        Debug.Log("isCollectedLucesMolino " + isCollectedLucesMolino);
    }
    private void FinishCasa() //Las casas se construyen todas a la vez, por lo que hay que hacer una lista de casas para reconstruirlas
    {
        // musicController.CallAudioFinal();
        ActivateBuildings(GameObject.FindGameObjectWithTag("House"));
        Debug.Log("isCollectedLucesCasa " + isCollectedLucesCasa);
    }
}
