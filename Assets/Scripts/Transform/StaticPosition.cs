using UnityEngine;
using System.Collections;

public class StaticPosition : MonoBehaviour {

	private Vector3 staticPosition;

	// Use this for initialization
	void Start () {
		staticPosition = transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = staticPosition;	
	}
}
