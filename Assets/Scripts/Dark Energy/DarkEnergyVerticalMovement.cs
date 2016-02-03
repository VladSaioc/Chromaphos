using UnityEngine;
using System.Collections;

//public class DarkEnergyVerticalMovement : MonoBehaviour {
//	public Vector3 speed = new Vector3(0, 0, 0);
//	public float baseSpeed;
//	public float orientation;
//	private float amplitude;
//	public bool switchLock;
	
//	void SwitchMovement()
//	{
//		if (Mathf.Abs (transform.position.y - GetComponentInParent<Transform>().position.y) >= amplitude
//		    && switchLock == false) {
//			switchLock = true;
//			orientation = orientation * (-1);
//			speed.y = speed.y * (-1);
//		}
//		if (switchLock == true &&
//		    Mathf.Abs (transform.position.y) < amplitude - amplitude/10) {
//			switchLock = false;
//		}
//	}
//	void Move ()
//	{
//		transform.position += speed * Mathf.Round (Time.deltaTime * 100) / 100;
//	}
//	
//	// Use this for initialization
//	void Start () {
//		orientation = 1;
//		switchLock = false;
//		//amplitude = transform.localScale.y;
//		speed.y = baseSpeed;
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		SwitchMovement ();
//		Move ();	
////	}
//}