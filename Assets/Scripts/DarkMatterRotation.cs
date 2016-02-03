using UnityEngine;
using System.Collections;

public class DarkMatterRotation : MonoBehaviour {
	
	public Vector3 rotate = new Vector3();
	public float orientation;
	public bool aesthetic;
	
	// Use this for initialization
	void Start () {
		rotate.z = rotate.z * orientation;
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Collider2D>() != null || aesthetic == true)
		if(Time.timeScale != 0) transform.Rotate(rotate * Time.deltaTime / Time.timeScale);		
	}
}
