﻿using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn = 1;
    private bool coroutineAllowed = true;

	// Use this for initialization
	private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
	}

    private void OnMouseDown()
    {
        //Debug.Log("clicked rollbutton");
        //if (!GameControl.gameOver && coroutineAllowed)
        if (coroutineAllowed)
            StartCoroutine("RollTheDice");

    }

    private IEnumerator RollTheDice()
    {
        
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            // rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1;
        if (whosTurn == 1)
        {
            
            //  GameControl.coloureddice(1, randomDiceSide);
            //GameControl.diceSideThrown = randomDiceSide + 1;
            // GameControl.AskQuestion(1);
            Debug.Log(randomDiceSide + 1);
            GameControl.MovePlayer(1);

        } else if (whosTurn == -1)
        {
            
            // GameControl.coloureddice(2, randomDiceSide);
            //GameControl.diceSideThrown = randomDiceSide + 1;
            Debug.Log(randomDiceSide + 1);
            // GameControl.AskQuestion(2);
            GameControl.MovePlayer(2);
        }
        whosTurn *= -1;
        coroutineAllowed = true;
    }
}