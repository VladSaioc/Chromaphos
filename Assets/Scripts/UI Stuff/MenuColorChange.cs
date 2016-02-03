using UnityEngine;
using System.Collections;

public class MenuColorChange : MonoBehaviour {
	public Color[] nuances;
	public float[] transition;
	public bool check;
	private float t;
	private float index;
	private bool locked;
	
	
	// Use this for initialization
	void Start () {
		index = - 1;
		t = 1;
		locked = true;
	}
	
	void CheckTransition()
	{
		if(locked == false && !check)
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
		check = true;
		//}
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Renderer>().material.color = Color.Lerp (nuances [0], nuances [1], t);
		if (t >= 0 && t <= 1) {
			t += index * Time.deltaTime / transition[(int)(index * (-1) + 1) / 2];
		}
		//Debug.Log(locked + " " + t + " " + index);
		CheckTransition ();
	}
}
