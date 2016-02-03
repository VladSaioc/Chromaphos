using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelFinishTransition : MonoBehaviour {

	private Vector3 photonPos;
	private Vector3 electronPos;
	public Color[] fade;
	private float t;
	private bool active = false;
	private bool exists = false;
	public string nextLevelName;

	// Use this for initialization
	void Start () {
		t = 0;
		GetComponent<Renderer>().material.color = fade [0];
		if (GameObject.Find ("Electron")) {
			electronPos = GameObject.Find ("Electron").transform.position;
			exists = true;
		}
	}

	void CheckActive() {
		if (GameObject.Find ("Photon").GetComponent<Transform> ().position.y > electronPos.y - 13)
			active = true;
	}

	void Execute() {
		if (!active)
			CheckActive ();
		else {
			t += Time.deltaTime;
			GetComponent<Renderer>().material.color = Color.Lerp (fade [0], fade [1], t);
			if (t >= 1) {
				PlayerPrefs.SetInt(nextLevelName, 1);				
				PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "to" + nextLevelName, 1);
				SceneManager.LoadScene (nextLevelName);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (exists)
			Execute ();
	}
}
