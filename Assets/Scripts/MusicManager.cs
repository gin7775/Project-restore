using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource[] tracks;
    public AudioSource wind;
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

    private void Awake()
    {
        for(int i = 0; i < tracks.Length; i++)
        {
            tracks[i].mute = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void unMuteAudio(Instrumentos instrumento)
    {
        switch (instrumento)
        {
            case Instrumentos.Piano:
                break;
            case Instrumentos.Tom:
                break;
            case Instrumentos.Flauta:
                break;
            case Instrumentos.Melody:
                break;

            
        }
    }
}
