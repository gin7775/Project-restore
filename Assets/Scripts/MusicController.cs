using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public MusicManager musicManager;
    public AudioSource menuFX;
   
    // Start is called before the first frame update
    void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        menuFX = musicManager.RecieveMenuFX1();
    }

    // Update is called once per frame
    void Update()
    {
        if(musicManager == null)
        {
            musicManager = FindObjectOfType<MusicManager>();
            menuFX = musicManager.RecieveMenuFX1();
        }
    }
    public void PlayMenuFX()
    {
        menuFX.Play();
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
