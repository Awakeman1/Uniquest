using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipQuestion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    public void Skip()
    {
        Debug.Log("Skipped");
        Dice.QuestionID++;
        GameControl.AskQuestion();
    }

}
