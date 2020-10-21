using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections; 
using System.Collections.Generic;
using System.IO;
using System.Data;
using Mono.Data.Sqlite;


public class GameControl : MonoBehaviour {

    private static GameObject Player1;
    private static GameObject Player2;
    private static GameObject Player3;
    private static GameObject Player4;
    private static GameObject Player5;
    private static GameObject Player6;
    private static GameObject Player7;
    private static GameObject Player8;
    private static GameObject Player9;
    private static GameObject Player10;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;
    public static int player3StartWaypoint = 0;
    public static int player4StartWaypoint = 0;
    public static int player5StartWaypoint = 0;
    public static int player6StartWaypoint = 0;
    public static int player7StartWaypoint = 0;
    public static int player8StartWaypoint = 0;
    public static int player9StartWaypoint = 0;
    public static int player10StartWaypoint = 0;

    public int NumberofPlayers;
    private static GameObject Mcamera;
    public static int diceSideThrown = 0;   
    public static int WhosTurn = 1;

    public static GameObject mainUI;
    public static GameObject GameOverUI;
    public static GameObject QuestionUI;



    public static Boolean QuestionCorrect = false; 
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
        


        NumberofPlayers = MainMenu.NumPlayers;
        mainUI = GameObject.Find("Canvas");
        GameOverUI = GameObject.Find("GameOver");
        QuestionUI = GameObject.Find("QuestionUI");
        GameOverUI.SetActive(false);
        QuestionUI.SetActive(false);
        
        switch(NumberofPlayers){
            case 2:
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
                Player3.SetActive(false);   
                Player4.SetActive(false);
                Player5.SetActive(false);
                Player6.SetActive(false);
                Player7.SetActive(false);
                Player8.SetActive(false);
                Player9.SetActive(false);
                Player10.SetActive(false);           
                
            break;

            case 3:
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
                Player4.SetActive(false);
                Player5.SetActive(false);
                Player6.SetActive(false);
                Player7.SetActive(false);
                Player8.SetActive(false);
                Player9.SetActive(false);
                Player10.SetActive(false);
                
            break;

            case 4:
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
                Player5.SetActive(false);
                Player6.SetActive(false);
                Player7.SetActive(false);
                Player8.SetActive(false);
                Player9.SetActive(false);
                Player10.SetActive(false);
            break;

            case 5:
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
                Player6.SetActive(false);
                Player7.SetActive(false);
                Player8.SetActive(false);
                Player9.SetActive(false);
                Player10.SetActive(false);
            break;

            case 6:
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
                Player1.GetComponent<AudioListener>().enabled = false;
                Player2.GetComponent<AudioListener>().enabled = false;
                Player3.GetComponent<AudioListener>().enabled = false;
                Player4.GetComponent<AudioListener>().enabled = false;
                Player5.GetComponent<AudioListener>().enabled = false;
                Player6.GetComponent<AudioListener>().enabled = false;
                Player7.SetActive(false);
                Player8.SetActive(false);
                Player9.SetActive(false);
                Player10.SetActive(false);
            break;

            case 7:
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
                Player1.GetComponent<AudioListener>().enabled = false;
                Player2.GetComponent<AudioListener>().enabled = false;
                Player3.GetComponent<AudioListener>().enabled = false;
                Player4.GetComponent<AudioListener>().enabled = false;
                Player5.GetComponent<AudioListener>().enabled = false;
                Player6.GetComponent<AudioListener>().enabled = false;
                Player7.GetComponent<AudioListener>().enabled = false;
                Player8.SetActive(false);
                Player9.SetActive(false);
                Player10.SetActive(false);
            break;

            case 8:
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
                Player1.GetComponent<AudioListener>().enabled = false;
                Player2.GetComponent<AudioListener>().enabled = false;
                Player3.GetComponent<AudioListener>().enabled = false;
                Player4.GetComponent<AudioListener>().enabled = false;
                Player5.GetComponent<AudioListener>().enabled = false;
                Player6.GetComponent<AudioListener>().enabled = false;
                Player7.GetComponent<AudioListener>().enabled = false;
                Player8.GetComponent<AudioListener>().enabled = false;
                Player9.SetActive(false);
                Player10.SetActive(false);
            break;

            case 9:
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
                Player1.GetComponent<AudioListener>().enabled = false;
                Player2.GetComponent<AudioListener>().enabled = false;
                Player3.GetComponent<AudioListener>().enabled = false;
                Player4.GetComponent<AudioListener>().enabled = false;
                Player5.GetComponent<AudioListener>().enabled = false;
                Player6.GetComponent<AudioListener>().enabled = false;
                Player7.GetComponent<AudioListener>().enabled = false;
                Player8.GetComponent<AudioListener>().enabled = false;
                Player9.GetComponent<AudioListener>().enabled = false;
                Player10.SetActive(false);
            break;
            
            case 10:
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
                Player1.GetComponent<AudioListener>().enabled = false;
                Player2.GetComponent<AudioListener>().enabled = false;
                Player3.GetComponent<AudioListener>().enabled = false;
                Player4.GetComponent<AudioListener>().enabled = false;
                Player5.GetComponent<AudioListener>().enabled = false;
                Player6.GetComponent<AudioListener>().enabled = false;
                Player7.GetComponent<AudioListener>().enabled = false;
                Player8.GetComponent<AudioListener>().enabled = false;
                Player9.GetComponent<AudioListener>().enabled = false;
                Player10.GetComponent<AudioListener>().enabled = false;
            break;
        }

        Mcamera = GameObject.Find("MainCamera");
        Mcamera.SetActive(true);
        Mcamera.GetComponent<AudioListener>().enabled = false;
        
    }


    void Update()
    {
        if (Player1.GetComponent<FollowThePath>().waypointIndex == 34)
        {
            Player1.GetComponent<FollowThePath>().moveAllowed = false;
            Debug.Log("Game Over, Player1 Wins");
            GameControl.WhosTurn = 0;
            mainUI.SetActive(false);
            GameOverUI.SetActive(true);
            GameOverUI.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Player 1";
        }
        if (Player2.GetComponent<FollowThePath>().waypointIndex == 34)
        {
            Player2.GetComponent<FollowThePath>().moveAllowed = false;
            Debug.Log("Game Over, Player2 Wins");
            GameControl.WhosTurn = 0;
            mainUI.SetActive(false);
            GameOverUI.SetActive(true);
            GameOverUI.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Player 2";
        }
        if (Player3.GetComponent<FollowThePath>().waypointIndex == 34)
        {
            Player3.GetComponent<FollowThePath>().moveAllowed = false;
            Debug.Log("Game Over, Player3 Wins");
            GameControl.WhosTurn = 0;
            mainUI.SetActive(false);
            GameOverUI.SetActive(true);
            GameOverUI.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Player 3";
        }
        if (Player4.GetComponent<FollowThePath>().waypointIndex == 34)
        {
            Player4.GetComponent<FollowThePath>().moveAllowed = false;
            Debug.Log("Game Over, Player4 Wins");
            GameControl.WhosTurn = 0;
            mainUI.SetActive(false);
            GameOverUI.SetActive(true);
            GameOverUI.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Player 4";
        }
        if (Player5.GetComponent<FollowThePath>().waypointIndex == 34)
        {
            Player5.GetComponent<FollowThePath>().moveAllowed = false;
            Debug.Log("Game Over, Player5 Wins");
            GameControl.WhosTurn = 0;
            mainUI.SetActive(false);
            GameOverUI.SetActive(true);
            GameOverUI.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Player 5";
        }
        if (Player6.GetComponent<FollowThePath>().waypointIndex == 34)
        {
            Player6.GetComponent<FollowThePath>().moveAllowed = false;
            Debug.Log("Game Over, Player6 Wins");
            GameControl.WhosTurn = 0;
            mainUI.SetActive(false);
            GameOverUI.SetActive(true);
            GameOverUI.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Player 6";
        }
        if (Player7.GetComponent<FollowThePath>().waypointIndex == 34)
        {
            Player7.GetComponent<FollowThePath>().moveAllowed = false;
            Debug.Log("Game Over, Player7 Wins");
            GameControl.WhosTurn = 0;
            mainUI.SetActive(false);
            GameOverUI.SetActive(true);
            GameOverUI.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Player 7";
        }
        if (Player8.GetComponent<FollowThePath>().waypointIndex == 34)
        {
            Player8.GetComponent<FollowThePath>().moveAllowed = false;
            Debug.Log("Game Over, Player8 Wins");
            GameControl.WhosTurn = 0;
            mainUI.SetActive(false);
            GameOverUI.SetActive(true);
            GameOverUI.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Player 8";
        }
        if (Player9.GetComponent<FollowThePath>().waypointIndex == 34)
        {
            Player9.GetComponent<FollowThePath>().moveAllowed = false;
            Debug.Log("Game Over, Player9 Wins");
            GameControl.WhosTurn = 0;
            mainUI.SetActive(false);
            GameOverUI.SetActive(true);
            GameOverUI.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Player 9";
        }
        if (Player10.GetComponent<FollowThePath>().waypointIndex == 34)
        {
            Player10.GetComponent<FollowThePath>().moveAllowed = false;
            Debug.Log("Game Over, Player10 Wins");
            GameControl.WhosTurn = 0;
            mainUI.SetActive(false);
            GameOverUI.SetActive(true);
            GameOverUI.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Player 10";
        }


        if(Player1.GetComponent<FollowThePath>().waypointIndex > player1StartWaypoint + diceSideThrown){
            Player1.GetComponent<FollowThePath>().moveAllowed = false;
            player1StartWaypoint = Player1.GetComponent<FollowThePath>().waypointIndex - 1;

            

            switch(Player1.GetComponent<FollowThePath>().waypointIndex){
                case 4:
                    WhosTurn = 1;
                    Debug.Log("p1 goes again");
                    break;
                case 7:
                    Debug.Log("p1 went in");
                    Player1.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player1.GetComponent<FollowThePath>().waypointIndex == 12){
                        Debug.Log("p1 came out");
                        Player1.GetComponent<FollowThePath>().moveAllowed = false;
                        player1StartWaypoint = Player1.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
                case 13:
                    WhosTurn = 1;
                    Debug.Log("p1 goes again");
                    break;
                case 17:
                    WhosTurn = 1;
                    Debug.Log("p1 goes again");
                    break;
                case 23:
                    WhosTurn = 1;
                    Debug.Log("p1 goes again");
                    break;
                case 25:
                    Debug.Log("p1 went in");
                    Player1.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player1.GetComponent<FollowThePath>().waypointIndex == 29){
                        Debug.Log("p1 came out");
                        Player1.GetComponent<FollowThePath>().moveAllowed = false;
                        player1StartWaypoint = Player1.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
            }
        }            

        if(Player2.GetComponent<FollowThePath>().waypointIndex > player2StartWaypoint + diceSideThrown){
            Player2.GetComponent<FollowThePath>().moveAllowed = false;
            player2StartWaypoint = Player2.GetComponent<FollowThePath>().waypointIndex - 1;  

            switch(Player2.GetComponent<FollowThePath>().waypointIndex){
                case 4:
                    WhosTurn = 2;
                    Debug.Log("p2 goes again");
                    break;
                case 7:
                    Debug.Log("p2 went in");
                    Player2.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player2.GetComponent<FollowThePath>().waypointIndex == 12){
                        Debug.Log("p2 came out");
                        Player2.GetComponent<FollowThePath>().moveAllowed = false;
                        player2StartWaypoint = Player2.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
                case 13:
                    WhosTurn = 2;
                    Debug.Log("p2 goes again");
                    break;
                case 17:
                    WhosTurn = 2;
                    Debug.Log("p2 goes again");
                    break;
                case 23:
                    WhosTurn = 2;
                    Debug.Log("p2 goes again");
                    break;
                case 25:
                    Debug.Log("p2 went in");
                    Player2.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player2.GetComponent<FollowThePath>().waypointIndex == 29){
                        Debug.Log("p2 came out");
                        Player2.GetComponent<FollowThePath>().moveAllowed = false;
                        player2StartWaypoint = Player2.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
                
            }
        }

        if(Player3.GetComponent<FollowThePath>().waypointIndex > player3StartWaypoint + diceSideThrown){
            Player3.GetComponent<FollowThePath>().moveAllowed = false;
            player3StartWaypoint = Player3.GetComponent<FollowThePath>().waypointIndex - 1;

            switch(Player3.GetComponent<FollowThePath>().waypointIndex){
                case 4:
                    WhosTurn = 3;
                    Debug.Log("p3 goes again");
                    break;
                case 7:
                    Debug.Log("p3 went in");
                    Player3.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player3.GetComponent<FollowThePath>().waypointIndex == 12){
                        Debug.Log("p3 came out");
                        Player1.GetComponent<FollowThePath>().moveAllowed = false;
                        player3StartWaypoint = Player3.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
                case 13:
                    WhosTurn = 3;
                    Debug.Log("p3 goes again");
                    break;
                case 17:
                    WhosTurn = 3;
                    Debug.Log("p3 goes again");
                    break;
                case 23:
                    WhosTurn = 3;
                    Debug.Log("p3 goes again");
                    break;   
                case 25:
                    Debug.Log("p3 went in");
                    Player3.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player3.GetComponent<FollowThePath>().waypointIndex == 29){
                        Debug.Log("p3 came out");
                        Player1.GetComponent<FollowThePath>().moveAllowed = false;
                        player3StartWaypoint = Player3.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break; 
            }
        }

        if(Player4.GetComponent<FollowThePath>().waypointIndex > player4StartWaypoint + diceSideThrown){
            Player4.GetComponent<FollowThePath>().moveAllowed = false;
            player4StartWaypoint = Player4.GetComponent<FollowThePath>().waypointIndex - 1;

            switch(Player4.GetComponent<FollowThePath>().waypointIndex){
                case 4:
                    WhosTurn = 4;
                    Debug.Log("p4 goes again");
                    break;
                case 7:
                    Debug.Log("p4 went in");
                    Player4.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player4.GetComponent<FollowThePath>().waypointIndex == 12){
                        Debug.Log("p4 came out");
                        Player4.GetComponent<FollowThePath>().moveAllowed = false;
                        player4StartWaypoint = Player4.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
                case 13:
                    WhosTurn = 4;
                    Debug.Log("p4 goes again");
                    break;
                case 17:
                    WhosTurn = 4;
                    Debug.Log("p4 goes again");
                    break;
                case 23:
                    WhosTurn = 4;
                    Debug.Log("p4 goes again");
                    break;
                case 25:
                    Debug.Log("p4 went in");
                    Player4.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player4.GetComponent<FollowThePath>().waypointIndex == 29){
                        Debug.Log("p4 came out");
                        Player4.GetComponent<FollowThePath>().moveAllowed = false;
                        player4StartWaypoint = Player4.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
            }
        }

        if(Player5.GetComponent<FollowThePath>().waypointIndex > player5StartWaypoint + diceSideThrown){
            Player5.GetComponent<FollowThePath>().moveAllowed = false;
            player5StartWaypoint = Player5.GetComponent<FollowThePath>().waypointIndex - 1;

            switch(Player5.GetComponent<FollowThePath>().waypointIndex){
                case 4:
                    WhosTurn = 5;
                    Debug.Log("p5 goes again");
                    break;
                case 7:
                    Debug.Log("p5 went in");
                    Player5.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player5.GetComponent<FollowThePath>().waypointIndex == 12){
                        Debug.Log("p5 came out");
                        Player5.GetComponent<FollowThePath>().moveAllowed = false;
                        player5StartWaypoint = Player5.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
                case 13:
                    WhosTurn = 5;
                    Debug.Log("p5 goes again");
                    break;
                case 17:
                    WhosTurn = 5;
                    Debug.Log("p5 goes again");
                    break;
                case 23:
                    WhosTurn = 5;
                    Debug.Log("p5 goes again");
                    break;
                case 25:
                    Debug.Log("p5 went in");
                    Player5.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player5.GetComponent<FollowThePath>().waypointIndex == 29){
                        Debug.Log("p5 came out");
                        Player5.GetComponent<FollowThePath>().moveAllowed = false;
                        player5StartWaypoint = Player5.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
            }
        }
        
        if(Player6.GetComponent<FollowThePath>().waypointIndex > player6StartWaypoint + diceSideThrown){
            Player6.GetComponent<FollowThePath>().moveAllowed = false;
            player6StartWaypoint = Player6.GetComponent<FollowThePath>().waypointIndex - 1;

            switch(Player6.GetComponent<FollowThePath>().waypointIndex){
                case 4:
                    WhosTurn = 6;
                    Debug.Log("p6 goes again");
                    break;
                case 7:
                    Debug.Log("p6 went in");
                    Player6.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player6.GetComponent<FollowThePath>().waypointIndex == 12){
                        Debug.Log("p6 came out");
                        Player6.GetComponent<FollowThePath>().moveAllowed = false;
                        player6StartWaypoint = Player6.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
                case 13:
                    WhosTurn = 6;
                    Debug.Log("p6 goes again");
                    break;
                case 17:
                    WhosTurn = 6;
                    Debug.Log("p6 goes again");
                    break;
                case 23:
                    WhosTurn = 6;
                    Debug.Log("p6 goes again");
                    break;
                case 25:
                    Debug.Log("p6 went in");
                    Player6.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player6.GetComponent<FollowThePath>().waypointIndex == 29){
                        Debug.Log("p6 came out");
                        Player6.GetComponent<FollowThePath>().moveAllowed = false;
                        player6StartWaypoint = Player6.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
            }
        }

        if(Player7.GetComponent<FollowThePath>().waypointIndex > player7StartWaypoint + diceSideThrown){
            Player7.GetComponent<FollowThePath>().moveAllowed = false;
            player7StartWaypoint = Player7.GetComponent<FollowThePath>().waypointIndex - 1;

            switch(Player7.GetComponent<FollowThePath>().waypointIndex){
                case 4:
                    WhosTurn = 7;
                    Debug.Log("p7 goes again");
                    break;
                case 7:
                    Debug.Log("p7 went in");
                    Player7.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player7.GetComponent<FollowThePath>().waypointIndex == 12){
                        Debug.Log("p7 came out");
                        Player7.GetComponent<FollowThePath>().moveAllowed = false;
                        player7StartWaypoint = Player7.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
                case 13:
                    WhosTurn = 7;
                    Debug.Log("p7 goes again");
                    break;
                case 17:
                    WhosTurn = 7;
                    Debug.Log("p7 goes again");
                    break;
                case 23:
                    WhosTurn = 7;
                    Debug.Log("p7 goes again");
                    break;
                case 25:
                    Debug.Log("p7 went in");
                    Player7.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player7.GetComponent<FollowThePath>().waypointIndex == 29){
                        Debug.Log("p7 came out");
                        Player7.GetComponent<FollowThePath>().moveAllowed = false;
                        player7StartWaypoint = Player7.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
            }
        }

        if(Player8.GetComponent<FollowThePath>().waypointIndex > player8StartWaypoint + diceSideThrown){
            Player8.GetComponent<FollowThePath>().moveAllowed = false;
            player8StartWaypoint = Player8.GetComponent<FollowThePath>().waypointIndex - 1;

            switch(Player8.GetComponent<FollowThePath>().waypointIndex){
                case 4:
                    WhosTurn = 8;
                    Debug.Log("p8 goes again");
                    break;
                case 7:
                    Debug.Log("p8 went in");
                    Player8.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player8.GetComponent<FollowThePath>().waypointIndex == 12){
                        Debug.Log("p8 came out");
                        Player8.GetComponent<FollowThePath>().moveAllowed = false;
                        player8StartWaypoint = Player8.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
                case 13:
                    WhosTurn = 8;
                    Debug.Log("p8 goes again");
                    break;
                case 17:
                    WhosTurn = 8;
                    Debug.Log("p8 goes again");
                    break;
                case 23:
                    WhosTurn = 8;
                    Debug.Log("p8 goes again");
                    break;
                case 25:
                    Debug.Log("p8 went in");
                    Player8.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player8.GetComponent<FollowThePath>().waypointIndex == 29){
                        Debug.Log("p8 came out");
                        Player8.GetComponent<FollowThePath>().moveAllowed = false;
                        player8StartWaypoint = Player8.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
            }
        }

        if(Player9.GetComponent<FollowThePath>().waypointIndex > player9StartWaypoint + diceSideThrown){
            Player9.GetComponent<FollowThePath>().moveAllowed = false;
            player9StartWaypoint = Player9.GetComponent<FollowThePath>().waypointIndex - 1;

            switch(Player9.GetComponent<FollowThePath>().waypointIndex){
                case 4:
                    WhosTurn = 9;
                    Debug.Log("p9 goes again");
                    break;
                case 7:
                    Debug.Log("p9 went in");
                    Player9.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player9.GetComponent<FollowThePath>().waypointIndex == 12){
                        Debug.Log("p9 came out");
                        Player9.GetComponent<FollowThePath>().moveAllowed = false;
                        player9StartWaypoint = Player9.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
                case 13:
                    WhosTurn = 9;
                    Debug.Log("p9 goes again");
                    break;
                case 17:
                    WhosTurn = 9;
                    Debug.Log("p9 goes again");
                    break;
                case 23:
                    WhosTurn = 9;
                    Debug.Log("p9 goes again");
                    break;
                case 25:
                    Debug.Log("p9 went in");
                    Player9.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player9.GetComponent<FollowThePath>().waypointIndex == 29){
                        Debug.Log("p9 came out");
                        Player9.GetComponent<FollowThePath>().moveAllowed = false;
                        player9StartWaypoint = Player9.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
            }
        }

        if(Player10.GetComponent<FollowThePath>().waypointIndex > player10StartWaypoint + diceSideThrown){
            Player10.GetComponent<FollowThePath>().moveAllowed = false;
            player10StartWaypoint = Player10.GetComponent<FollowThePath>().waypointIndex - 1;

            switch(Player10.GetComponent<FollowThePath>().waypointIndex){
                case 4:
                    WhosTurn = 10;
                    Debug.Log("p10 goes again");
                    break;
                case 7:
                    Debug.Log("p10 went in");
                    Player10.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player10.GetComponent<FollowThePath>().waypointIndex == 12){
                        Debug.Log("p10 came out");
                        Player10.GetComponent<FollowThePath>().moveAllowed = false;
                        player10StartWaypoint = Player10.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
                case 13:
                    WhosTurn = 10;
                    Debug.Log("p10 goes again");
                    break;
                case 17:
                    WhosTurn = 10;
                    Debug.Log("p10 goes again");
                    break;
                case 23:
                    WhosTurn = 10;
                    Debug.Log("p10 goes again");
                    break;
                case 25:
                    Debug.Log("p10 went in");
                    Player10.GetComponent<FollowThePath>().moveAllowed = true;
                    if(Player10.GetComponent<FollowThePath>().waypointIndex == 29){
                        Debug.Log("p10 came out");
                        Player10.GetComponent<FollowThePath>().moveAllowed = false;
                        player10StartWaypoint = Player10.GetComponent<FollowThePath>().waypointIndex - 1;
                    }
                    break;
            }
        }

     }



    public static void MovePlayer(int WhoMoves)
    {
        Debug.Log("Moveplayer");
        switch(WhoMoves){
            case 1:
                
                string getqn = "SELECT * FROM questions WHERE Qn_Number = '" + Dice.QuestionID + "';";
                
                IDbCommand dbcmd = dbconn.CreateCommand();
                dbcmd.CommandText = getqn;
                IDataReader reader = dbcmd.ExecuteReader();
                while(reader.Read())
                {
                    int test = reader.GetInt32(0);
                    Question_Question = reader.GetString(1);
                    Question_Answer1 = reader.GetString(2);
                    Question_Answer2 = reader.GetString(3);
                    Question_Answer3 = reader.GetString(4);
                    Question_Correct = reader.GetString(5);
                    
                }
                    Debug.Log("Qn: " + Question_Question);
                    Debug.Log("ans1: " + Question_Answer1);
                    Debug.Log("ans2: " + Question_Answer2);
                    Debug.Log("ans3: " + Question_Answer3);
                    Debug.Log("Correct: " + Question_Correct);
                    


                if(QuestionCorrect){
                    Player1.GetComponent<FollowThePath>().moveAllowed = true;
                }
                else{
                    Player1.GetComponent<FollowThePath>().moveAllowed = false;
                }
                break;
            case 2:

                string getqn = "SELECT * FROM questions WHERE Qn_Number = '" + Dice.QuestionID + "';";
                
                IDbCommand dbcmd = dbconn.CreateCommand();
                dbcmd.CommandText = getqn;
                IDataReader reader = dbcmd.ExecuteReader();
                while(reader.Read())
                {
                    int test = reader.GetInt32(0);
                    Question_Question = reader.GetString(1);
                    Question_Answer1 = reader.GetString(2);
                    Question_Answer2 = reader.GetString(3);
                    Question_Answer3 = reader.GetString(4);
                    Question_Correct = reader.GetString(5);
                    
                }
                    Debug.Log("Qn: " + Question_Question);
                    Debug.Log("ans1: " + Question_Answer1);
                    Debug.Log("ans2: " + Question_Answer2);
                    Debug.Log("ans3: " + Question_Answer3);
                    Debug.Log("Correct: " + Question_Correct);


                if(QuestionCorrect){
                    Player2.GetComponent<FollowThePath>().moveAllowed = true;
                }
                else{
                    Player2.GetComponent<FollowThePath>().moveAllowed = false;
                }
                break;
            case 3:
                string getqn = "SELECT * FROM questions WHERE Qn_Number = '" + Dice.QuestionID + "';";
                
                IDbCommand dbcmd = dbconn.CreateCommand();
                dbcmd.CommandText = getqn;
                IDataReader reader = dbcmd.ExecuteReader();
                while(reader.Read())
                {
                    int test = reader.GetInt32(0);
                    Question_Question = reader.GetString(1);
                    Question_Answer1 = reader.GetString(2);
                    Question_Answer2 = reader.GetString(3);
                    Question_Answer3 = reader.GetString(4);
                    Question_Correct = reader.GetString(5);
                    
                }
                    Debug.Log("Qn: " + Question_Question);
                    Debug.Log("ans1: " + Question_Answer1);
                    Debug.Log("ans2: " + Question_Answer2);
                    Debug.Log("ans3: " + Question_Answer3);
                    Debug.Log("Correct: " + Question_Correct);
                if(QuestionCorrect){
                    Player3.GetComponent<FollowThePath>().moveAllowed = true;
                }
                else{
                    Player3.GetComponent<FollowThePath>().moveAllowed = false;
                }
                break;
            case 4:
                string getqn = "SELECT * FROM questions WHERE Qn_Number = '" + Dice.QuestionID + "';";
                
                IDbCommand dbcmd = dbconn.CreateCommand();
                dbcmd.CommandText = getqn;
                IDataReader reader = dbcmd.ExecuteReader();
                while(reader.Read())
                {
                    int test = reader.GetInt32(0);
                    Question_Question = reader.GetString(1);
                    Question_Answer1 = reader.GetString(2);
                    Question_Answer2 = reader.GetString(3);
                    Question_Answer3 = reader.GetString(4);
                    Question_Correct = reader.GetString(5);
                    
                }
                    Debug.Log("Qn: " + Question_Question);
                    Debug.Log("ans1: " + Question_Answer1);
                    Debug.Log("ans2: " + Question_Answer2);
                    Debug.Log("ans3: " + Question_Answer3);
                    Debug.Log("Correct: " + Question_Correct);
                if(QuestionCorrect){
                    Player4.GetComponent<FollowThePath>().moveAllowed = true;
                }
                else{
                    Player4.GetComponent<FollowThePath>().moveAllowed = false;
                }
                break;
            case 5:
                string getqn = "SELECT * FROM questions WHERE Qn_Number = '" + Dice.QuestionID + "';";
                
                IDbCommand dbcmd = dbconn.CreateCommand();
                dbcmd.CommandText = getqn;
                IDataReader reader = dbcmd.ExecuteReader();
                while(reader.Read())
                {
                    int test = reader.GetInt32(0);
                    Question_Question = reader.GetString(1);
                    Question_Answer1 = reader.GetString(2);
                    Question_Answer2 = reader.GetString(3);
                    Question_Answer3 = reader.GetString(4);
                    Question_Correct = reader.GetString(5);
                    
                }
                    Debug.Log("Qn: " + Question_Question);
                    Debug.Log("ans1: " + Question_Answer1);
                    Debug.Log("ans2: " + Question_Answer2);
                    Debug.Log("ans3: " + Question_Answer3);
                    Debug.Log("Correct: " + Question_Correct);
                if(QuestionCorrect){
                    Player5.GetComponent<FollowThePath>().moveAllowed = true;
                }
                else{
                    Player5.GetComponent<FollowThePath>().moveAllowed = false;
                }
                break;
            case 6:
                string getqn = "SELECT * FROM questions WHERE Qn_Number = '" + Dice.QuestionID + "';";
                
                IDbCommand dbcmd = dbconn.CreateCommand();
                dbcmd.CommandText = getqn;
                IDataReader reader = dbcmd.ExecuteReader();
                while(reader.Read())
                {
                    int test = reader.GetInt32(0);
                    Question_Question = reader.GetString(1);
                    Question_Answer1 = reader.GetString(2);
                    Question_Answer2 = reader.GetString(3);
                    Question_Answer3 = reader.GetString(4);
                    Question_Correct = reader.GetString(5);
                    
                }
                    Debug.Log("Qn: " + Question_Question);
                    Debug.Log("ans1: " + Question_Answer1);
                    Debug.Log("ans2: " + Question_Answer2);
                    Debug.Log("ans3: " + Question_Answer3);
                    Debug.Log("Correct: " + Question_Correct);
                if(QuestionCorrect){
                    Player6.GetComponent<FollowThePath>().moveAllowed = true;
                }
                else{
                    Player6.GetComponent<FollowThePath>().moveAllowed = false;
                }
                break;
            case 7:
                string getqn = "SELECT * FROM questions WHERE Qn_Number = '" + Dice.QuestionID + "';";
                
                IDbCommand dbcmd = dbconn.CreateCommand();
                dbcmd.CommandText = getqn;
                IDataReader reader = dbcmd.ExecuteReader();
                while(reader.Read())
                {
                    int test = reader.GetInt32(0);
                    Question_Question = reader.GetString(1);
                    Question_Answer1 = reader.GetString(2);
                    Question_Answer2 = reader.GetString(3);
                    Question_Answer3 = reader.GetString(4);
                    Question_Correct = reader.GetString(5);
                    
                }
                    Debug.Log("Qn: " + Question_Question);
                    Debug.Log("ans1: " + Question_Answer1);
                    Debug.Log("ans2: " + Question_Answer2);
                    Debug.Log("ans3: " + Question_Answer3);
                    Debug.Log("Correct: " + Question_Correct);
                if(QuestionCorrect){
                    Player7.GetComponent<FollowThePath>().moveAllowed = true;
                }
                else{
                    Player7.GetComponent<FollowThePath>().moveAllowed = false;
                }
                break;
            case 8:
                string getqn = "SELECT * FROM questions WHERE Qn_Number = '" + Dice.QuestionID + "';";
                
                IDbCommand dbcmd = dbconn.CreateCommand();
                dbcmd.CommandText = getqn;
                IDataReader reader = dbcmd.ExecuteReader();
                while(reader.Read())
                {
                    int test = reader.GetInt32(0);
                    Question_Question = reader.GetString(1);
                    Question_Answer1 = reader.GetString(2);
                    Question_Answer2 = reader.GetString(3);
                    Question_Answer3 = reader.GetString(4);
                    Question_Correct = reader.GetString(5);
                    
                }
                    Debug.Log("Qn: " + Question_Question);
                    Debug.Log("ans1: " + Question_Answer1);
                    Debug.Log("ans2: " + Question_Answer2);
                    Debug.Log("ans3: " + Question_Answer3);
                    Debug.Log("Correct: " + Question_Correct);
                if(QuestionCorrect){
                    Player8.GetComponent<FollowThePath>().moveAllowed = true;
                }
                else{
                    Player8.GetComponent<FollowThePath>().moveAllowed = false;
                }
                break;
            case 9:
                string getqn = "SELECT * FROM questions WHERE Qn_Number = '" + Dice.QuestionID + "';";
                
                IDbCommand dbcmd = dbconn.CreateCommand();
                dbcmd.CommandText = getqn;
                IDataReader reader = dbcmd.ExecuteReader();
                while(reader.Read())
                {
                    int test = reader.GetInt32(0);
                    Question_Question = reader.GetString(1);
                    Question_Answer1 = reader.GetString(2);
                    Question_Answer2 = reader.GetString(3);
                    Question_Answer3 = reader.GetString(4);
                    Question_Correct = reader.GetString(5);
                    
                }
                    Debug.Log("Qn: " + Question_Question);
                    Debug.Log("ans1: " + Question_Answer1);
                    Debug.Log("ans2: " + Question_Answer2);
                    Debug.Log("ans3: " + Question_Answer3);
                    Debug.Log("Correct: " + Question_Correct);
                if(QuestionCorrect){
                    Player9.GetComponent<FollowThePath>().moveAllowed = true;
                }
                else{
                    Player9.GetComponent<FollowThePath>().moveAllowed = false;
                }
                break;
            case 10:
                string getqn = "SELECT * FROM questions WHERE Qn_Number = '" + Dice.QuestionID + "';";
                
                IDbCommand dbcmd = dbconn.CreateCommand();
                dbcmd.CommandText = getqn;
                IDataReader reader = dbcmd.ExecuteReader();
                while(reader.Read())
                {
                    int test = reader.GetInt32(0);
                    Question_Question = reader.GetString(1);
                    Question_Answer1 = reader.GetString(2);
                    Question_Answer2 = reader.GetString(3);
                    Question_Answer3 = reader.GetString(4);
                    Question_Correct = reader.GetString(5);
                    
                }
                    Debug.Log("Qn: " + Question_Question);
                    Debug.Log("ans1: " + Question_Answer1);
                    Debug.Log("ans2: " + Question_Answer2);
                    Debug.Log("ans3: " + Question_Answer3);
                    Debug.Log("Correct: " + Question_Correct);
                if(QuestionCorrect){
                    Player10.GetComponent<FollowThePath>().moveAllowed = true;
                }
                else{
                    Player10.GetComponent<FollowThePath>().moveAllowed = false;
                }
                break;
        }
    }

}
