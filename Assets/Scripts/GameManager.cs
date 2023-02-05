using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [SerializeField] GameObject inactiveHouseGameObjects;
    [SerializeField] GameObject inactiveCriptGameObjects;
    [SerializeField] GameObject inactiveChurchGameObjects;
    [SerializeField] GameObject inactiveWindmillGameObjects;

    public MusicController musicController;
    

    // Start is called before the first frame update
    void Start()
    {
        lucesCasa = 5;
        lucesCripta = 5;
        lucesMolino = 5;
        lucesIglesia = 5;
        isCollectedLucesCasa = false;
        isCollectedLucesCripta = false;
        isCollectedLucesIglesia = false;
        isCollectedLucesMolino = false;

        musicController = FindObjectOfType<MusicController>();

        // Obtiene el objeto padre de las luces
        inactiveHouseGameObjects = GameObject.FindGameObjectWithTag("HousesLights");
        inactiveCriptGameObjects = GameObject.FindGameObjectWithTag("MausoleumLights");
        inactiveChurchGameObjects = GameObject.FindGameObjectWithTag("ChurchLights");
        inactiveWindmillGameObjects = GameObject.FindGameObjectWithTag("WindmillLights");

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
            lucesMolino = ActivateChildCount(inactiveWindmillGameObjects);
        }

        if (isCollectedLucesMolino)
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

        if (lucesMolino <= 0 && !isCollectedLucesMolino)
        {
            isCollectedLucesMolino = true;
            FinishMolino();
        }

        if (lucesCasa <= 0 && !isCollectedLucesCasa)
        {
            isCollectedLucesCasa = true;
            FinishCasa();
        }

    }

    // Activa las luces hijas
    private int ActivateChildCount(GameObject go)
    {
        int contador = 0;

        for (int i = 0; i < go.transform.childCount; i++)
        {
            GameObject auxGo = go.transform.GetChild(i).gameObject;
            for (int j = 0; j < auxGo.transform.childCount; j++)
            {
                auxGo.transform.GetChild(j).gameObject.SetActive(true);
                contador++;
            }
        }
        
        return contador;
    }

    // Oculta ruinas y muestra edificio
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
        musicController.CallUnmuteTrack(MusicManager.Instrumentos.Piano);
        StartCoroutine(Building("Mausoleum"));
        Debug.Log("isCollectedLucesCripta " + isCollectedLucesCripta);
    }

    private void FinishIglesia()
    {
        musicController.CallUnmuteTrack(MusicManager.Instrumentos.Celesta);
        StartCoroutine(Building("Church"));
        Debug.Log("isCollectedLucesIglesia " + isCollectedLucesIglesia);
    }
    private void FinishMolino()
    {
        musicController.CallUnmuteTrack(MusicManager.Instrumentos.PercInicial);
        StartCoroutine(Building("Windmill"));
        Debug.Log("isCollectedLucesMolino " + isCollectedLucesMolino);
    }
    private void FinishCasa()
    {
        musicController.CallAudioFinal();
        StartCoroutine(Building("House"));
        Debug.Log("isCollectedLucesCasa " + isCollectedLucesCasa);
    }

    // TimeOut
    IEnumerator Building(String build)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        // Cambia de Ruinas
        ActivateBuildings(GameObject.FindGameObjectWithTag(build));

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
