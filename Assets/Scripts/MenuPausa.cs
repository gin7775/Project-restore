using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool Paused = false;

    public GameObject player;

    Rigidbody rb;

    public GameObject MenuPausaUI;

    public MovementCamera movement;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        MenuPausaUI.SetActive(false);
        rb.constraints = RigidbodyConstraints.None;
        movement.moving = true;
        //Time.timeScale = 1f;
        Paused = false;
    }

    void Pause()
    {
        MenuPausaUI.SetActive(true);
        //Time.timeScale = 0f;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        movement.moving = false;
        Debug.Log("PAUSA");
        Paused = true;
    }
    public void LoadMenu () 
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadOpciones ()
    {
        SceneManager.LoadScene("Opciones");
    }
    public void QuitGame ()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
