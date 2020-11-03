﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEditor;
using UnityEngine.SceneManagement;

public class RemoveQn : MonoBehaviour
{

    public static IDbConnection dbconn;
    public  GameObject content;
    public static string conn, questiontopurge="";

    void Start()
    {
        content = GameObject.Find("Content");
        
    }

    
     public void ReloadLevel(){
              SceneManager.LoadScene(SceneManager.GetActiveScene().name);
              
     }


    public void purge(){
        if(questiontopurge != ""){
            try{

                    conn = "URI=file:" + Application.dataPath + "/dbQuestions.s3db";
                    dbconn = (IDbConnection) new SqliteConnection(conn);
                    dbconn.Open();
                    IDbCommand dbcmd = dbconn.CreateCommand();

                    string sqlQuery = "DELETE FROM questions WHERE Qn_Question = '" + questiontopurge + "'; delete from sqlite_sequence where name ='questions' ";

                    dbcmd.CommandText = sqlQuery;
                                IDataReader reader = dbcmd.ExecuteReader();
                                    while (reader.Read())
                                        {
                                        
                                        }
                                    reader.Close();
                                    reader = null;
                                    Debug.Log("Should have been removed.");
                                    
                                dbcmd.Dispose();
                                dbcmd = null;
                                dbconn.Close();
                                dbconn = null;
                                {
                                    
                                }
                        if(EditorUtility.DisplayDialog("Success!",  "Your question has been removed. You will now return to the main menu.",  "Ok"))
                        print("Pressed Yes.");
                        ReloadLevel();
                        
                
            }
            catch(SqliteException e){
                Debug.Log("Syntax error found: " + e);
                if(EditorUtility.DisplayDialog("Fail!",  "There was an error removing your question.",  "Ok"))
                        print("Pressed Yes.");
            }

        }
        else{
            if(EditorUtility.DisplayDialog("Fail!",  "Please select an item to remove.",  "Ok"))
                        print("Pressed Yes.");
        }
    }


    public void remove(GameObject sender)
    {
        Debug.Log("There are " + content.transform.childCount + " kiddies");        
        for(int a = 1; a < content.transform.childCount; a++) { //Loops through every child of object
                    
                    Transform child = content.transform.GetChild(a); //Gets the current child
                    child.GetComponent<UnityEngine.UI.Text>().color = Color.black;
        }




        questiontopurge = sender.GetComponent<UnityEngine.UI.Text>().text;
        sender.GetComponent<UnityEngine.UI.Text>().color = Color.blue;
        Debug.Log("Select to remove: " + questiontopurge);

    
    }

    public static void reindex(){
        if(questiontopurge != ""){
            try{

                    conn = "URI=file:" + Application.dataPath + "/dbQuestions.s3db";
                    dbconn = (IDbConnection) new SqliteConnection(conn);
                    dbconn.Open();
                    IDbCommand dbcmd = dbconn.CreateCommand();

                    string sqlQuery = "REINDEX 'questions'; REINDEX 'sqlite_sequence';";

                    dbcmd.CommandText = sqlQuery;
                                IDataReader reader = dbcmd.ExecuteReader();
                                    while (reader.Read())
                                        {
                                        
                                        }
                                    reader.Close();
                                    reader = null;
                                    Debug.Log("Should have been reindexed.");
                                    
                                dbcmd.Dispose();
                                dbcmd = null;
                                dbconn.Close();
                                dbconn = null;
                                {
                                    
                                }
                        
                        
                
            }
            catch(SqliteException e){
                Debug.Log("Syntax error found: " + e);
                if(EditorUtility.DisplayDialog("Fail!",  "There was an error removing your question.",  "Ok"))
                        print("Pressed Yes.");
            }

        }
        else{
            if(EditorUtility.DisplayDialog("Fail!",  "Please select an item to remove.",  "Ok"))
                        print("Pressed Yes.");
        }
    }
}
