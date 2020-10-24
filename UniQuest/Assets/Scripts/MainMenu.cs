using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static GameObject mmCanvas;
    public static int NumPlayers = 2;

    private GameObject mmBackgroundImg, mmBackgroundBlank;
    private GameObject menuMain, menuNewGame, menuOptions, menuAddQuestion, menuRmQuestion;
    private GameObject txtNumPlayers;


    public void Start()
    {
        Debug.Log("Start " + GetInstanceID(), this);

        mmCanvas = GameObject.Find("Canvas");
        mmBackgroundImg = GameObject.Find("Background");
        mmBackgroundBlank = GameObject.Find("Background_Nopic");

        menuMain = GameObject.Find("MainMenu");
        menuNewGame = GameObject.Find("NGMenu");
        menuOptions = GameObject.Find("OptionsMenu");
        menuAddQuestion = GameObject.Find("AddQuestionMenu");
        menuRmQuestion = GameObject.Find("RmQuestionMenu");

        txtNumPlayers = GameObject.Find("txt_playernum");

        ClearScreen();
        mmBackgroundImg.gameObject.SetActive(true);
        menuMain.gameObject.SetActive(true);
    }
       
  public void OptionMenu()
    {
        Debug.Log("Options");

        ClearScreen();
        mmBackgroundImg.gameObject.SetActive(true);
        menuOptions.gameObject.SetActive(true);
    }



    public void NewGame ()
    {
        Debug.Log("Newgame");

        ClearScreen();
        mmBackgroundImg.gameObject.SetActive(true);
        menuNewGame.gameObject.SetActive(true);
    }

    public void playercountplus()
    {
        if(NumPlayers < 10){
            NumPlayers++;
            txtNumPlayers.gameObject.GetComponent<UnityEngine.UI.Text>().text = NumPlayers.ToString();
        }
    }

    public void playercountminus()
    {
        if(NumPlayers > 2){
            NumPlayers--;
            txtNumPlayers.gameObject.GetComponent<UnityEngine.UI.Text>().text = NumPlayers.ToString();
        }
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }

  
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back()
    {
        Debug.Log("Back");
        ClearScreen();
        mmBackgroundImg.gameObject.SetActive(true);
        menuMain.gameObject.SetActive(true);
    }

    public void AddQuestion()
    {
        Debug.Log("Add Qn");

        ClearScreen();
        mmBackgroundBlank.gameObject.SetActive(true);
        menuAddQuestion.gameObject.SetActive(true);
    }

    public void RMQuestion()
    {
        Debug.Log("Rm Question");

        ClearScreen();
        mmBackgroundBlank.gameObject.SetActive(true);
        menuRmQuestion.gameObject.SetActive(true);

    }

    private void ClearScreen()
    {
        mmBackgroundImg.gameObject.SetActive(false);
        mmBackgroundBlank.gameObject.SetActive(false);
        menuMain.gameObject.SetActive(false);
        menuNewGame.gameObject.SetActive(false);
        menuOptions.gameObject.SetActive(false);
        menuAddQuestion.gameObject.SetActive(false);
        menuRmQuestion.gameObject.SetActive(false);
    }


}
