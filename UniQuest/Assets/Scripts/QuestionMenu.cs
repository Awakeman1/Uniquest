using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class QuestionMenu : MonoBehaviour
{
    public static GameObject mmCanvas;
    public static string CurrentLetter;

    public static string conn;
    public static string Question;
    public static string Answera;
    public static string Answerb;
    public static string Answerc;
    public static string correctanswer;
    public static IDbConnection dbconn;

    public void ToggleLetterup()
    {
        mmCanvas = GameObject.Find("Canvas");
        CurrentLetter = mmCanvas.transform.GetChild(5).GetChild(12).GetComponent<UnityEngine.UI.Text>().text;

        if(CurrentLetter == "A"){
            mmCanvas.transform.GetChild(5).GetChild(12).GetComponent<UnityEngine.UI.Text>().text = "B";
        }
        else if(CurrentLetter == "B"){
            mmCanvas.transform.GetChild(5).GetChild(12).GetComponent<UnityEngine.UI.Text>().text = "C";
        }
    }

    public void ToggleLetterdown()
    {
        mmCanvas = GameObject.Find("Canvas");
        CurrentLetter = mmCanvas.transform.GetChild(5).GetChild(12).GetComponent<UnityEngine.UI.Text>().text;

        if(CurrentLetter == "C"){
            mmCanvas.transform.GetChild(5).GetChild(12).GetComponent<UnityEngine.UI.Text>().text = "B";
        }
        else if(CurrentLetter == "B"){
            mmCanvas.transform.GetChild(5).GetChild(12).GetComponent<UnityEngine.UI.Text>().text = "A";
        }
    }

    public void AddQuestion()
    {
        mmCanvas = GameObject.Find("Canvas");
        conn = "URI=file:" + Application.dataPath + "/dbQuestions.s3db";
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        Question = mmCanvas.transform.GetChild(5).GetChild(8).GetChild(2).GetComponent<UnityEngine.UI.Text>().text;
        Answera = mmCanvas.transform.GetChild(5).GetChild(11).GetChild(2).GetComponent<UnityEngine.UI.Text>().text;
        Answerb = mmCanvas.transform.GetChild(5).GetChild(10).GetChild(2).GetComponent<UnityEngine.UI.Text>().text;
        Answerc = mmCanvas.transform.GetChild(5).GetChild(9).GetChild(2).GetComponent<UnityEngine.UI.Text>().text;
        if(CurrentLetter == "A"){
            correctanswer = Answera;
        }
        else if(CurrentLetter == "B"){
            correctanswer = Answerb;
        }
        else if(CurrentLetter == "C"){
            correctanswer = Answerc;
        }

        string sqlQuery = "INSERT INTO questions ('Qn_Question', 'Qn_Answer_A', 'Qn_Answer_B', 'Qn_Answer_C', 'Qn_CorrectAnswer') VALUES ('" + Question + "', '" + Answera + "', '" + Answerb + "', '" + Answerc + "', '" + correctanswer + "')";

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
             while (reader.Read())
                {
                    // int value = reader.GetString(0);
                    // string name = reader.GetString(1);
                    // int rand = reader.GetString(2);
        
                    // Debug.Log( "value= "+value+"  name ="+name+"  random ="+  rand);
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