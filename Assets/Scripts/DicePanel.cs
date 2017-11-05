using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicePanel : MonoBehaviour {

	[SerializeField]
	//TODO when at home, change this to a panel of images and get dice pictures for the rolls
	Text diceText;
	DiceManager diceRoller;
	//Maybe need to have 2 for 2 player support

	// Use this for initialization
	void Start ()
	{
		diceRoller = GameObject.FindObjectOfType<DiceManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		diceText.text = diceRoller.DiceTotal.ToString ();
	}
}
