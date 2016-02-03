using UnityEngine;
using System.Collections;

public class DarkEnergyStretchVertical : MonoBehaviour {

	public Vector3 speed = new Vector3(0, 0, 0);
	public float baseSpeed;
	public float orientation;
	public float amplitude;
	public bool switchLock;
	
	void SwitchMovement()
	{
		if (Mathf.Abs (transform.localScale.y) >= amplitude
		    && switchLock == false) {
			switchLock = true;
			orientation = orientation * (-1);
			speed.y = speed.y * (-1);
		}
		if (switchLock == true &&
		    Mathf.Abs (transform.localScale.y) < amplitude - amplitude/10) {
			switchLock = false;
		}
	}
	void Move ()
	{
		transform.localScale += speed * Mathf.Round (Time.deltaTime * 100) / 100 / Time.timeScale;
	}

	// Use this for initialization
	void Start () {
		orientation = 1;
		switchLock = false;
		amplitude = transform.localScale.y;
		speed.y = amplitude * baseSpeed;
	
	}
	
	// Update is called once per frame
	void Update () {
		SwitchMovement ();
		Move ();	
	}
}
