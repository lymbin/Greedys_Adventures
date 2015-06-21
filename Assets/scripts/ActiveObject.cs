using UnityEngine;
using System.Collections;

public enum activeObjectType{none, ladder, torch, choose, enter};

public class ActiveObject : MonoBehaviour {

	public activeObjectType type;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "player") {
			Transform player = other.gameObject.transform;
			player.gameObject.GetComponent<HeroController>().activeObject = this.gameObject;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.tag == "player") {
			Transform player = other.gameObject.transform;
			player.gameObject.GetComponent<HeroController>().activeObject = null;
		}
	}
}
