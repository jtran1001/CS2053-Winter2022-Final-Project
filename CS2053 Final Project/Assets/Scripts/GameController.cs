/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public enum GameState { BEGIN, PLAYING, WIN, LOSE };

    public static GameState gameState = GameController.GameState.BEGIN;

    void Start()
    {
        if (title != null)
        {
            if (gameState == GameController.GameState.BEGIN)
                title.text = "Ball Escape!!";
            else if (gameState == GameController.GameState.WIN)
                title.text = "You Win!";
            else if (gameState == GameController.GameState.LOSE)
                title.text = "You Lose!";
        }
    }

    public void LoadGame()
    {
        gameState = GameController.GameState.PLAYING;
        SceneManager.LoadScene("Game");
        SceneManager.UnloadSceneAsync("GameController");
    }

    //This will not use in the editor... it will only work if you build your game... not required for this assignment... just here, so you know
    public void QuitGame()
    {
        Application.Quit();
    }
}
*/