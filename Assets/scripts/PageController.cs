using UnityEngine;
using System.Collections;

public class PageController : MonoBehaviour {

	public GameObject FirstPage;
	public AudioClip OnChageMusic;
	private AudioSource asource;
	void Awake(){

		if (!FirstPage || FirstPage != gameObject) {
			gameObject.SetActive (false);
		}

		asource = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<AudioSource>();			
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
		if(currentPage)
			currentPage.SetActive(false);
		if(nextPage)
			nextPage.SetActive(true);

	}
}
