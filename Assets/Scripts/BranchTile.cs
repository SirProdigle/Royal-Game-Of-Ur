using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchTile : Tile {
	[SerializeField]
	private Tile nextTileP1;
	[SerializeField]
	private Tile nextTileP2;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public override Tile GetNextTile (Chip c)
	{
		if (c.Team == 1) {
			return nextTileP1;
		} else {
			return nextTileP2;
		}
	}
}
