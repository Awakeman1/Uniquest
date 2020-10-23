using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// using Mono.Data.Sqlite;

public class MainMenu : MonoBehaviour
{
    public static GameObject mmCanvas;
    public static int NumPlayers = 2;



    public void Start()
    {
        mmCanvas = GameObject.Find("Canvas");
        //Debug.Log("Start");
        Debug.Log("Start " + GetInstanceID(), this);
        mmCanvas.transform.GetChild(0).gameObject.SetActive(true);
        mmCanvas.transform.GetChild(1).gameObject.SetActive(false);

        mmCanvas.transform.GetChild(2).gameObject.SetActive(true);
        mmCanvas.transform.GetChild(3).gameObject.SetActive(false); 
        mmCanvas.transform.GetChild(4).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(5).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(6).gameObject.SetActive(false);
    }
       
  public void OptionMenu()
    {
        Debug.Log("Options");
        mmCanvas.transform.GetChild(0).gameObject.SetActive(true);
        mmCanvas.transform.GetChild(1).gameObject.SetActive(false);

        mmCanvas.transform.GetChild(2).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(3).gameObject.SetActive(false); 
        mmCanvas.transform.GetChild(4).gameObject.SetActive(true);
        mmCanvas.transform.GetChild(5).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(6).gameObject.SetActive(false);
    }



    public void NewGame ()
    {
        Debug.Log("Newgame");
        mmCanvas.transform.GetChild(0).gameObject.SetActive(true);
        mmCanvas.transform.GetChild(1).gameObject.SetActive(false);

        mmCanvas.transform.GetChild(2).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(3).gameObject.SetActive(true); 
        mmCanvas.transform.GetChild(4).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(5).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(6).gameObject.SetActive(false);;  
    }

    public void playercountplus()
    {
        if(NumPlayers < 10){
            NumPlayers++;
            mmCanvas.transform.GetChild(3).GetChild(5).gameObject.GetComponent<UnityEngine.UI.Text>().text = NumPlayers.ToString();
        }
    }

    public void playercountminus()
    {
        if(NumPlayers > 2){
            NumPlayers--;
            mmCanvas.transform.GetChild(3).GetChild(5).gameObject.GetComponent<UnityEngine.UI.Text>().text = NumPlayers.ToString();
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
        mmCanvas.transform.GetChild(0).gameObject.SetActive(true);
        mmCanvas.transform.GetChild(1).gameObject.SetActive(false);

        mmCanvas.transform.GetChild(2).gameObject.SetActive(true);
        mmCanvas.transform.GetChild(3).gameObject.SetActive(false); 
        mmCanvas.transform.GetChild(4).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(5).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(6).gameObject.SetActive(false);
    }

    public void AddQuestion()
    {
        Debug.Log("Add Qn");
        mmCanvas.transform.GetChild(0).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(1).gameObject.SetActive(true);

        mmCanvas.transform.GetChild(2).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(3).gameObject.SetActive(false); 
        mmCanvas.transform.GetChild(4).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(5).gameObject.SetActive(true);
        mmCanvas.transform.GetChild(6).gameObject.SetActive(false);
    }

    public void RMQuestion()
    {
        Debug.Log("Rm Question");
        mmCanvas.transform.GetChild(0).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(1).gameObject.SetActive(true);

        mmCanvas.transform.GetChild(2).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(3).gameObject.SetActive(false); 
        mmCanvas.transform.GetChild(4).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(5).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(6).gameObject.SetActive(true);
    }


}
