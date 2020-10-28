using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;// on rajoute le namespace scenemanagement pour gérer le changement de scene

public class Credit : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading menu...");//Charge la scène du jeu
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
