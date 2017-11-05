using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

	public int[] DiceRolls {
		get;
		set;
	}

	public int DiceTotal {
		get {
			return DiceRolls [0] + DiceRolls [1] + DiceRolls [2] + DiceRolls [3];
		}
	}

	public bool CanMove {
		get;
		set;
	}


	// Use this for initialization
	void Start ()
	{
		DiceRolls = new int[4]{ 0, 0, 0, 0 };
		CanMove = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void RollDice ()
	{
		//Check to stop re-rolling the same dice on the same turn
		if (CanMove == false) {
			for (int i = 0; i < DiceRolls.Length; i++) {
				DiceRolls [i] = Random.Range (0, 2);
			}
			Debug.Log ("Dice: " + DiceRolls [0] + " " + DiceRolls [1] + " " + +DiceRolls [2] + " " + DiceRolls [3] + " " + " (" + DiceTotal + ")");
			CanMove = true;
		}
	}
}
