using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int openedLevel = 0;
	
	public bool isCenzored = true;
	public bool isOpenSecret = false;

	public GameObject MenuPage;

	public static GameManager instance = null;

	void Awake () {

		if (!instance)
			instance = this;
		else if(instance != this){
			Destroy(instance);
			instance = this;
		}

		DontDestroyOnLoad (gameObject);

		LoadGame ();
	}
	
	void LoadGame () {
		// temporary use this for tests
		if(openedLevel == 0)
			openedLevel = PlayerPrefs.GetInt ("LevelCount");

		int cenzor = PlayerPrefs.GetInt("IsCenzored");

		if (cenzor == 0)
			isCenzored = false;
		else
			isCenzored = true;
	}
	
	void SaveGame () {
		PlayerPrefs.SetInt ("LevelCount", openedLevel);
		
		if(!isCenzored)
			PlayerPrefs.SetInt("IsCenzored", 0);
		else
			PlayerPrefs.SetInt("IsCenzored", 1);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(MenuPage){
				MenuPage.SetActive(!MenuPage.activeInHierarchy);
			}
		}
	}

	void OnDestroy(){
		SaveGame ();
	}
	
	public void OnValueChanged(bool value){
		isCenzored = value;
	}
}
