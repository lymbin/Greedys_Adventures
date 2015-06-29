using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsToggle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//GetComponent<Toggle> ().onValueChanged.
		GetComponent<Toggle> ().onValueChanged.AddListener (GameManager.instance.OnValueChanged);
	}

}
