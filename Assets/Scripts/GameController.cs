using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void GotoGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GotoGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
