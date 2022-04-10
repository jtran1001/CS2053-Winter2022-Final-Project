using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("SlimelightLevel1");
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
