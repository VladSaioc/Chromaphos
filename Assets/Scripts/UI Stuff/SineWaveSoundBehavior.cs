using UnityEngine;
using System.Collections;

public class SineWaveSoundBehavior : MonoBehaviour {

	private float t;
	public float duration;
	private float index;

	// Use this for initialization
	void Start () {
		t = 0;
		index = 1;
		GetComponent<AudioSource> ().volume = 0.05f + 0.95f * t;
	}

	void SwitchAmp() {
		index = -1 * index;
		if (t < 0)
			t = 0;
		else if (t > 1)
			t = 1;
	}

	// Update is called once per frame
	void Update () {
		t += index * Time.fixedDeltaTime / duration;
		if (t < 0 || t > 1)
			SwitchAmp ();
		GetComponent<AudioSource> ().volume = 0.05f + 0.95f * t;
	}
}
