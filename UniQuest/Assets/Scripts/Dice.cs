using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;

public class Dice : MonoBehaviour {

    private Sprite ds1, ds2, ds3, ds4, ds5, ds6;
    public List<Sprite> DiceSides = new List<Sprite>();
    public static int numberofquestions;
    public static int QuestionID;
    
    public static string conn;
    public static IDbConnection dbconn;


    private bool coroutineAllowed = true;

    public void Start()
    {
        conn = "URI=file:" + Application.dataPath + "/dbQuestions.s3db";
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open();
        
        string getnumqns = "SELECT COUNT(*) FROM questions;";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = getnumqns;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            numberofquestions = reader.GetInt32(0);
        }

        Debug.Log("number of qns: " + numberofquestions);
        ds1 = Resources.Load<Sprite>("DiceSides/s1");
        ds2 = Resources.Load<Sprite>("DiceSides/s2");
        ds3 = Resources.Load<Sprite>("DiceSides/s3");
        ds4 = Resources.Load<Sprite>("DiceSides/s4");
        ds5 = Resources.Load<Sprite>("DiceSides/s5");
        ds6 = Resources.Load<Sprite>("DiceSides/s6");
        DiceSides.Add(ds1);
        DiceSides.Add(ds2);
        DiceSides.Add(ds3);
        DiceSides.Add(ds4);
        DiceSides.Add(ds5);
        DiceSides.Add(ds6);
    }

    public void OnMouseDown()
    {
        
        if (coroutineAllowed){
            StartCoroutine("RollTheDice");
        }
    }

    private IEnumerator RollTheDice()
    {
       if(GameControl.WhosTurn != 0)
       {
            coroutineAllowed = false;
            int randomDiceSide = 0;
            for (int i = 0; i <= 20; i++)
            {
                randomDiceSide = Random.Range(0, 6);
                GameObject.Find("DiceButton").gameObject.GetComponent<Image>().sprite = DiceSides[randomDiceSide];     
                yield return new WaitForSeconds(0.02f);
            }
            GameControl.diceSideThrown = randomDiceSide + 1;
            if(GameControl.WhosTurn > MainMenu.NumPlayers){
                GameControl.WhosTurn = 1;
            }
            Debug.Log(GameControl.WhosTurn);
            QuestionID = Random.Range(1, numberofquestions);
            yield return new WaitForSeconds(1);
            GameControl.AskQuestion();
            coroutineAllowed = true;
       }
       else{
           Debug.Log("Game Is Over. Cannot Roll");
       }
       
        
    }
}
