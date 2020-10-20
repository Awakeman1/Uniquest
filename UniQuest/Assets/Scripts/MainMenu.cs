using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static GameObject mmCanvas;
    public static int NumPlayers = 2;


    public void Start()
    {
        mmCanvas = GameObject.Find("Canvas");
        Debug.Log("Start");
        mmCanvas.transform.GetChild(1).gameObject.SetActive(true);
        mmCanvas.transform.GetChild(2).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(3).gameObject.SetActive(false); 
    }
       
  public void OptionMenu()
    {
        Debug.Log("Options");
        mmCanvas.transform.GetChild(1).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(2).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(3).gameObject.SetActive(true);
    }



    public void NewGame ()
    {
        Debug.Log("Newgame");
        mmCanvas.transform.GetChild(1).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(2).gameObject.SetActive(true);
        mmCanvas.transform.GetChild(3).gameObject.SetActive(false);      
    }

    public void playercountplus()
    {
        if(NumPlayers < 10){
            NumPlayers++;
            mmCanvas.transform.GetChild(2).GetChild(5).gameObject.GetComponent<UnityEngine.UI.Text>().text = NumPlayers.ToString();
        }
    }

    public void playercountminus()
    {
        if(NumPlayers > 2){
            NumPlayers--;
            mmCanvas.transform.GetChild(2).GetChild(5).gameObject.GetComponent<UnityEngine.UI.Text>().text = NumPlayers.ToString();
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
        mmCanvas.transform.GetChild(1).gameObject.SetActive(true);
        mmCanvas.transform.GetChild(2).gameObject.SetActive(false);
        mmCanvas.transform.GetChild(3).gameObject.SetActive(false);
        
    }


}
