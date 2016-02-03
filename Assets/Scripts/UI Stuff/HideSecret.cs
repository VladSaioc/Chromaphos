using UnityEngine;
using System.Collections;

public class HideSecret : MonoBehaviour {

	public string[] path;

	// Use this for initialization
	void Start () {
		bool show = true;

		for (int i = 0; i < path.Length; i++) {
			if(PlayerPrefs.GetInt(path[i]) != 1) show = false;
		}

		if (!show)
			gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
