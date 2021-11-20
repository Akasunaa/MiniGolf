using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorymenuScript : MonoBehaviour
{
    private GameObject victMenu;
    private GameObject fader;
    private IEnumerator coroutine;

    private void Start()
    {
        victMenu=GameObject.Find("VictoryMenu").gameObject;
        fader = GameObject.Find("Fader").gameObject;
    }

    //For the return Main Menu Button
    public void LaunchReturnMain()
    {
        coroutine=ReturnMain();
        StartCoroutine(coroutine);
    }

    public IEnumerator ReturnMain()
    {
        fader.transform.GetChild(0).GetComponent<Fader>().StartTransition(0,2f);
        yield return null;
    }

    //For the quit button:
    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
