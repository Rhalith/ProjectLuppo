using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [Header("Set Slider")]
    [SerializeField] private Slider _Slider;
    [SerializeField] private GameObject optionsUI;

    private void Start()
    {
        //Adds listener for Volume Slider
        _Slider.onValueChanged.AddListener(val => AudioManager.instance.ChangeMasterVolume(val));
    }
    #region URL-Methods

    //Opens URL for Instagram
    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/badge_r._studios/");
    }
    //Opens URL for Facebook
    public void OpenFacebook()
    {
        Application.OpenURL("Enter Facebook URL Here");
    }
    //Opens URL for Discord
    public void OpenDiscord()
    {
        Application.OpenURL("Enter Discord URL Here");
    }
    //Opens URL for Reddit
    public void OpenReddit()
    {
        Application.OpenURL("Enter Reddit URL Here");
    }
    //Opens URL for Privacy Policy
    public void OpenPrivacyPolicy()
    {
        Application.OpenURL("Enter Privacy Policy URL Here");
    }
    //Opens URL for Terms & Conditions
    public void OpenTermsConditions()
    {
        Application.OpenURL("Enter Terms & Conditions URL Here");
    }
    //Opens URL for Player Support
    public void OpenPlayerSupport()
    {
        Application.OpenURL("Enter Player Support URL Here");
    }
#endregion

    //Toggle Music
    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
    }

    //Toggle Effect
    public void ToggleEffects()
    {
        AudioManager.instance.ToggleEffects();
    }

    //Go Fullscreen or Windowed
    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Is Fullscreen:" + isFullscreen);
    }

    //Closes Options Menu
    public void CloseOptions() 
    {
        optionsUI.SetActive(false);
    }
}
