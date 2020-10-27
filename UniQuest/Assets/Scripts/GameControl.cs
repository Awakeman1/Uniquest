using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections; 
using System.Collections.Generic;
using System.IO;
using System.Data;
using Mono.Data.Sqlite;
using TMPro;


public class GameControl : MonoBehaviour {

    private static GameObject Player1, Player2, Player3, Player4, Player5, Player6, Player7, Player8, Player9, Player10;
    private static ArrayList players;
    private static GameObject activePlayer;
    private static Dictionary<GameObject, int> playerPositions;

    public int NumberofPlayers;
    private static GameObject Mcamera;
    public static int diceSideThrown = 0;   
    public static int WhosTurn = 1;

    public static GameObject mainUI, diceUI, GameOverUI, QuestionUI, Wrong, Right;

    public static TextMeshProUGUI QuestionText, ans1Text,ans2Text, ans3Text;

    public static bool QuestionCorrect = false, gamePaused = false; 
    public static String Question_Question;
    public static String Question_Answer1;
    public static String Question_Answer2;
    public static String Question_Answer3;
    public static String Question_Correct;

    public static string conn;
    public static IDbConnection dbconn;


    public void Start()
    {
        conn = "URI=file:" + Application.dataPath + "/dbQuestions.s3db";
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand getqn = dbconn.CreateCommand();
        
        
        mainUI = GameObject.Find("Canvas");
        diceUI = GameObject.Find("DiceButton");
        GameOverUI = GameObject.Find("GameOverPanel");
        QuestionUI = GameObject.Find("QuestionPanel");
        Wrong = GameObject.Find("Wrong");
        Right = GameObject.Find("Right");

        QuestionText = GameObject.Find("QuestionText").GetComponent<TextMeshProUGUI>();
        ans1Text = GameObject.Find("OptionAText").GetComponent<TextMeshProUGUI>();
        ans2Text = GameObject.Find("OptionBText").GetComponent<TextMeshProUGUI>();
        ans3Text = GameObject.Find("OptionCText").GetComponent<TextMeshProUGUI>();

        GameOverUI.SetActive(false);
        QuestionUI.SetActive(false);
        Wrong.SetActive(false);
        Right.SetActive(false);

        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        Player3 = GameObject.Find("Player3");
        Player4 = GameObject.Find("Player4");
        Player5 = GameObject.Find("Player5");
        Player6 = GameObject.Find("Player6");
        Player7 = GameObject.Find("Player7");
        Player8 = GameObject.Find("Player8");
        Player9 = GameObject.Find("Player9");
        Player10 = GameObject.Find("Player10");

        players = new ArrayList()
        {Player1, Player2, Player3, Player4, Player5, Player6, Player7, Player8, Player9, Player10};

        NumberofPlayers = MainMenu.NumPlayers;
        for(int i = 10; i > NumberofPlayers; i--)
        {
            GameObject player = (GameObject) players[i-1];
            player.SetActive(false);
            players.Remove(player);
        }

        playerPositions = new Dictionary<GameObject, int>();

        foreach (GameObject player in players)
        {
            playerPositions.Add(player, 0);
            try
            {
                player.GetComponent<AudioListener>().enabled = false;
            }
            catch
            {
                Debug.Log(player + " has no audio listener");
            }
        }

        Mcamera = GameObject.Find("MainCamera");
        Mcamera.SetActive(true);
        Mcamera.GetComponent<AudioListener>().enabled = false;
        
    }

    void Update()
    {
        if (!gamePaused)
        {
            activePlayer = (GameObject)players[WhosTurn - 1];
            if (activePlayer.GetComponent<FollowThePath>().moveAllowed == true)
            {
                if (activePlayer.GetComponent<FollowThePath>().waypointIndex > playerPositions[activePlayer] + diceSideThrown)
                {
                    activePlayer.GetComponent<FollowThePath>().moveAllowed = false;
                    playerPositions[activePlayer] = activePlayer.GetComponent<FollowThePath>().waypointIndex - 1;

                    switch (activePlayer.GetComponent<FollowThePath>().waypointIndex)
                    {
                        case 4:
                        case 13:
                        case 17:
                        case 23:
                            Debug.Log(activePlayer.name + " goes again");
                            break;
                        case 7:
                            Debug.Log(activePlayer.name + " went in portal");
                            activePlayer.GetComponent<FollowThePath>().moveSpeed = 3f;
                            diceSideThrown = 5;
                            activePlayer.GetComponent<FollowThePath>().moveAllowed = true;
                            break;
                        case 25:
                            Debug.Log(activePlayer.name + " went in portal");
                            activePlayer.GetComponent<FollowThePath>().moveSpeed = 3f;
                            diceSideThrown = 4;
                            activePlayer.GetComponent<FollowThePath>().moveAllowed = true;
                            break;
                        case 12:
                        case 29:
                            Debug.Log(activePlayer.name + " exited portal");
                            activePlayer.GetComponent<FollowThePath>().moveSpeed = 1f;
                            NextTurn();
                            break;
                        case 34:
                            String winner = activePlayer.name;
                            Debug.Log("Game Over, " + winner + " Wins");
                            diceUI.SetActive(false);
                            GameOverUI.SetActive(true);
                            GameOverUI.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = winner;
                            break;
                        default:
                            NextTurn();
                            break;

                    }
                }
            }
        }
        
     }

    private static void NextTurn()
    {
        WhosTurn++;
        if (WhosTurn > players.Count)
        {
            WhosTurn = 1;
        }
    }
    
    public static void AskQuestion()
    {
        Debug.Log("AskQuestion");

       // string getqn = "SELECT * FROM questions WHERE Qn_Number = '" + Dice.QuestionID + "';";
        string getqn = "SELECT * FROM questions WHERE ROWID = '" + Dice.QuestionID + "';";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = getqn;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int test = reader.GetInt32(0);
            Question_Question = reader.GetString(1);
            Question_Answer1 = reader.GetString(2);
            Question_Answer2 = reader.GetString(3);
            Question_Answer3 = reader.GetString(4);
            Question_Correct = reader.GetString(5);

        }

        Debug.Log("Qn: " + Question_Question);
        Debug.Log("Ans1: " + Question_Answer1);
        Debug.Log("Ans2: " + Question_Answer2);
        Debug.Log("Ans3: " + Question_Answer3);
        Debug.Log("CorrectAns: " + Question_Correct);

        gamePaused = true;
        QuestionUI.SetActive(true);
        
        QuestionText.SetText(Question_Question);
        ans1Text.SetText(Question_Answer1);
        ans2Text.SetText(Question_Answer2);
        ans3Text.SetText(Question_Answer3);

    }

    public void AnswerQuestion(TextMeshProUGUI answerText)
    {
        
        if (answerText.text == Question_Correct)
        {
            QuestionCorrect = true;
        }
        else
        {
            QuestionCorrect = false;
        }
      
        QuestionUI.SetActive(false);
        gamePaused = false;

        if (QuestionCorrect)
        {
            StartCoroutine(RightAns());
        }
        else
        {
            StartCoroutine(WrongAns());
        }
        
    }
    IEnumerator RightAns()
    {
        Right.SetActive(true);
        yield return new WaitForSeconds(1);
        Right.SetActive(false);
        activePlayer.GetComponent<FollowThePath>().moveAllowed = true;
        QuestionCorrect = false;
    }

    IEnumerator WrongAns()
    {
        Wrong.SetActive(true);
        yield return new WaitForSeconds(1);
        Wrong.SetActive(false);
        NextTurn();
    }
}
