using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource[] tracks;
    public AudioSource wind;
    public AudioSource menufx1;
    public AudioSource bucleFinal;
    public AudioSource fire, luz,desbloqueo;
    public enum Instrumentos
    {
        Piano, //0
        Celesta, //1
        PercInicial, //2
        Violin, //3
        Bajo, //4
        Pads, //5
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
        bucleFinal.mute = true;

        for (int i = 0; i < tracks.Length; i++)
        {
            tracks[i].mute = true;
        }
      
    }
    // Start is called before the first frame update
    void Start()
    {
        UnmuteAll();
       
        DontDestroyOnLoad(this);

    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Z))
        //{
        //    unMuteAudio(Instrumentos.Piano);
        //}
        //if (Input.GetKey(KeyCode.X))
        //{
        //    unMuteAudio(Instrumentos.Celesta);
        //}
        //if (Input.GetKey(KeyCode.C))
        //{
        //    unMuteAudio(Instrumentos.PercInicial);
        //}
        //if (Input.GetKey(KeyCode.V))
        //{
        //    unMuteAudio(Instrumentos.Violin);
        //}
        //if (Input.GetKey(KeyCode.B))
        //{
        //    unMuteAudio(Instrumentos.Bajo);
        //}
        //if (Input.GetKey(KeyCode.N))
        //{
        //    unMuteAudio(Instrumentos.Pads);
        //}
        //if (Input.GetKey(KeyCode.O))
        //{
        //    MuteDemute();
        //}

    }
    public void unMuteAudio(Instrumentos instrumento)
    {
        int audio = Convert.ToInt32(instrumento);
        switch (instrumento)
        {

            case Instrumentos.Piano:
                tracks[audio].mute = false;
                break;
            case Instrumentos.Celesta:
                tracks[audio].mute = false;
                break;
            case Instrumentos.PercInicial:
                tracks[audio].mute = false;
                break;
            case Instrumentos.Violin:
                tracks[audio].mute = false;
                break;
            case Instrumentos.Bajo:
                tracks[audio].mute = false;
                break;
            case Instrumentos.Pads:
                MuteDemute();
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
    public void MuteDemute()
    {
        for (int i = 0; i < tracks.Length; i++)
        {
            tracks[i].mute = true;
        }
        bucleFinal.mute = false;

    }
   

}
