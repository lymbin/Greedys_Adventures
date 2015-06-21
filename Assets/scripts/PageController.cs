using UnityEngine;
using System.Collections;

public class PageController : MonoBehaviour {

	public GameObject FirstPage;
	public AudioClip OnChageMusic;
	private AudioSource asource;
	void Awake(){

		if (FirstPage && FirstPage != gameObject) {
			gameObject.SetActive (false);
		} 

		asource = GameObject.FindGameObjectWithTag ("GameScript").GetComponent<AudioSource>();			
	}

	void OnEnable(){
		if (OnChageMusic) {
			if(asource.clip != OnChageMusic){
				asource.clip = OnChageMusic;
				asource.Play();
			}		
		}	
	}

	void OnDisable(){

	}
}

public class pageChanger{
	
	public static void ChangePage(GameObject currentPage, GameObject nextPage){
		currentPage.SetActive(false);
		nextPage.SetActive(true);

	}
}
