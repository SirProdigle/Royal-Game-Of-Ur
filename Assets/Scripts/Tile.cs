using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
	[SerializeField]
	protected Tile nextTile;

	public Chip OccupyingChip {
		get;
		set;
	}
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public virtual Tile GetNextTile (Chip c)
	{
		return nextTile;
	}

	public virtual void OnChipLand ()
	{
		return;
	}
}
