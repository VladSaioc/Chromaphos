using UnityEngine;
using System.Collections;

public class LevelArrowBehavior : MonoBehaviour {

	public string from, to;
	public Color color;


	// Use this for initialization
	void Start () {
		foreach (Renderer obj in GetComponentsInChildren<Renderer>()) {
			obj.material.color = color;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt (from + "to" + to, 0) == 1) {
			gameObject.SetActive (true);
		} else
			gameObject.SetActive (false);		
	}
}
