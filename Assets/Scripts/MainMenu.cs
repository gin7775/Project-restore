using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneGame(int sceneToChange)
    {
        
        switch (sceneToChange)
        {
            case 1:
                SceneManager.LoadScene("Blocking");
                break;
            case 2:
                SceneManager.LoadScene("Opciones");
                break;
            case 3:
                SceneManager.LoadScene("Credits");
                break;
            case 4:
                SceneManager.LoadScene("Menu");
                break;
            case 5:
                Application.Quit();
                break;

        }
        
    }



    public void CargarNivel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }

}
