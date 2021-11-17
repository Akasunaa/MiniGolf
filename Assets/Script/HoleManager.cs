using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    [SerializeField] int sceneToLoad;
    private IEnumerator coroutine;

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
            yield return null;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneToLoad);
    }
}