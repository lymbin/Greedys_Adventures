using UnityEngine;
using System.Collections;

public class PageController : MonoBehaviour {

	public GameObject FirstPage;
	public AudioClip OnChageMusic;

	void Awake(){
		if (!FirstPage || FirstPage != gameObject) {
			gameObject.SetActive (false);
		}
	}

	void Start(){
		if(gameObject.activeInHierarchy)
			if(OnChageMusic)
				SoundManager.instance.PlayMusic (OnChageMusic);
	}

	void OnEnable(){
		if(OnChageMusic)
			SoundManager.instance.PlayMusic (OnChageMusic);
	}

	void OnDisable(){

	}
}

public class pageChanger{
	
	public static void ChangePage(GameObject currentPage, GameObject nextPage){
		if(currentPage)
			currentPage.SetActive(false);
		if(nextPage)
			nextPage.SetActive(true);

	}
}
