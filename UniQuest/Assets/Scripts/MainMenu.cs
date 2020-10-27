using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class MainMenu : MonoBehaviour
{
    public static GameObject mmCanvas;
    public static int NumPlayers = 2;

    public GameObject mmBackgroundImg, mmBackgroundBlank;
    public GameObject menuMain, menuNewGame, menuOptions, menuAddQuestion, menuRmQuestion;
    public GameObject txtNumPlayers;

    public static IDbConnection dbconn, dbconn2;
    public static string conn, tempqn;
    public static int numberofqns;
    public GameObject rmquestionitem, Content;

    public void Start()
    {
        Debug.Log("Start " + GetInstanceID(), this);
        rmquestionitem = GameObject.Find("qn");
        Content = GameObject.Find("Content");

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
        string question = "test";
        

        ClearScreen();
        mmBackgroundBlank.gameObject.SetActive(true);
        menuRmQuestion.gameObject.SetActive(true);


        conn = "URI=file:" + Application.dataPath + "/dbQuestions.s3db";
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        string getnumqns = "SELECT COUNT(*) FROM questions;";
        
        dbcmd.CommandText = getnumqns;
                IDataReader reader = dbcmd.ExecuteReader();
                    while (reader.Read())
                        {
                            numberofqns = reader.GetInt32(0);
                        }
                    reader.Close();
                    reader = null;
                    
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
                {
                    
                }

        


        for(int i = 1; i < numberofqns; i++){
            string getqn = "SELECT Qn_Question FROM questions WHERE ROWID = '" + i + "';";
            dbconn2 = (IDbConnection) new SqliteConnection(conn);
            dbconn2.Open();
            IDbCommand dbcmd2 = dbconn2.CreateCommand();
            dbcmd2.CommandText = getqn;
                 IDataReader reader2 = dbcmd2.ExecuteReader();
                    while (reader2.Read())
                        {
                            tempqn = reader2.GetString(0);
                        }
                    reader2.Close();
                    reader2 = null;
                    
                dbcmd2.Dispose();
                dbcmd2 = null;
                dbconn2.Close();
                dbconn2 = null;
                {
                    
                }




            GameObject a = Instantiate(rmquestionitem, new Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity);
            a.transform.SetParent(Content.gameObject.transform, false);
            a.gameObject.GetComponent<UnityEngine.UI.Text>().text = tempqn;
        }
        rmquestionitem.gameObject.SetActive(false);



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
