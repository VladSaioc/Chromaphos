using UnityEngine;
using System.Collections;

public class ClearDataHighlight : MonoBehaviour {

	public Color[] fade;
	public float duration;
	private float index;

	// Use this for initialization
	void Start () {
	}
//
//	void ChangeColor() {
//		renderer.material.color = Color.Lerp (fade [0], fade [1], t);
//	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponentInParent<SetDefaultSettings> ().GetHighlight ()) {
			GetComponent<Renderer>().material.color = fade [1];
			} else {
			GetComponent<Renderer>().material.color = fade[0];
			}
	}
}
