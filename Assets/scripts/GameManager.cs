using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int currentLevel = 0;
	
	public bool isCenzored = true;
	public bool isOpenSecret = false;
	
	public Toggle cenzoredToggle;
	public GameObject MiniMenuPage;
	
	// Use this for initialization
	void Start () {
		LoadGame ();
		if (cenzoredToggle)
			cenzoredToggle.isOn = isCenzored;
	}
	
	void LoadGame () {
		if(currentLevel == 0)
			currentLevel = PlayerPrefs.GetInt ("LevelCount");

		int cenzor = PlayerPrefs.GetInt("IsCenzored");

		if (cenzor == 0)
			isCenzored = false;
		else
			isCenzored = true;
	}
	
	void SaveGame () {
		PlayerPrefs.SetInt ("LevelCount", currentLevel);
		
		if(!isCenzored)
			PlayerPrefs.SetInt("IsCenzored", 0);
		else
			PlayerPrefs.SetInt("IsCenzored", 1);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(MiniMenuPage){
				MiniMenuPage.SetActive(!MiniMenuPage.activeInHierarchy);
			}
		}
	}

	void OnDestroy(){
		SaveGame ();
	}
	
	public void OnValueChanged(bool Next){
		isCenzored = Next;
	}
}
