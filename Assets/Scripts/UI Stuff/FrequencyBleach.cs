using UnityEngine;
using System.Collections;

public class FrequencyBleach : MonoBehaviour {
	public Color[] nuances;
	public float transition;
	public int coef;
	private float t;
	private float index;
	private bool locked;


	// Use this for initialization
	void Start () {
		index = - 1;
		t = 1;
		locked = true;
	}

	public float GetT() {
		return t;
	}

	void CheckTransition()
	{
		if(locked == false
		   && GameObject.Find ("Photon").GetComponent<PhotonMovement> ().coefIndex != coef
		   && GameObject.Find ("Photon").GetComponent<PhotonMovement> ().newCoefIndex != coef)
		{
			locked = true;
			t = 1;
			index = -1;
		}
	}

	public void ChangeColor()
	{
		//if (GameObject.Find ("Photon").GetComponent<Movement> ().coefIndex == transform.GetComponent<FrequencySelector> ().GetCoef ()) {
		index = 1;
		t = 0;
		locked = false;
		if(GetComponent<AudioSource>() != null) {
			GetComponent<AudioSource>().Play();
		}
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Renderer>().material.color = Color.Lerp (nuances [0], nuances [1], t);
		if (t >= 0 && t <= 1) {
			t += index * Time.fixedDeltaTime / transition;
		}
		if (GetComponent<AudioSource> () != null)
			GetComponent<AudioSource> ().volume = t;
		//Debug.Log(locked + " " + t + " " + index);
		CheckTransition ();
	}
}
