using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;




[System.Serializable]
public class Game : MonoBehaviour {

	public int currentLevel = 0;

	public bool isCenzored = true;
	public bool isOpenSecret = false;

	public Toggle cenzoredToggle;

	// Use this for initialization
	void Start () {
		LoadGame ();
		if (cenzoredToggle)
			cenzoredToggle.isOn = isCenzored;
	}

	void LoadGame () {
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

	}

	public void OnValueChanged(bool Next){
		isCenzored = Next;
	}
}
