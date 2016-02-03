using UnityEngine;
using System.Collections;

public class PlayColorSound : MonoBehaviour {

	public int coef;
	private bool playing;
	private float t;

	// Use this for initialization
	void Start () {
		playing = false;
	}

	void CheckPlaying() {
		if (GameObject.Find ("Photon").GetComponent<PhotonMovement> ().coefIndex != coef) {
			if(playing) t =1;
			playing = false;
		} else {
			GetComponent<AudioSource>().volume = 1;
			if(!playing) GetComponent<AudioSource>().Play();
			playing = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (playing == false) {
			if(t > 0) {
				t -= Time.fixedDeltaTime * 2;
				GetComponent<AudioSource>().volume = t;
			}
		}
		CheckPlaying ();
	}
}
