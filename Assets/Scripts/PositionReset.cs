using UnityEngine;
using System.Collections;

public class PositionReset : MonoBehaviour {

	public float threshold;
	public Vector3 start;
	public bool resetCheck;

	// Use this for initialization
	void Start () {
		resetCheck = false;
	}

	void Cycle()
	{
		start.x = transform.position.x;
		start.z = transform.position.z;
		transform.position = start;
		resetCheck = true;
	}
	
	// Update is called once per frame
	void Update () {		
		if (resetCheck)
			resetCheck = false;
		if (transform.position.y > threshold) {
			Cycle ();
		}
	}
}
