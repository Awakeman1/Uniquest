using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections; 
using System.Collections.Generic;
using System.IO;

public class GameControl : MonoBehaviour {

    //private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;
    private static GameObject player1, player2;
    private static GameObject Mcamera;
   
    //private static GameObject MainOverlay, QuestionOverlay, QuestionOverlay2, Wrong, Right;
    //private static GameObject qPrompt, qPrompt2;
    //public static GameObject qTrue, qFalse;
    //public static Button qTrue, qFalse, qTrue2, qFalse2;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gameOver = false;
    public int NumberofPlayers;

    // public static string DiceColour;

    //public static List<string> questionlist = new List<string>();
    //public static List<string> answerlist = new List<string>();

    // Use this for initialization

    void Start () {
        NumberofPlayers = MainMenu.NumPlayers;
        Debug.Log("OnStart, " + NumberofPlayers +" players");
        //whoWinsTextShadow = GameObject.Find("WhoWinsText");
        //player1MoveText = GameObject.Find("Player1MoveText");
        //player2MoveText = GameObject.Find("Player2MoveText");
        Mcamera = GameObject.Find("MainCamera");


        Mcamera.SetActive(false);
        Mcamera.GetComponent<AudioListener>().enabled = false;
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player1.SetActive(true);
        player2.SetActive(true);
        enablePlayerCamera(player1);
        disablePlayerCamera(player2);
        
        
        //MainOverlay = GameObject.Find("Canvas");
        //Wrong = GameObject.Find("wrong");
        //Right = GameObject.Find("right");

        //QuestionOverlay = GameObject.Find("Question");
        //qPrompt = GameObject.Find("qPrompt");
        //qTrue = GameObject.Find("qTrue").GetComponent<Button>();
        //qFalse = GameObject.Find("qFalse").GetComponent<Button>();

        //QuestionOverlay2 = GameObject.Find("Question2");
        //qPrompt2 = GameObject.Find("qPrompt2");
        //qTrue2 = GameObject.Find("qTrue2").GetComponent<Button>();
        //qFalse2 = GameObject.Find("qFalse2").GetComponent<Button>();



        //MainOverlay.SetActive(true);        
        //QuestionOverlay.SetActive(false);
        //QuestionOverlay2.SetActive(false);
        //Wrong.SetActive(false);
        //Right.SetActive(false);

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

        //whoWinsTextShadow.gameObject.SetActive(false);
        //player1MoveText.gameObject.SetActive(true);
        //player2MoveText.gameObject.SetActive(false);

        
        //ReadTextFile();
        
        


    }

   

    // Update is called once per frame
    void Update()
    {
            

        if (player1.GetComponent<FollowThePath>().waypointIndex > player1StartWaypoint + diceSideThrown)
        {
            Debug.Log(player1.GetComponent<FollowThePath>().waypointIndex -1);
            
            switch(player1.GetComponent<FollowThePath>().waypointIndex -1){
            case 5:
                rollagain(1);
                break;
            case 8:
                portal(1, 13);
                break;
            case 14:
                rollagain(1);
                break;
            case 18:
                rollagain(1);
                break;
            case 24:
                rollagain(1);
                break; 
            case 26:
                portal(1, 30);
                break;
            default:
                player1.GetComponent<FollowThePath>().moveAllowed = false;
                Debug.Log("Test");
                player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
                enablePlayerCamera(player2);
                disablePlayerCamera(player1);
                break;
        }
           // player1MoveText.gameObject.SetActive(false);
            //player2MoveText.gameObject.SetActive(true);
            
            
        }
       


      
        if (player2.GetComponent<FollowThePath>().waypointIndex > player2StartWaypoint + diceSideThrown)
        {
            Debug.Log(player1.GetComponent<FollowThePath>().waypointIndex -1);
            
            switch(player2.GetComponent<FollowThePath>().waypointIndex -1){
            case 5:
                rollagain(2);
                break;
            case 8:
                portal(2, 13);
                break;
            case 14:
                rollagain(2);
                break;
            case 18:
                rollagain(2);
                break;
            case 24:
                rollagain(1);
                break; 
            case 26:
                portal(2, 30);
                break;
            default:
                player2.GetComponent<FollowThePath>().moveAllowed = false;
                
                player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
                enablePlayerCamera(player1);
                disablePlayerCamera(player2);
                break;
        }      
        
     }
       

//if p1's position is the last in the waypoint array, p1 wins
//         if (player1.GetComponent<FollowThePath>().waypointIndex == player1.GetComponent<FollowThePath>().waypoints.Length)
//         {
//             //string winner = "Player 1";
//            // gameend(winner);
//         }

// //if p2's position is the last in the waypoint array, p2 wins
//         if (player2.GetComponent<FollowThePath>().waypointIndex ==  player2.GetComponent<FollowThePath>().waypoints.Length)
//         {
//             //string winner = "Player 2";
//             //gameend(winner);
//         }

       
    }


    public static void disablePlayerCamera(GameObject player){
        player.transform.GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(0).gameObject.GetComponent<AudioListener>().enabled = false;
    }

    public static void enablePlayerCamera(GameObject player){
        player.transform.GetChild(0).gameObject.SetActive(true);
        player.transform.GetChild(0).gameObject.GetComponent<AudioListener>().enabled = false;
    }

    public static void disableGlobalCamera(){
        Mcamera.SetActive(false);
    }
    public static void enableGlobalCamera(){
        Mcamera.SetActive(true);
    }


    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) { 
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }
    

    



    public static void rollagain(int playerToMove){
        switch (playerToMove) { 
            case 1:
                Debug.Log("Apparently Player 1 Should roll again.");
                break;

            case 2:
                Debug.Log("Apparently Player 2 Should roll again.");
                break;
            default:
                Debug.Log("Someone gets to roll again, But I have no clue who... ");
                break;
        }
    }


    public static void portal(int playerToMove, int destination){
      switch (playerToMove){
        case 1:
          Debug.Log("Player 1 entered a portal. their destination is: " + destination);
          break;
        case 2:
          Debug.Log("Player 1 entered a portal. their destination is: " + destination);
          break;
        default:          
          Debug.Log("We've entered a portal. Wow. Dunno who or where though");
          break;
      }
    }


    // public static void gameend(string winner){
    //     whoWinsTextShadow.gameObject.SetActive(true);
    //     player1MoveText.gameObject.SetActive(false);
    //     player2MoveText.gameObject.SetActive(false);
    //     whoWinsTextShadow.GetComponent<Text>().text = winner + " Wins";
    //     gameOver = true;
    // }

}
