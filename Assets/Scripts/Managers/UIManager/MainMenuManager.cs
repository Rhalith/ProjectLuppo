using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject optionsUI;

    //Starts New Game
    public void StartNewGame()
    {
        ScenesManager.instance.LoadNewGame();
    }

    //Opens Options Menu
    public void OpenOptions()
    {
        optionsUI.SetActive(true);
    }

    //Closes Game
    public void ExitGame() 
    {
        Application.Quit();
    }
}
