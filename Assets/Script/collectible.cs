﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;// on rajoute le namespace scenemanagement pour gérer le changement de scene

public class collectible : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private GameObject Victoire;

    // on créé une variable qui apparait dans l'inspector pour afficher le score
    public int ScoreValue;
    public int ScoreFinal = 15;
    // autre variable "valeur du score" nombre entier "int"


    void Start()
    {
        ScoreValue = 0; //donne une valeur à la variable "valeur du score"
    }


    void Update()
    {
        Score.text = "Score : " + ScoreValue + "/15";
        // le compteur affiche "score : + la valeur de ScoreValue

    }

    private void OnTriggerEnter2D(Collider2D other)
    // on apelle une fonction qui detecte quand un objet est traversé, 
    // other on peut l'appeller comme on veut
    {

        //Debug.Log("tu as récupéré un Coin!");
        // on affiche un message dans la console, quand la fonction est vérifié
        // le compteur fonctionne et il affiche "pumpkin detected" dans la console

        if (other.gameObject.CompareTag("Coin"))
        // on appelle la variable qu'on a mis dans la fonction avec l'objet et le tag qu'on à mis a nos collectibles
        {

            Destroy(other.gameObject);
            ScoreValue += 1;
            /* on peut ecrire aussi : 
            scoreValue ++;
            ScoreValue = ScoreValue +1;
            */
        }

        if (ScoreValue == ScoreFinal)
        {
            Instantiate(Victoire);
        }
    }
}