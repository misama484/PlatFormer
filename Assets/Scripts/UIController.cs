using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject panelOptions;
    public void startGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void showOptionPanel()
    {
        Time.timeScale = 0;
        panelOptions.SetActive(true);
    }

    public void hideOptionPanel()
    {
        Time.timeScale = 1;
        panelOptions.SetActive(false);
    }

    public void goToStartScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}
