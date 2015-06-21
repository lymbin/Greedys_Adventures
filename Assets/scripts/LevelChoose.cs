using UnityEngine;
using System.Collections;

public class LevelChoose : MonoBehaviour {

	public int level;
	public Game gameClass;

	private bool isActive;

	// Use this for initialization
	void Start () {
		if (!gameClass)
			gameClass = GameObject.FindGameObjectWithTag ("GameScript").GetComponent<Game>();
	}
	void Update () {

	}

	void OnMouseDown(){

		if (level > gameClass.currentLevel)
			return;

		switch (level) {
		case 1: 
		case 2:
		case 4: 
		case 5:
		case 6: 
		case 7:
		case 8: 
		case 9:
		case 10:
			break;
		}
	}
	
	void OnMouseEnter() {

	}
	void OnMouseOver() {
		
	}
	void OnMouseExit() {

	}


}
