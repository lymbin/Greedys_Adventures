using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax;
}
[System.Serializable]
public class Sides{
	public string sortingLayerLeft, sortingLayerRight;
}
public class HeroController : MonoBehaviour {

	[HideInInspector]
	public bool jump = false; // If player need jump

	[HideInInspector]
	public bool isFacingRight = true;
	
	private bool isActivated = false;

	//[HideInInspector]
	public GameObject activeObject = null;

    public float speed;	// Movement speed
	public float jumpForce = 1000f; // Speed of jump or how higher we can jump 
	public float moveForce = 100f;
	public float groundRadius = 1f;
	public LayerMask groundMask;

	public Boundary boundary;	// Bound of our world
	public Sides sides;
	
	private Transform groundCheck; // Reference to groundCheck
	
	private bool isGrounded = false; // If player on ground

	private Animator anim;
	
	void Start ()
	{
		anim = GetComponent<Animator> ();
	}
	void Awake () 
	{
		// Set reference to groundCheck
		groundCheck =transform.Find("groundCheck");
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.E))
			ActivateObject ();


		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundMask);
		anim.SetBool ("Ground", isGrounded);

		// Jumping checker
		if (isGrounded && Input.GetButtonDown ("Jump")) 
		{
			anim.SetBool ("Ground", false);
			jump = true;
		}

		if (!activeObject && isActivated) {

				isActivated = false;

			if(GetComponent<Rigidbody2D> ().isKinematic)
				GetComponent<Rigidbody2D> ().isKinematic = false;
		}




	}

	void FixedUpdate () 
	{
		float MoveH;
		
		MoveH = Input.GetAxis("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (MoveH));

		//Other movement system with shitty move set.
		// Игрок двигается как по мылу и не движется при небольшом нажатии на кнопку
		/*if (!jump && MoveH * GetComponent<Rigidbody2D>().velocity.x < speed)
				GetComponent<Rigidbody2D>().AddForce (Vector2.right * MoveH * moveForce);

		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > speed)
			GetComponent<Rigidbody2D>().velocity = new Vector2 (Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * speed, GetComponent<Rigidbody2D>().velocity.y);
		*/

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (MoveH * speed, GetComponent<Rigidbody2D> ().velocity.y);

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
		GetComponent<Rigidbody2D>().position = new Vector2
		(
			Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
		);

		if (MoveH > 0 && !isFacingRight)
			Flip ();
		else if (MoveH < 0 && isFacingRight)
			Flip ();

		if (jump) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}

	private void Flip ()
	{
		isFacingRight = !isFacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

		GameObject[] items = GameObject.FindGameObjectsWithTag("PlayersItems");
		foreach(GameObject item in items){
			if(item.GetComponent<SpriteRenderer>().sortingLayerName == sides.sortingLayerLeft)
			{
				item.GetComponent<SpriteRenderer>().sortingLayerName = sides.sortingLayerRight;
			}
			else if(item.GetComponent<SpriteRenderer>().sortingLayerName == sides.sortingLayerRight)
			{
				item.GetComponent<SpriteRenderer>().sortingLayerName = sides.sortingLayerLeft;
			}
		}
	}
	private void ActivateObject ()
	{
		if(!activeObject)
			return;

		if (activeObject.GetComponent<ActiveObject> ().type == activeObjectType.ladder) {
			if(!isActivated){
				isActivated = true;
				GetComponent<Rigidbody2D> ().isKinematic = true;
			}
			else
			{
				isActivated = false;
				GetComponent<Rigidbody2D> ().isKinematic = false;
			}

		}

	}
}
