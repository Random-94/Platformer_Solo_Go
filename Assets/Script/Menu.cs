using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;// on rajoute le namespace scenemanagement pour gérer le changement de scene

public class Menu : MonoBehaviour
{

    public void playBouton()
    {
        SceneManager.LoadScene("SampleScene");//Charge la scène du jeu
    }

    public void creditsBouton()
    {
        SceneManager.LoadScene("Credit");//Charge la scène de crédits
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
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
