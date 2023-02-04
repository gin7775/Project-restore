using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool Paused = false;

    public GameObject MenuPausaUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Resume ()
    {
        MenuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    void Pause()
    {
        MenuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
}
