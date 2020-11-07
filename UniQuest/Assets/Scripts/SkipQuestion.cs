using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipQuestion : MonoBehaviour
{
    
    void Start()
    {
        
    }

  
    public void Skip()
    {
        Debug.Log("Skipped");
        Dice.QuestionID++;
        if(Dice.QuestionID >= Dice.numberofquestions){
            Dice.QuestionID = 1;
        }
        GameControl.AskQuestion();
    }

}
