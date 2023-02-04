using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource[] tracks;
    public AudioSource wind;
    public AudioSource menufx1;
    public enum Instrumentos
    {
        Piano, //0
        Tom, //1
        Flauta, //2
        Melody, //3
        Bajo, //4
        Pads //5
    }
    Instrumentos instrumento;
    private static MusicManager _instance;
    
    public static MusicManager Instance
    {
        get
        {
            return _instance;
        }
        private set
        {
            if (_instance is null)
            {
                _instance = value;
            }
            else
            if (_instance is null)
            {
                Destroy(value.gameObject);
                _instance = new MusicManager();
            }
            
        }
    }



    private void Awake()
    {
        Instance = this;
       
        for (int i = 0; i < tracks.Length; i++)
        {
            tracks[i].mute = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            unMuteAudio(Instrumentos.Piano);
        }
        if (Input.GetKey(KeyCode.X))
        {
            unMuteAudio(Instrumentos.Tom);
        }
        if (Input.GetKey(KeyCode.C))
        {
            unMuteAudio(Instrumentos.Flauta);
        }
        if (Input.GetKey(KeyCode.V))
        {
            unMuteAudio(Instrumentos.Melody);
        }
        if (Input.GetKey(KeyCode.B))
        {
            unMuteAudio(Instrumentos.Bajo);
        }
        if (Input.GetKey(KeyCode.N))
        {
            unMuteAudio(Instrumentos.Pads);
        }

    }
    public void unMuteAudio(Instrumentos instrumento)
    {
        int audio = Convert.ToInt32(instrumento);
        switch (instrumento)
        {

            case Instrumentos.Piano:
                tracks[audio].mute = false;
                break;
            case Instrumentos.Tom:
                tracks[audio].mute = false;
                break;
            case Instrumentos.Flauta:
                tracks[audio].mute = false;
                break;
            case Instrumentos.Melody:
                tracks[audio].mute = false;
                break;
            case Instrumentos.Bajo:
                tracks[audio].mute = false;
                break;
            case Instrumentos.Pads:
                tracks[audio].mute = false;
                break;
            default:
                break;

        }
    }

    public void UnmuteAll()
    {
        for (int i = 0; i < tracks.Length; i++)
        {
            tracks[i].mute = false;
        }
    }

    public AudioSource RecieveMenuFX1()
    {
        AudioSource fx;
        fx = menufx1;

        return fx;
    }

}
