using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    public static bool GameIsPaused = false;

    public GameObject PauseMenuUi;
    private Inputs inputs;


    private void OnEnable()
    {
        inputs = new Inputs();
        inputs.Enable();
        inputs.Perso.Pause.performed += OnPausePerformed;
        
    }

    private void OnPausePerformed(InputAction.CallbackContext obj)
    {
        
        Resume();
        Pause();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void Resume()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading menu...");//Charge la scène du jeu
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit menu...");//Charge la scène du jeu
    }

}
