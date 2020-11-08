using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallErr : MonoBehaviour
{
    public static GameObject Err01, Err02, Err03, Err04;

    
    void Start()
    {
        Err01 = GameObject.Find("Err01");
        Err02 = GameObject.Find("Err02");
        Err03 = GameObject.Find("Err03");
        Err04 = GameObject.Find("Err04");

        Err01.GetComponent<UnityEngine.UI.Text>().text = "Err01: Number found in Question or Answers. Please see User & Installation Manual for help.";
        Err02.GetComponent<UnityEngine.UI.Text>().text = "Err02: Syntax Error. Please see User & Installation Manual for help.";
        Err03.GetComponent<UnityEngine.UI.Text>().text = "Err03: There was an issue removing the question. Please see User & Installation Manual for help.";
        Err04.GetComponent<UnityEngine.UI.Text>().text = "Err04: Please select an item to remove. Please see User & Installation Manual for help.";

        Err01.gameObject.SetActive(false);
        Err02.gameObject.SetActive(false);
        Err03.gameObject.SetActive(false);
        Err04.gameObject.SetActive(false);

    }

    public static void Error1(string message){
        
        Err01 = GameObject.Find("Err01");
//Err01.gameObject.SetActive(true);
        Err01.GetComponent<UnityEngine.UI.Text>().text = message;
        
    }

    public static void Error2(string message){
        
        Err02 = GameObject.Find("Err02");
       // Err02.gameObject.SetActive(true);
        Err02.GetComponent<UnityEngine.UI.Text>().text = message;
        
    }

    public static void Error3(string message){
        
        Err03 = GameObject.Find("Err03");
        //Err03.gameObject.SetActive(true);
        Err03.GetComponent<UnityEngine.UI.Text>().text = message;
        
    }

    public static void Error4(string message){
        
        Err04 = GameObject.Find("Err04");
      //  Err04.gameObject.SetActive(true);
        Err04.GetComponent<UnityEngine.UI.Text>().text = message;
        
    }
    

    

}
