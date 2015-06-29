using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource musicSource;
	public AudioSource sfxSource;

	static public SoundManager instance = null;

	void Awake(){
		if (!instance)
			instance = this;
		else if(instance != this) {
			Destroy(instance);
			instance = this;
		}

		DontDestroyOnLoad (gameObject);
		
	}
	public void PlayMusic(AudioClip clip){
		if (musicSource.clip != clip) {
			musicSource.clip = clip;
			musicSource.Play ();
		}
	}

	public void PlaySingle(AudioClip clip){
		sfxSource.clip = clip;

		sfxSource.Play ();

	}
	public void RandimizeSFX(params AudioClip[] clips){

		int randomIndex = Random.Range (0, clips.Length);

		sfxSource.clip = clips [randomIndex];

		sfxSource.Play ();
	}

	static public void MuteMusic(){
		Debug.Log("MuteMusic");
		instance.musicSource.mute = !instance.musicSource.mute;
	}

	static public void SetMusicVolume(float value){
		instance.musicSource.volume = value;
	}
}