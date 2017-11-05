using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

	public int PlayerTurn {
		get;
		protected set;
	}

	public bool RepeatTurn = false;
	// Use this for initialization
	void Start ()
	{
		PlayerTurn = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void NextTurn ()
	{
		if (RepeatTurn) {
			RepeatTurn = false;
			return;
		}
		if (PlayerTurn == 1) {
			PlayerTurn = 2;
		} else {
			PlayerTurn = 1;
		}
	}
}
