using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEditor;

public class RemoveQn : MonoBehaviour
{

    public static IDbConnection dbconn;
    public static string conn;

    void Start()
    {
        
        
    }

    public void remove(GameObject sender)
    {

        try{

                conn = "URI=file:" + Application.dataPath + "/dbQuestions.s3db";
                dbconn = (IDbConnection) new SqliteConnection(conn);
                dbconn.Open();
                IDbCommand dbcmd = dbconn.CreateCommand();

                string sqlQuery = "DELETE FROM questions WHERE Qn_Question = '" + sender.GetComponent<UnityEngine.UI.Text>().text + "';";

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
                    if(EditorUtility.DisplayDialog("Success!",  "Your question has been removed.",  "Ok"))
                    print("Pressed Yes.");
            
        }
        catch(SqliteException e){
            Debug.Log("Syntax error found: " + e);
            if(EditorUtility.DisplayDialog("Fail!",  "There was an error removing your question.",  "Ok"))
                    print("Pressed Yes.");
        }

       
        
    }
}
