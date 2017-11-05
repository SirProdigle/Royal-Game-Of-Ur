using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTile : Tile {

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public override void OnChipLand ()
	{
		GameObject.FindObjectOfType<TurnManager> ().RepeatTurn = true;
	}
}
