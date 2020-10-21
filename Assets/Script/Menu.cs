using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void playBouton()
    {
        SceneManager.LoadScene("SampleScene");//Charge la scène du jeu
    }

    public void creditsBouton()
    {
        SceneManager.LoadScene("MyCredits");//Charge la scène de crédits
    }

    //Fonction pour le bouton "Quitter"
    public void quitBouton()
    {
        Debug.Log("Ferme le jeu");//Code de débug pour voir si le bouton réagit bien.
        Application.Quit();//Ferme et Arrête l'application
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
