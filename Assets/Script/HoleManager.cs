using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    [SerializeField] int sceneToLoad;
    private IEnumerator coroutine;
    [SerializeField] int time;

    public void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Player"))
        {
            Debug.Log("Victory !");
            coroutine = ChangeScene();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator ChangeScene()
    {
        Fader fader = FindObjectOfType<Fader>();
        yield return fader.FadeOut(time);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneToLoad);
        yield return fader.FadeIn(time);
        
            
    }
}