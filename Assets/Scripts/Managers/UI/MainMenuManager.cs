using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuUI;
    [SerializeField] private GameObject _optionsUI;

    //Starts New Game
    public void StartNewGame()
    {
        ScenesManager.instance.LoadNewGame();
    }

    //Opens Options Menu
    public void OpenOptions()
    {
        _optionsUI.SetActive(true);
    }

    //Closes Game
    public void ExitGame() 
    {
        Application.Quit();
    }
}
