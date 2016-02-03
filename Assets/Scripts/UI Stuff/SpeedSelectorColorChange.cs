using UnityEngine;
using System.Collections;

public class SpeedSelectorColorChange : MonoBehaviour {

	private float currentSpeed;
	public Color[] colors;
	private bool changing;
	private float duration = 1f;
	private float t = 0; 

	// Use this for initialization
	void Start () {
		currentSpeed = PlayerPrefs.GetFloat ("GameSpeed", 1);
		changing = false;
	}

	void ChangeColor() {
		GetComponent<Renderer>().material.color = Color.Lerp(colors[(int) ((currentSpeed - 1) * 4)],
		            colors [(int)((PlayerPrefs.GetFloat ("GameSpeed", 1) - 1) * 4)], t);
	}

	void StopChange() {
		changing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetFloat ("GameSpeed", 1) != currentSpeed && !changing) {
			changing = true;
			currentSpeed = PlayerPrefs.GetFloat ("GameSpeed", 1);
			t = 0;
		}
		if (changing) {
			t += Time.deltaTime / duration;
			if (t > duration)
				StopChange ();
		}
		ChangeColor ();
	}
}
