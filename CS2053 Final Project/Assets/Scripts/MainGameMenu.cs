using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameMenu : MonoBehaviour
{
    // Start game
    public void PlayGame()
    {
        SceneManager.LoadScene("SlimeGame1");
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene("SlimeGame");
    }
}
