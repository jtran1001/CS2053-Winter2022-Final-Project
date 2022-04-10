using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameMenu : MonoBehaviour
{
    // Start game
    public void PlayGame()
    {
        SceneManager.LoadScene("SlimelightLevel1");
    }

    public void PlayTutorial()
    {
        Application.Quit();
    }
}
