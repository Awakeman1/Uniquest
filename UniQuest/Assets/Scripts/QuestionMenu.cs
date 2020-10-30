using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using UnityEditor;

public class QuestionMenu : MonoBehaviour
{
    public static GameObject mmCanvas, txtCurrentLetter, rmquestionitem;
    public static string CurrentLetter, conn, Question, Answera, Answerb, Answerc, correctanswer, questiontype;
    public static IDbConnection dbconn;
    public static int numberofqns;
    

    public void Start()
    {
        mmCanvas = GameObject.Find("Canvas");
        txtCurrentLetter = GameObject.Find("CorrectAns");
        rmquestionitem = GameObject.Find("qn");
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
        int number;

        
        txtCurrentLetter = GameObject.Find("CorrectAns");
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
        
        if(int.TryParse(Question, out number) || int.TryParse(Answera, out number) || int.TryParse(Answerb, out number) || int.TryParse(Answerc, out number)){
            Debug.Log("Found int instead of String. Please fix.");
            if(EditorUtility.DisplayDialog("Fail!",  "A number was detected. Please change it like the following: Replace '1' with 'one'",  "Ok"))
                print("Pressed Yes.");
        }
        else{
            if(Answerc == ""){
                try{
                        string sqlQuery = "INSERT INTO questions ('Qn_Question', 'Qn_Answer_A', 'Qn_Answer_B', 'Qn_Answer_C', 'Qn_CorrectAnswer', 'Qn_Type') VALUES ('"+ Question + "', '"+ Answera + "', '" + Answerb + "', '" + Answerc + "', '" + correctanswer + "', 'yn')";
                        
                        dbcmd.CommandText = sqlQuery;
                        IDataReader reader = dbcmd.ExecuteReader();
                            while (reader.Read())
                                {
                                
                                }
                            reader.Close();
                            reader = null;
                            Debug.Log("Added Successfully - I think...");
                            
                        dbcmd.Dispose();
                        dbcmd = null;
                        dbconn.Close();
                        dbconn = null;
                        {
                            
                        }

                        if(EditorUtility.DisplayDialog("Success!",  "Your question has been added to the database.",  "Ok"))
                        print("Pressed Yes.");
                        
                }
                catch(SqliteException e){
                    Debug.Log("Syntax error found: " + e);
                    if(EditorUtility.DisplayDialog("Fail!",  "There was an error adding your question. Ensure that there are no apostrophes or quotation marks.",  "Ok"))
                        print("Pressed Yes.");
                }
            }
            else{
                try{
                    string sqlQuery = "INSERT INTO questions ('Qn_Question', 'Qn_Answer_A', 'Qn_Answer_B', 'Qn_Answer_C', 'Qn_CorrectAnswer', 'Qn_Type') VALUES ('"+ Question + "', '"+ Answera + "', '" + Answerb + "', '" + Answerc + "', '" + correctanswer + "', 'mc')";
                    
                    dbcmd.CommandText = sqlQuery;
                    IDataReader reader = dbcmd.ExecuteReader();
                        while (reader.Read())
                            {
                            
                            }
                        reader.Close();
                        reader = null;
                        Debug.Log("Added Successfully - I think...");
                        
                    dbcmd.Dispose();
                    dbcmd = null;
                    dbconn.Close();
                    dbconn = null;
                    {
                        
                    }

                    if(EditorUtility.DisplayDialog("Success!",  "Your question has been added to the database.",  "Ok"))
                    print("Pressed Yes.");
                    
            }
            catch(SqliteException e){
                Debug.Log("Syntax error found: " + e);
                if(EditorUtility.DisplayDialog("Fail!",  "There was an error adding your question. Ensure that there are no apostrophes or quotation marks.",  "Ok"))
                    print("Pressed Yes.");
            }
            }
        }
        
    }

}