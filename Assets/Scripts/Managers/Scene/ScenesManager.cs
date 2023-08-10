using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;
    void Awake()
    {
        instance = this;
    }

    public enum Scene
    {
        MainMenu,
        Level01
    }

    //Loads Specific Scene
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    //Loads First Scene
    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.Level01.ToString());
    }

    //Loads Next Scene
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Loads Main Menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }
}
