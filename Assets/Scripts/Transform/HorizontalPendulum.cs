using UnityEngine;
using System.Collections;

public class HorizontalPendulum : MonoBehaviour {
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
		speed.x = baseSpeed * modifier * orientation;
	}
	
	void SwitchMovement()
	{
		if (Mathf.Abs (transform.localPosition.x) >= amplitude) {
			Vector3 newPos = transform.localPosition;
			newPos.x = amplitude * orientation - 0.001f * orientation;
			transform.localPosition = newPos;
			orientation = orientation * (-1);
			speed.x = speed.x * (-1);
		}
	}
	void Move ()
	{
		Vector3 temp = speed;
		temp.x = temp.x * (1 + 0.9f * (amplitude - Mathf.Abs(transform.localPosition.x))) / 10;
		transform.localPosition += temp * Mathf.Round (Time.fixedDeltaTime * 100) / 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (t < 0.5f)
			t += Time.fixedDeltaTime;
		if(t>=0.5f) Move ();
		SwitchMovement ();
	}
}
