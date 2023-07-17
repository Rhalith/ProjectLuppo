using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject optionsUI;

    public void StartNewGame()
    {
        ScenesManager.instance.LoadNewGame();
    }

    public void OpenOptions()
    {
        optionsUI.SetActive(true);
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}
