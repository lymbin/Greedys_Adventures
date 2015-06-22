using UnityEngine;
using System.Collections;

public class LevelChoose : MonoBehaviour {

	public int level;
	public GameManager gameClass;

	public GameObject levelLock;

	private bool isActive;


	void Awake () {
		if (!gameClass)
			gameClass = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();

		if (level > gameClass.currentLevel) {
			if(levelLock){
				levelLock = Instantiate(levelLock, transform.position, Quaternion.identity) as GameObject;
				levelLock.transform.SetParent(transform);
			}
		}
	}

	void Update () {

	}

	void OnMouseDown(){

		print(gameClass.currentLevel);


		if (level > gameClass.currentLevel)
			return;

		string LevelName = "level" + level;
		Application.LoadLevel (LevelName);
	}
	
	void OnMouseEnter() {

	}
	void OnMouseOver() {
		
	}
	void OnMouseExit() {

	}


}
