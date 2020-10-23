using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Fin : MonoBehaviour
{
    public void replayBouton()
    {
        SceneManager.LoadScene("SampleScene");//Charge la scène du jeu
    }

    public void menuBouton()
    {
        SceneManager.LoadScene("Menu");//Charge la scène du jeu
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
