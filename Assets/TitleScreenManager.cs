using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMODUnity;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject CreditScreen;
    bool creditsShown;
    public StudioEventEmitter menuButton;


    public void StartGame()
    {
        SceneManager.LoadScene(1);
        menuButton.Play();
    }
    public void ExitGame()
    {
        Application.Quit();
        menuButton.Play();

    }
    public void ShowCredits()
    {
        creditsShown = true;
        CreditScreen.SetActive(true);
        menuButton.Play();

    }
    private void Update()
    {
        if (creditsShown && Input.anyKeyDown)
        {
            creditsShown = false;
            CreditScreen.SetActive(false);
        }
    }
}
