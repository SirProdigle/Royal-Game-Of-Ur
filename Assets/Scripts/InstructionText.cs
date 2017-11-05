using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionText : MonoBehaviour {
	Text t;
	DiceManager dm;
	TurnManager tm;
	// Use this for initialization
	void Start ()
	{
		dm = GameObject.FindObjectOfType<DiceManager> ();
		tm = GameObject.FindObjectOfType<TurnManager> ();
		t = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Get vars;
		int playerTurn = tm.PlayerTurn;
		bool readyToMove = dm.CanMove;
		string textToShow;
		if (playerTurn == 1) {
			textToShow = "Player 1: ";
			t.color = Color.red;
		} else {
			textToShow = "Player 2: ";
			t.color = Color.blue;
		}

		if (readyToMove) {
			textToShow += "Click a Chip to move!";
		} else {
			textToShow += "Roll the dice!";
		}

		t.text = textToShow;
	}
}
