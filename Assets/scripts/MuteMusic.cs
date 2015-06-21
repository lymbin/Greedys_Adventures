using UnityEngine;
using System.Collections;

public class MuteMusic : MonoBehaviour {
	
	static private AudioSource aSource;

	void Awake(){
		aSource = GameObject.FindGameObjectWithTag ("GameScript").GetComponent<AudioSource> ();
	}
	static public void Mute(){
		aSource.mute = !aSource.mute;
	}
}
