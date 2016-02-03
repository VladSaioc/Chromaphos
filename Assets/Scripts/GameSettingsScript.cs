using UnityEngine;
using System.Collections;

public class GameSettingsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetFloat ("GameSpeed") != 0) 
			Time.timeScale = PlayerPrefs.GetFloat ("GameSpeed");
		else
			Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
