using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button StartButton;
    public Button SelectLevelButton;
    public Button ReturnButton;
    public Button QuitButton;



    public GameObject mainMenuContainer;
    public GameObject levelSelectContainer;
    [SerializeField] Fader fader;
    [SerializeField] float time;


    private void Start()
    {
        StartButton.onClick.AddListener(StartGame);
        SelectLevelButton.onClick.AddListener(SelectLevel);
        ReturnButton.onClick.AddListener(Return);
        QuitButton.onClick.AddListener(Quit);
        mainMenuContainer = GameObject.Find("MainMenuContainer") as GameObject;
        levelSelectContainer = GameObject.Find("SelectLevelContainer") as GameObject;
        //gameMenuContainer = GameObject.Find("ModeCamera").gameObject;
        mainMenuContainer.SetActive(true);
        levelSelectContainer.SetActive(false);


    }
    //faites comme si vous n'aviez rien vu, je vais corriger ça
    private void StartLevel1()
    {
        SceneManager.LoadScene(1);
    }
    private void StartLevel2()
    {
        SceneManager.LoadScene(2);
    }
    private void StartLevel3()
    {
        SceneManager.LoadScene(3);
    }
    private void StartGame()
    {
        //print("puteuh");
        //SceneManager.LoadScene(1);
        fader.StartTransition(1, time);

    }

    private void SelectLevel()
    {
        levelSelectContainer.SetActive(true);
        mainMenuContainer.SetActive(false);
    }

    private void Return()
    {
        mainMenuContainer.SetActive(true);
        levelSelectContainer.SetActive(false);
    }

    void Quit()
    {
        Application.Quit();
    }



}
