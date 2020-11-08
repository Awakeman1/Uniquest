using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
// using UnityEditor;
using UnityEngine.SceneManagement;

public class RemoveQn : MonoBehaviour
{

    public static IDbConnection dbconn;
    public  GameObject content, errsucc;
    public static string conn, questiontopurge="";

    void Start()
    {
        content = GameObject.Find("Content");
        errsucc = GameObject.Find("errsucc");
        errsucc.gameObject.SetActive(false);
    }

    
     public void ReloadLevel(){
              SceneManager.LoadScene(SceneManager.GetActiveScene().name);
              
     }


    public void purge(){
        if(questiontopurge == null){
            CallErr.Error4("Err04: Please select an item to remove. Please see User & Installation Manual for help.");
        }
        else if(questiontopurge != ""){
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
                        
                        ReloadLevel();
                        
                
            }
            catch(SqliteException e){
                Debug.Log("Syntax error found: " + e);
                errsucc.GetComponent<UnityEngine.UI.Text>().text = "Err03 - There was an unknown error. Please see User Guide for more information.";
                errsucc.gameObject.SetActive(true);
                CallErr.Error3("Err03: There was an issue removing the question. Please see User & Installation Manual for help.");
                // if(EditorUtility.DisplayDialog("Fail!",  "There was an error removing your question.",  "Ok"))
                //         print("Pressed Yes.");
            }

        }
        else{
            // errsucc.GetComponent<UnityEngine.UI.Text>().text = "Err04 - No item selected. Please see User Guide for more information.";
            // errsucc.gameObject.SetActive(true);
            CallErr.Error4("Err04: Please select an item to remove. Please see User & Installation Manual for help.");
            // if(EditorUtility.DisplayDialog("Fail!",  "Please select an item to remove.",  "Ok"))
            //             print("Pressed Yes.");
        }
    }


    public void remove(GameObject sender)
    {
        Debug.Log("There are " + content.transform.childCount + " kiddies");        
        for(int a = 1; a < content.transform.childCount; a++) {
                    
                    Transform child = content.transform.GetChild(a);
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
                CallErr.Error3("Err03: There was an issue removing the question. Please see User & Installation Manual for help.");
                // if(EditorUtility.DisplayDialog("Fail!",  "There was an error removing your question.",  "Ok"))
                //         print("Pressed Yes.");
            }

        }
        else{
          CallErr.Error4("Err04: Please select an item to remove. Please see User & Installation Manual for help.");
            // if(EditorUtility.DisplayDialog("Fail!",  "Please select an item to remove.",  "Ok"))
            //             print("Pressed Yes.");
        }
    }
}
