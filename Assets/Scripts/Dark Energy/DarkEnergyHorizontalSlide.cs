using UnityEngine;
using System.Collections;

public class DarkEnergyHorizontalSlide : MonoBehaviour {

	public Vector3 slideSpeed;
	private Vector3 startLocation;
	public float amplitude;

	// Use this for initialization
	void Start () {
		startLocation.y = transform.localPosition.y;
		startLocation.x = amplitude;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += slideSpeed * Time.deltaTime;
		if (transform.localPosition.x < -amplitude)
			transform.localPosition = startLocation;
	}
}
