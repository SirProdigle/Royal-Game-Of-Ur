using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
	[SerializeField]
	//TODO make some kind of TileManager to handle this
	public Vector3 startPosition;
	public bool Invincible = false;
	public int Team;
	[SerializeField]
	Tile startTile;
	Tile currentTile;
	Tile tileToMoveTo;
	[SerializeField]
	DiceManager diceManager;
	TurnManager turnManager;
	// Use this for initialization
	void Start ()
	{
		diceManager = GameObject.FindObjectOfType<DiceManager> ();
		turnManager = GameObject.FindObjectOfType<TurnManager> ();
		currentTile = null;
		startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnMouseDown ()
	{
		if (diceManager.DiceTotal == 0 && Team == turnManager.PlayerTurn) {
			diceManager.CanMove = false;
			turnManager.NextTurn ();
		}
		if (diceManager.CanMove && Team == turnManager.PlayerTurn) {
			//Go forward x number of tiles in the list
			if (currentTile == null) {
				tileToMoveTo = startTile;
				for (int i = 0; i < diceManager.DiceTotal - 1; i++) {
					tileToMoveTo = tileToMoveTo.GetNextTile (this);
					if (tileToMoveTo == null) {
						//We scored a point. Add 1 and get rid of chip
						Destroy (this.gameObject);
					}
				}
			} else {
				tileToMoveTo = currentTile;
				for (int i = 0; i < diceManager.DiceTotal; i++) {
					tileToMoveTo = tileToMoveTo.GetNextTile (this);
					if (tileToMoveTo == null) {
						//We scored a point. Add 1 and get rid of chip
						//TODO animate going into pile
						Destroy (this.gameObject);
					}
				}
			}
			if (tileToMoveTo.OccupyingChip == null) {
				if (currentTile != null)
					currentTile.OccupyingChip = null;
				currentTile = tileToMoveTo;
				currentTile.OccupyingChip = this;
			} else if (tileToMoveTo.OccupyingChip.Team == this.Team) {
				throw new UnityException ("Can't land on place where we have a chip");
			} else if (tileToMoveTo.OccupyingChip.Team != this.Team) {
				Chip enemyChip = tileToMoveTo.OccupyingChip;
				if (enemyChip.Invincible) {
					//They are on a safe space and we cannot take them
					return;
				}
				enemyChip.transform.position = enemyChip.startPosition;
				enemyChip.currentTile = null;
				tileToMoveTo.OccupyingChip = null;
				if (currentTile != null)
					currentTile.OccupyingChip = null;
				currentTile = tileToMoveTo;
				currentTile.OccupyingChip = this;
			}

			//We have our tile to move to
			Invincible = false;

			//TODO Animation
			StartCoroutine (GoToPosition (tileToMoveTo.transform.position));
			//this.transform.position = tileToMoveTo.transform.position;
			//diceManager.CanMove = false;
			//currentTile.OnChipLand ();
			//turnManager.NextTurn ();
		} else {
			Debug.Log ("Tried to click chip of another player");
		}
	}


	Vector3 velocity = Vector3.zero;
	[SerializeField]
	AudioSource chipUp;
	[SerializeField]
	AudioSource chipDown;

	IEnumerator GoToPosition (Vector3 endPos)
	{
		float smoothTime = 0.5f;
		Vector3 endUpPos = this.transform.position + Vector3.up;
		chipUp.Play ();
		while (this.transform.position != endUpPos) {
			transform.position = Vector3.SmoothDamp (this.transform.position, endUpPos, ref velocity, smoothTime / 8);
			yield return null;
		}
		while (this.transform.position != endPos + Vector3.up) {
			transform.position = Vector3.SmoothDamp (this.transform.position, endPos + Vector3.up, ref velocity, smoothTime / 4);
			yield return null;
		}
		while (this.transform.position != endPos) {
			transform.position = Vector3.SmoothDamp (this.transform.position, endPos, ref velocity, smoothTime / 8);
			yield return null;
		}
		chipDown.Play ();
		diceManager.CanMove = false;
		currentTile.OnChipLand ();
		turnManager.NextTurn ();
	}
}
