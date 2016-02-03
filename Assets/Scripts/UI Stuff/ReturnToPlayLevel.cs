using UnityEngine;
using System.Collections;

public class ReturnToPlayLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetFloat ("PlayLevelReturn") == 1) {
			PlayerPrefs.SetFloat ("PlayLevelReturn", 0);
			transform.position = GameObject.Find ("Play").GetComponent<OptionsMenuSelect> ().offset;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
