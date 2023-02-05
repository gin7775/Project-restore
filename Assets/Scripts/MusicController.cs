using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public MusicManager musicManager;
    public AudioSource menuFX;
    public AudioSource fire, luz, desbloqueo;
    // Start is called before the first frame update
    void Start()
    {
       musicManager = FindObjectOfType<MusicManager>();
        menuFX = musicManager.RecieveMenuFX1();
        fire = musicManager.fire;
        luz = musicManager.luz;
        desbloqueo = musicManager.desbloqueo;
    }

    // Update is called once per frame
    void Update()
    {
        if(musicManager == null)
        {
            musicManager = FindObjectOfType<MusicManager>();
            menuFX = musicManager.RecieveMenuFX1();
            fire = musicManager.fire;
            luz = musicManager.luz;
            desbloqueo = musicManager.desbloqueo;
        }
    }
    public void PlayMenuFX()
    {
        menuFX.Play();
    }
    public void PlayFXCristal()
    {
        luz.Play();
    }
    public void PlayFXFire()
    {
        fire.Play();
    }
    public void PlayFXDesbloqueo()
    {
        desbloqueo.Play();
    }

    public void CallUnmuteAll()
    {
        musicManager.UnmuteAll();
    }
    public void CallUnmuteTrack(MusicManager.Instrumentos instrumento)
    {
        musicManager.unMuteAudio(instrumento);
    }
    public void CallAudioFinal()
    {
        musicManager.MuteDemute();
    }
  
}
