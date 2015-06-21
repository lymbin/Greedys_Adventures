using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

	public float xDistance = 1.0f; // Distance between the x axis the player and the camera when camera follows
	public float yDistance = 1.0f; // Distance between the y axis the player and the camera when camera follows
	public float xSmooth = 8f;	// How smoothly the camera cathes up whis it's target movement in the x axis
	public float ySmooth = 8f;  //How smoothly the camera cathes up whis it's target movement in the y axis
	public Vector2 maxXAndY;		// The maximum x and y coordinates the camera can have.
	public Vector2 minXAndY;		// The minimum x and y coordinates the camera can have.

	private Transform player; // Reference to the player's transform

	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag("player").transform;
	}

	bool CheckX ()
	{
		return Mathf.Abs (transform.position.x - player.position.x) > xDistance;
	}
	bool CheckY ()
	{
		return Mathf.Abs (transform.position.y - player.position.y) > yDistance;
	}


	void FixedUpdate ()
	{
		playerFollow ();
	}

	void playerFollow ()
	{
		// If not hapends set coordinates of the camera by default
		float targetX = transform.position.x;
		float targetY = transform.position.y;

		if (CheckX ())
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);

		if (CheckY ())
			targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);

		// Check targetX and targetY coordinates not get out from the borders
		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

		transform.position = new Vector3 (targetX, targetY, transform.position.z);
	}
}
