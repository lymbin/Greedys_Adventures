using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Texture2D backgroundTexture;
	public const int mainMenuWidth = 200;

	public Game gameClass;

	private int menuType = 0;

	// Use this for initialization
	void Start () {
		if (!gameClass)
			gameClass = GameObject.FindGameObjectWithTag ("GameScript").GetComponent<Game>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (backgroundTexture != null)
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);

		switch (menuType) {
		case 0: drawNewGameScreen();
			break;
		case 1: drawLevelChooserScreen();
			break;
		case 2: drawSettingsScreen();
			break;
		default:
			break;
		}
	}

	void drawNewGameScreen(){

		GUI.BeginGroup (new Rect (Screen.width / 2 - mainMenuWidth/2, Screen.height - 180, mainMenuWidth, 240));

		if(GUI.Button(new Rect(0, 40, mainMenuWidth, 30) , "New Game")){
			menuType = 1;
		}
		
		if(GUI.Button(new Rect(0, 80, mainMenuWidth, 30) , "Settings")){
			menuType = 2;
		}
			
		if(GUI.Button(new Rect(0, 120, mainMenuWidth, 30) , "Exit")){
				Application.Quit();
		}
			
		GUI.EndGroup();	
	}

	void drawLevelChooserScreen(){
	
	}

	void drawSettingsScreen(){
	
	}
}
