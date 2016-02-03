using UnityEngine;
using System.Collections;

public class MenuCameraMovement : MonoBehaviour {

	private Vector3 location;
	private Vector3 destination;
	private float timer;
	public float duration;

	// Use this for initialization
	void Start () {
		timer = 1;
		location = transform.position;
	}

	public void MoveCamera (Vector3 dest)
	{
		timer = 0;
		location = transform.position;
		destination = dest;
	}

	void Update()
	{		
		if (timer < 1) {
			timer += Mathf.Floor (Time.deltaTime * 1000)/ duration / 1000;
			transform.position = Vector3.Lerp(location, destination, timer);
		} else
			timer = 1;
	}
}
