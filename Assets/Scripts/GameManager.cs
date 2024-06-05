using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject StartMenuM;
   
 

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
        StartMenuM.SetActive(false);
        
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        StartMenuM.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
