using UnityEngine;
using System.Collections;

public class VerticalPendulum : MonoBehaviour {
	public Vector3 speed = new Vector3(0, 0, 0);
	public float baseSpeed;
	public float orientation;
	public float modifier;
	public float amplitude;
	private float t = 0;
	
	// Use this for initialization
	void Start () {
		t = 0;
		if (orientation == 0f)
			orientation = 1;
		//	transform.localPosition = speed;
		speed.y = baseSpeed * orientation;
	}
	
	void SwitchMovement()
	{
		if (Mathf.Abs (transform.localPosition.y) >= amplitude) {
			Vector3 newPos = transform.localPosition;
			newPos.y = amplitude * orientation - 0.001f * orientation;
			transform.localPosition = newPos;
			orientation = orientation * (-1);
			speed.y = speed.y * (-1);
		}
	}
	void Move ()
	{
		//Vector3 temp = speed* modifier;
		//temp.y = temp.y * (0.01f + 0.999f * (amplitude - Mathf.Abs(transform.localPosition.y))) / 10;
		transform.localPosition += speed * Mathf.Round (Time.deltaTime * 100) / 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (t < 0.5f)
			t += Time.deltaTime;
		if(t>=0.5f) Move ();
		SwitchMovement ();
	}
}
