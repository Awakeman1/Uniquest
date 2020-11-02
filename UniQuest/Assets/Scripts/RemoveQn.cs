using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEditor;
using UnityEngine.SceneManagement;

public class RemoveQn : MonoBehaviour
{

    public static IDbConnection dbconn;
    public static string conn, questiontopurge="";

    void Start()
    {
        
        
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

                    string sqlQuery = "DELETE FROM questions WHERE Qn_Question = '" + questiontopurge + "';";

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
        questiontopurge = sender.GetComponent<UnityEngine.UI.Text>().text;
        Debug.Log("Select to remove: " + questiontopurge);

    }
}
