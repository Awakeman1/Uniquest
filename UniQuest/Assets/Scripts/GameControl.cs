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

    private static GameObject expectedans, Player1, Player2, Player3, Player4, Player5, Player6, Player7, Player8, Player9, Player10, activePlayer, Mcamera, mainUI, diceUI, GameOverUI, QuestionUI, Wrong, Right, ans1, ans2, ans3, currentplayertext;
    private static ArrayList players;
    private static Dictionary<GameObject, int> playerPositions;
    public static int diceSideThrown = 0, NumberofPlayers, WhosTurn = 1;   
    
    public static TextMeshProUGUI QuestionText, ans1Text,ans2Text, ans3Text;
    public static bool QuestionCorrect = false, gamePaused = false; 
    public static String Question_Question, Question_Answer1, Question_Answer2, Question_Answer3, Question_Correct, Question_Type, conn ;
    public static IDbConnection dbconn;
    public static ParticleSystem Rollagain1, Rollagain2, Rollagain3, Rollagain4, In1, In2, Out1, Out2;
    
    public void Awake(){
        Debug.Log("GameControl Awake");
    }

    public void Start()
    {
        Debug.Log("GameControl Onstart()");
        Mcamera = GameObject.Find("MainCamera");
        conn = "URI=file:" + Application.dataPath + "/dbQuestions.s3db";
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand getqn = dbconn.CreateCommand();
        
        
        Rollagain1 = GameObject.Find("Rollagain1").GetComponent<ParticleSystem>();
        Rollagain2 = GameObject.Find("Rollagain2").GetComponent<ParticleSystem>();
        Rollagain3 = GameObject.Find("Rollagain3").GetComponent<ParticleSystem>();
        Rollagain4 = GameObject.Find("Rollagain4").GetComponent<ParticleSystem>();
        In1 = GameObject.Find("In1").GetComponent<ParticleSystem>();
        In2 = GameObject.Find("In2").GetComponent<ParticleSystem>();
        Out1 = GameObject.Find("Out1").GetComponent<ParticleSystem>();
        Out2 = GameObject.Find("Out2").GetComponent<ParticleSystem>();

        expectedans = GameObject.Find("expectedans");

        currentplayertext = GameObject.Find("CurrentPlayerText");
        currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Yellow";

        mainUI = GameObject.Find("Canvas");
        diceUI = GameObject.Find("DiceButton");
        GameOverUI = GameObject.Find("GameOverPanel");
        QuestionUI = GameObject.Find("QuestionPanel");
        Wrong = GameObject.Find("Wrong");
        Right = GameObject.Find("Right");

        QuestionText = GameObject.Find("QuestionText").GetComponent<TextMeshProUGUI>();
        ans1 = GameObject.Find("OptionA");
        ans2 = GameObject.Find("OptionB");
        ans3 = GameObject.Find("OptionC");

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
        Debug.Log("Test: should have added all the elements if this is running");
        
        players = new ArrayList()
        {Player1, Player2, Player3, Player4, Player5, Player6, Player7, Player8, Player9, Player10};

        NumberofPlayers = MainMenu.NumPlayers;
        for(int i = 10; i > NumberofPlayers; i--)
        {
            GameObject player = (GameObject) players[i-1];
            player.SetActive(false);
            players.Remove(player);
            Debug.Log("Players: " + players);
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
        Mcamera.transform.SetParent(Player1.gameObject.transform, false);
        
    }

    void Update()
    {
        if (!gamePaused)
        {
            activePlayer = (GameObject)players[WhosTurn - 1];
            if (activePlayer.GetComponent<FollowThePath>().moveAllowed == true)
            {
                if (activePlayer.GetComponent<FollowThePath>().waypointIndex > 34)
                {
                    activePlayer.GetComponent<FollowThePath>().moveAllowed = false;
                    String winner = activePlayer.name;
                    gamePaused = true;
                    Debug.Log("Game Over, " + winner + " Wins");
                    diceUI.SetActive(false);
                    GameOverUI.SetActive(true);
                    switch (winner)
                    {
                        case "Player1":
                            GameOverUI.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Yellow";
                            break;
                        case "Player2":
                            GameOverUI.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Red";
                            break;
                        case "Player3":
                            GameOverUI.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Purple";
                            break;
                        case "Player4":
                            GameOverUI.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Light Pink";
                            break;
                        case "Player5":
                            GameOverUI.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Orange";
                            break;
                        case "Player6":
                            GameOverUI.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Hot Pink";
                            break;
                        case "Player7":
                            GameOverUI.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Green";
                            break;
                        case "Player8":
                            GameOverUI.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Dark Blue";
                            break;
                        case "Player9":
                            GameOverUI.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Brown";
                            break;
                        case "Player10":
                            GameOverUI.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Light Blue";
                            break;
                    }
                                        
                }
                else if (activePlayer.GetComponent<FollowThePath>().waypointIndex > playerPositions[activePlayer] + diceSideThrown)
                {
                    activePlayer.GetComponent<FollowThePath>().moveAllowed = false;
                    playerPositions[activePlayer] = activePlayer.GetComponent<FollowThePath>().waypointIndex - 1;

                    switch (activePlayer.GetComponent<FollowThePath>().waypointIndex)
                    {
                        case 4:
                            Debug.Log(activePlayer.name + " goes again");
                            Rollagain1.Play();
                            break;
                        case 13:
                            Debug.Log(activePlayer.name + " goes again");
                            Rollagain2.Play();
                            break;
                        case 17:
                            Debug.Log(activePlayer.name + " goes again");
                            Rollagain3.Play();
                            break;
                        case 23:
                            Debug.Log(activePlayer.name + " goes again");
                            Rollagain4.Play();
                            break;
                        case 7:
                            Debug.Log(activePlayer.name + " went in portal");
                            activePlayer.GetComponent<FollowThePath>().moveSpeed = 3f;
                            diceSideThrown = 5;
                            activePlayer.GetComponent<FollowThePath>().moveAllowed = true;
                            In1.Play();
                            
                            break;
                        case 25:
                            Debug.Log(activePlayer.name + " went in portal");
                            activePlayer.GetComponent<FollowThePath>().moveSpeed = 3f;
                            diceSideThrown = 4;
                            activePlayer.GetComponent<FollowThePath>().moveAllowed = true;
                            In2.Play();
                            break;
                        case 12:
                            Debug.Log(activePlayer.name + " exited portal");
                            activePlayer.GetComponent<FollowThePath>().moveSpeed = 2f;Out1.Play();
                            Out1.Play();
                            NextTurn();
                            break;
                        case 29:
                            Debug.Log(activePlayer.name + " exited portal");
                            activePlayer.GetComponent<FollowThePath>().moveSpeed = 2f;Out1.Play();
                            Out2.Play();
                            NextTurn();
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
        switch(WhosTurn)
        {
            case 1:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Yellow";
            Mcamera.transform.SetParent(Player1.gameObject.transform, false);
            break;
            case 2:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Red";
            Mcamera.transform.SetParent(Player2.gameObject.transform, false);
            break;
            case 3:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Purple";
            Mcamera.transform.SetParent(Player3.gameObject.transform, false);
            break;
            case 4:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Light Pink";
            Mcamera.transform.SetParent(Player4.gameObject.transform, false);
            break;
            case 5:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Orange";
            Mcamera.transform.SetParent(Player5.gameObject.transform, false);
            break;
            case 6:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Hot Pink";
            Mcamera.transform.SetParent(Player6.gameObject.transform, false);
            break;
            case 7:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Green";
            Mcamera.transform.SetParent(Player7.gameObject.transform, false);
            break;
            case 8:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Dark Blue";
            Mcamera.transform.SetParent(Player8.gameObject.transform, false);
            break;
            case 9:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Brown";
            Mcamera.transform.SetParent(Player9.gameObject.transform, false);
            break;
            case 10:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Light Blue";
            Mcamera.transform.SetParent(Player10.gameObject.transform, false);
            break;
        }
        

        switch(WhosTurn)
        {
            case 1:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Yellow";
            break;
            case 2:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Red";
            break;
            case 3:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Purple";
            break;
            case 4:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Light Pink";
            break;
            case 5:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Orange";
            break;
            case 6:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Hot Pink";
            break;
            case 7:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Green";
            break;
            case 8:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Dark Blue";
            break;
            case 9:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Brown";
            break;
            case 10:
            currentplayertext.GetComponent<UnityEngine.UI.Text>().text = "Current Player is: Light Blue";
            break;
        }
    }

   

    
    public static void AskQuestion() //Rebuild
    {
        Debug.Log("AskQuestion");
        

        string getqn = "SELECT * FROM questions WHERE ROWID = '" + Dice.QuestionID + "';";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = getqn;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            Question_Question = reader.GetString(0);
            Question_Answer1 = reader.GetString(1);
            Question_Answer2 = reader.GetString(2);
            Question_Answer3 = reader.GetString(3);
            Question_Correct = reader.GetString(4);
            Question_Type = reader.GetString(5);
        }

        Debug.Log("Qn: " + Question_Question);
        Debug.Log("Ans1: " + Question_Answer1);
        Debug.Log("Ans2: " + Question_Answer2);
        Debug.Log("Ans3: " + Question_Answer3);
        Debug.Log("CorrectAns: " + Question_Correct);

        gamePaused = true;
        
        if(Question_Type == "mc")
        {
            Debug.Log("mc");
            QuestionText.SetText(Question_Question);
            ans1Text.SetText(Question_Answer1);
            ans2Text.SetText(Question_Answer2);
            ans3Text.SetText(Question_Answer3);
            ans3.SetActive(true);
            QuestionUI.SetActive(true);
        }
        else if(Question_Type == "tf")
        {
            Debug.Log("tf");
            QuestionText.SetText(Question_Question);
            ans1Text.SetText(Question_Answer1);
            ans2Text.SetText(Question_Answer2);
            ans3.SetActive(false);
            QuestionUI.SetActive(true);
        }
        else if(Question_Type == "yn")
        {
            Debug.Log("yn");
            QuestionText.SetText(Question_Question);
            ans1Text.SetText(Question_Answer1);
            ans2Text.SetText(Question_Answer2);
            ans3.SetActive(false);
            QuestionUI.SetActive(true);
        }

    }

    public void AnswerQuestion(TextMeshProUGUI answerText) // Rebuild
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
        expectedans.GetComponent<UnityEngine.UI.Text>().text = Question_Correct;
        Wrong.SetActive(true);
        yield return new WaitForSeconds(2);
        Wrong.SetActive(false);
        NextTurn();
    }
}
