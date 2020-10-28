using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// on rajoute le namespace scenemanagement pour gérer le changement de scene

public class Chargement_Menu : MonoBehaviour
{
    [SerializeField] private GameObject Chargement;// on reference le gameobject dans l'inspector
    [SerializeField] private string SceneToLoad; // permet de choisir la scene que nous voulons charger lors de l'activation du bouton


    public void LoadScene()
    {
        StartCoroutine(Load());//commence le chargement de la scene en parallèle
    }

    private IEnumerator Load() //fonction qui permet de lancer les différentes animations faites
    {
        var LoadingScreenInstance = Instantiate(Chargement);// on instancie le canvas sur laquelle se trouve l'animation
        DontDestroyOnLoad(LoadingScreenInstance);// on lui demande de ne pas supprimer le canvas apres avoir joué l'anim
        var LoadingAnimator = LoadingScreenInstance.GetComponent<Animator>();// on recupere le composant animator dans le canvas
        var AnimationTime = LoadingAnimator.GetCurrentAnimatorStateInfo(0).length;//cela permet de calculer le temps de l'animation
        var Loading = SceneManager.LoadSceneAsync(SceneToLoad);//permet de charger a scene en arriere plan pendant l'animation

        Loading.allowSceneActivation = false;// cela descative le canvas où se trouve l'animation

        while (!Loading.isDone)// tant que la scene n'a pas atteint 100% de chargement, elle ne lance pas la scene
        {
            if(Loading.progress >= 0.9f)
            {
                Loading.allowSceneActivation = true;
                LoadingAnimator.SetTrigger("Chargement");
            }

            yield return new WaitForSeconds(AnimationTime);
        }
    }
}
