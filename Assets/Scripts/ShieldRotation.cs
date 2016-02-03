using UnityEngine;
using System.Collections;

public class ShieldRotation : MonoBehaviour {
	
	public Vector3 rotate = new Vector3();
	public float orientation;
	private int coefIndex;
	public float[] coef;
	private Vector3 basic;
	
	// Use this for initialization
	void Start () {
		basic = rotate;
		rotate.z = rotate.z * orientation;
		coefIndex = GameObject.Find ("Photon").GetComponent<PhotonMovement>().coefIndex;
	}
	
	public void ChangeRotation()
	{
		rotate.z = basic.z * orientation * Mathf.Log10 (coef[coefIndex] + 1);
	}

	// Update is called once per frame
	void Update () { 
		if(Time.timeScale != 0) transform.Rotate(rotate * Time.deltaTime / Time.timeScale);
		coefIndex = GameObject.Find ("Photon").GetComponent<PhotonMovement>().coefIndex;
		ChangeRotation ();
	}
}
