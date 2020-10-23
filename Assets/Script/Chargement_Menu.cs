using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chargement_Menu : MonoBehaviour
{
    [SerializeField] private GameObject Chargement;
    [SerializeField] private string SceneToLoad;
    

    public void LoadScene()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        var LoadingScreenInstance = Instantiate(Chargement);
        DontDestroyOnLoad(LoadingScreenInstance);
        var LoadingAnimator = LoadingScreenInstance.GetComponent<Animator>();
        var AnimationTime = LoadingAnimator.GetCurrentAnimatorStateInfo(0).length;
        var Loading = SceneManager.LoadSceneAsync(SceneToLoad);

        Loading.allowSceneActivation = false;

        while(!Loading.isDone)
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
