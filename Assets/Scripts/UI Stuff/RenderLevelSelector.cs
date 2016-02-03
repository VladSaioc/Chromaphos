using UnityEngine;
using System.Collections;

public class RenderLevelSelector : MonoBehaviour {

	public string levelName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt (levelName, 0) == 1) {
			gameObject.SetActive (true);
		} else
			gameObject.SetActive (false);
	}
}
