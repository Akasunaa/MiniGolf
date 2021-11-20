using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private GameObject mainContainer;
    private GameObject levelSelectCont;
    private GameObject fader;

    private void Start()
    {
        levelSelectCont=GameObject.Find("SelectLevelContainer").gameObject;
        mainContainer=GameObject.Find("MainMenuContainer").gameObject;
        levelSelectCont.SetActive(false);
        fader = GameObject.Find("Fader").gameObject;
    }

    //-------------------------------------------------
    //For the buttons that launch a level
    private IEnumerator coroutine;

    public void LaunchLevelRoutine(int levelNum)
    {
        coroutine=LaunchLevel(levelNum);
        StartCoroutine(coroutine);
    }

    private IEnumerator LaunchLevel(int levelNum)
    {
        fader.transform.GetChild(0).GetComponent<Fader>().StartTransition(levelNum,2f);
        yield return null;
    }

    //-------------------------------------------------
    //For Button Select Levels :
    public void SelectLevels()
    {
        levelSelectCont.gameObject.SetActive(true);
        GameObject.Find("MainMenuContainer").SetActive(false);
    }

    //-------------------------------------------------
    //For the return button :
    public void ReturnMainMenu()
    {
        mainContainer.gameObject.SetActive(true);
        GameObject.Find("SelectLevelContainer").SetActive(false);
    }

    //-------------------------------------------------
    //For the quit button:
    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
