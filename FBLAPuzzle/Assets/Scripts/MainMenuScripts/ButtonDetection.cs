﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonDetection : MonoBehaviour
{
    //sceneManager sceneManager;
    MainMenuManager mainMenuManager;
    /*public GameObject PlayButton;
    public GameObject InstructionButton;
    public GameObject LeaderBoardButton;
    public GameObject ExistButton;*/
    public GameObject NextPageButton;
    public GameObject LastPageButton;

    public ScrollRect ScrollRect;
    int pageCounter = 0;
    //public GameObject PlayButton;
    //public GameObject PlayButton;
    //public GameObject PlayButton;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuManager = GameObject.Find("SceneManager").GetComponent<MainMenuManager>();
        /*PlayButton.GetComponent<Button>().onClick.AddListener(executePlayButton);
        InstructionButton.GetComponent<Button>().onClick.AddListener(executeInstructionButton);
        LeaderBoardButton.GetComponent<Button>().onClick.AddListener(executeLeaderBoardButton);
        ExistButton.GetComponent<Button>().onClick.AddListener(executeExistButton);
        NextPageButton.GetComponent<Button>().onClick.AddListener(executeNextPageButton);
        LastPageButton.GetComponent<Button>().onClick.AddListener(executeLastPageButton);*/
        ScrollRect.verticalNormalizedPosition = 1f;
        if (pageCounter <= 0) {
            LastPageButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void executePlayButton() {
        Debug.Log("Play");
        mainMenuManager.LoadingCanvas.SetActive(true);
        //sceneManager.LoadingCanvas.GetComponent<"LoadingBackground">.GetComponent<Loading>().runLoading("Map");
        mainMenuManager.LoadingCanvas.transform.GetChild(0).gameObject.GetComponent<Loading>().runLoading("Map");
        //SceneManager.LoadScene();
    }
    public void executeInstructionButton() {
        Debug.Log("Instruction");
        pageCounter = 0;
        LastPageButton.SetActive(false);
        mainMenuManager.changeInstrucitonPage(pageCounter);
        mainMenuManager.InstructionCanvas.SetActive(true);

    }
    public void executeLeaderBoardButton() {
        Debug.Log("Leader Board");
        ScrollRect.verticalNormalizedPosition = 1f;
        mainMenuManager.LeaderBoardCanvas.SetActive(true);


    }
    public void executeExistButton(GameObject existObj)
    {
        Debug.Log("Exist");
        existObj.SetActive(false);

    }
    public void executeNextPageButton()
    {
        pageCounter++;
        Debug.Log("page Counter" + pageCounter + " instructionpages " + mainMenuManager.InstructionPages.Length);
        if (pageCounter > 0)
        {
            LastPageButton.SetActive(true);
        }
        if (pageCounter== (mainMenuManager.InstructionPages.Length-1)) {
            NextPageButton.SetActive(false);
        }
        mainMenuManager.changeInstrucitonPage(pageCounter);
        Debug.Log("Next");

    }
    public void executeLastPageButton()
    {
        pageCounter--;
        if (pageCounter <= 0)
        {
            LastPageButton.SetActive(false);
        }
        if (pageCounter < mainMenuManager.InstructionPages.Length-1)
        {
            NextPageButton.SetActive(true);
        }
        mainMenuManager.changeInstrucitonPage(pageCounter);

        Debug.Log("Last");

    }
    public void quitProgram()
    {
        Debug.Log("clicked");
        Application.Quit();
    }

    public void resumeGame() {
        mainMenuManager.PauseMenuCanvas.SetActive(false);
    }
}