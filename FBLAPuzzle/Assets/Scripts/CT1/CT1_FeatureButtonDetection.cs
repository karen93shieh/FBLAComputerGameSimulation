﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CT1_FeatureButtonDetection : MonoBehaviour
{
    CT1_LevelManager levelManager;
    Loading loading;
    public GameObject tipButton;
    public GameObject gameCanvas;
    public GameObject[] buttons;

    GameObject showScoreBoardData;
    //public string nextSceneName;
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<CT1_LevelManager>();
        loading = levelManager.LoadingCanvas.transform.GetChild(0).GetComponent<Loading>();
        tipButton.SetActive(false);
        showScoreBoardData = levelManager.CelebratoryMessagesCanvas;
        //buttons = GameObject.FindGameObjectsWithTag("Buttons");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activateTips() {
        Debug.Log("Tips"); 
        levelManager.TipsCanvas.SetActive(true);
    }
    
    public void executeExistButton(GameObject existObj)
    {
        Debug.Log("Exist");
        existObj.SetActive(false);

    }


    public void selectAnswer(GameObject answerButton) {
        if (answerButton.GetComponent<CT1_ButtonRightOrWrong>().RightOrWrong == "wrong")
        {
            Debug.Log("selectAnswer wrong");
            answerButton.GetComponent<Image>().color = new Vector4(1,0.39f,0.39f,1);
            answerButton.GetComponent<Button>().interactable = false;
            levelManager.minusHeart();
        }
        else {
            Debug.Log("selectAnswer right");
            //levelManager.hideCanvas(levelManager.QuestionCanvas);
            answerButton.GetComponent<Image>().color = new Vector4(0.39f, 1, 0.39f, 1);
            StartCoroutine(buffer());

            //Time.timeScale = 1;
        }
    }
    public void lastStep()
    {
        gameCanvas.GetComponent<CT1_PiecePosition>().whenHitBackButton();
    }
    public void resetBoard()
    {
        gameCanvas.GetComponent<CT1_PiecePosition>().whenHitResetButton();
    }

    public void goMap() {
        //Time.timeScale = 1;
        showScoreBoardData.SetActive(false);
        levelManager.LoadingCanvas.SetActive(true);
        loading.runLoading("Map");
    }
    public void nextScene(string nextSceneName) {
        //Time.timeScale = 1;
        showScoreBoardData.SetActive(false);
        levelManager.LoadingCanvas.SetActive(true);
        loading.runLoading(nextSceneName);
        
    }

    IEnumerator buffer() {
        Debug.Log("Buffer");
        levelManager.QuestionCanvas.transform.GetChild(1).gameObject.GetComponent<Button>().interactable = false;
        levelManager.QuestionCanvas.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = false;
        levelManager.QuestionCanvas.transform.GetChild(3).gameObject.GetComponent<Button>().interactable = false;
        levelManager.QuestionCanvas.transform.GetChild(4).gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(.5f);
        levelManager.QuestionCanvas.transform.GetChild(1).gameObject.GetComponent<Button>().interactable = true;
        levelManager.QuestionCanvas.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = true;
        levelManager.QuestionCanvas.transform.GetChild(3).gameObject.GetComponent<Button>().interactable = true;
        levelManager.QuestionCanvas.transform.GetChild(4).gameObject.GetComponent<Button>().interactable = true;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
            Debug.Log("button interactable");
        }
        gameObject.GetComponent<CT1_LevelManager>().currentQuestionBox.GetComponent<CT1_BoxController>().answerCorrect();
        levelManager.QuestionCanvas.SetActive(false);
        GameObject.Find("Player").GetComponent<CT1_PlayerController>().enabled = true;
    }
    //Also add this part --------------------------------------------------------

    public void quitProgram()
    {
        Debug.Log("clicked");
        Application.Quit();
    }

    public void resumeGame()
    {
        levelManager.PauseMenuCanvas.SetActive(false);
        GameObject.Find("AudioPlayer").GetComponent<PlayAudio>().changeVolume(1f);
        GameObject.Find("Player").GetComponent<CT1_PlayerController>().enabled = true;
        GameObject.Find("PointsValue").GetComponent<CT1_PointsCalculation>().gamePause = false;
        StartCoroutine(GameObject.Find("PointsValue").GetComponent<CT1_PointsCalculation>().pointsCountDown());
        //Time.timeScale = 1;
    }
    public void switchToMainMenu()
    {
        showScoreBoardData.SetActive(false);
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            levelManager.LoadingCanvas.SetActive(true);
            levelManager.PauseMenuCanvas.SetActive(false);
            levelManager.LoadingCanvas.transform.GetChild(0).gameObject.GetComponent<Loading>().runLoading("MainMenu");
        }
        else
        {
            levelManager.PauseMenuCanvas.SetActive(false);
        }
    }
    public void switchToMap()
    {
        showScoreBoardData.SetActive(false);
        if (SceneManager.GetActiveScene().name != "Map")
        {
            levelManager.LoadingCanvas.SetActive(true);
            levelManager.PauseMenuCanvas.SetActive(false);
            levelManager.LoadingCanvas.transform.GetChild(0).gameObject.GetComponent<Loading>().runLoading("Map");
        }
        else
        {
            levelManager.PauseMenuCanvas.SetActive(false);
        }
    }
}