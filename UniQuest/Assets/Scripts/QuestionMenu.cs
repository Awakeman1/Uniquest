using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class QuestionMenu : MonoBehaviour
{
    public static GameObject mmCanvas, txtCurrentLetter;
    public static string CurrentLetter;

    public static string conn;
    public static string Question;
    public static string Answera;
    public static string Answerb;
    public static string Answerc;
    public static string correctanswer;
    public static IDbConnection dbconn;

    public void Start()
    {
        mmCanvas = GameObject.Find("Canvas");
        txtCurrentLetter = GameObject.Find("CorrectAns");
    }


    public void ToggleLetterup()
    {
        txtCurrentLetter = GameObject.Find("CorrectAns");
        
        if(txtCurrentLetter.gameObject.GetComponent<UnityEngine.UI.Text>().text == "A"){
            txtCurrentLetter.gameObject.GetComponent<UnityEngine.UI.Text>().text = "B";
        }
        else if(txtCurrentLetter.gameObject.GetComponent<UnityEngine.UI.Text>().text == "B"){
            txtCurrentLetter.gameObject.GetComponent<UnityEngine.UI.Text>().text = "C";
        }
    }

    public void ToggleLetterdown()
    {
        txtCurrentLetter = GameObject.Find("CorrectAns");
        
        if(txtCurrentLetter.gameObject.GetComponent<UnityEngine.UI.Text>().text == "C"){
            txtCurrentLetter.gameObject.GetComponent<UnityEngine.UI.Text>().text = "B";
        }
        else if(txtCurrentLetter.gameObject.GetComponent<UnityEngine.UI.Text>().text == "B"){
            txtCurrentLetter.gameObject.GetComponent<UnityEngine.UI.Text>().text = "A";
        }
    }

    public void AddQuestion()
    {
        CurrentLetter = txtCurrentLetter.GetComponent<UnityEngine.UI.Text>().text;

        conn = "URI=file:" + Application.dataPath + "/dbQuestions.s3db";
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        Question = GameObject.Find("QuestionText").GetComponent<UnityEngine.UI.Text>().text;
        Answera = GameObject.Find("OptionAText").GetComponent<UnityEngine.UI.Text>().text;
        Answerb = GameObject.Find("OptionBText").GetComponent<UnityEngine.UI.Text>().text;
        Answerc = GameObject.Find("OptionCText").GetComponent<UnityEngine.UI.Text>().text;

        if (CurrentLetter == "A"){
            correctanswer = Answera;
        }
        else if(CurrentLetter == "B"){
            correctanswer = Answerb;
        }
        else if(CurrentLetter == "C"){
            correctanswer = Answerc;
        }

        string sqlQuery = 
            "INSERT INTO questions ('Qn_Question', 'Qn_Answer_A', 'Qn_Answer_B', 'Qn_Answer_C', 'Qn_CorrectAnswer') " +
            "VALUES ('" + Question + "', '" + Answera + "', '" + Answerb + "', '" + Answerc + "', '" + correctanswer + "')";
        
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
             while (reader.Read())
                {
                   
                }
            reader.Close();
            reader = null;
            
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        {
            
        }
    }



}