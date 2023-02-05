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


        lucesCripta = activateChildCount(inactiveCriptGameObjects);
    }

    void Update()
    {
        lucesCripta = activateChildCount(inactiveCriptGameObjects);

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
        //Hay que meter el molino, las variables creo que están todas.
        if (lucesCasa <= 0 && !isCollectedLucesCasa)
        {
            isCollectedLucesCasa = true;
            finishCasa();
        }

    }
    private int activateChildCount(GameObject[] array)
    {
        int contador = 0;
        foreach (GameObject go in array)
        {
            if (go != null) {
                if (go.transform.childCount > 0)
                {
                    contador = array.Length;
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

 

    private void finishCripta() 
    {
        musicController.CallUnmuteTrack(MusicManager.Instrumentos.Piano);
        Debug.Log("isCollectedLucesCripta " + isCollectedLucesIglesia);
    }

    private void finishIglesia()
    {
        musicController.CallUnmuteTrack(MusicManager.Instrumentos.Piano);
        Debug.Log("isCollectedLucesIglesia " + isCollectedLucesIglesia);
    }
    private void finishMolino()
    {
        musicController.CallUnmuteTrack(MusicManager.Instrumentos.Piano);
        Debug.Log("isCollectedLucesMolino " + isCollectedLucesMolino);
    }
    private void finishCasa() //Las casas se construyen todas a la vez, por lo que hay que hacer una lista de casas para reconstruirlas
    {
        musicController.CallAudioFinal();
        Debug.Log("isCollectedLucesCasa " + isCollectedLucesCasa);
    }
}
