using UnityEngine;
using System.Collections;

public enum eButtonType {Exit, NewGame, Back, Settings, Shop, Secret, Mute, MainMenu};

public class OnButton : MonoBehaviour {
	
	public eButtonType type;

	public GameObject OnClickPage;
	public GameObject CurrentPage;

	public Sprite OnMouseEnterSprite;
	public Sprite OnMouseExitSprite;

	private SpriteRenderer spriteRenderer;

	void Awake() {
		if(OnMouseExitSprite && OnMouseEnterSprite)
			spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		if(!CurrentPage)
			CurrentPage = transform.parent.gameObject;
	}

	void OnDisable(){
		if(spriteRenderer)
			spriteRenderer.sprite = OnMouseExitSprite;
	}
	
	void OnMouseDown(){

		if (type == eButtonType.Exit) {
			Application.Quit ();
			return;

		} else if (type == eButtonType.Mute) {
			MuteMusic.Mute ();
			return;
		} else if (type == eButtonType.MainMenu) {

			Application.LoadLevel(0);
		}
		pageChanger.ChangePage (CurrentPage, OnClickPage);
	}

	void OnMouseEnter() {
		if(spriteRenderer)
			spriteRenderer.sprite = OnMouseEnterSprite;
	}
	void OnMouseOver() {

	}
	void OnMouseExit() {
		if(spriteRenderer)
			spriteRenderer.sprite = OnMouseExitSprite;
	}
}
