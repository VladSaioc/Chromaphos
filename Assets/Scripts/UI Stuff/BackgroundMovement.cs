using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	Vector3 newV;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newV = GameObject.Find ("Photon").transform.position;
		newV.x = newV.x / 5;
		transform.position = newV;
	}
}
