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
        musicManager = GetComponent<MusicManager>();
        menuFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
