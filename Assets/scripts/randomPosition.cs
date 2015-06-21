using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class randomPosition : MonoBehaviour {

	public float minX = -9f, maxX = 9f;
	public float minY = -4.5f, maxY = 4.5f;
	private Vector3 Position;

	void Awake () {
		Position = transform.position;

		Position.x = Random.Range (minX, maxX);
		Position.y = Random.Range (minY, maxY);

		transform.position = Position;
	}

}
