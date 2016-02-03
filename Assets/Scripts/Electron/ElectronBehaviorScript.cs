using UnityEngine;
using UnityEngine.SceneManagement;

public class ElectronBehaviorScript : MonoBehaviour {

	public string[] levelName;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.transform.tag == "Photon") {
			ChangeLevel ();
		}
	}

	void ChangeLevel()
	{
		if (levelName [GameObject.Find ("Photon").GetComponent<PhotonMovement> ().coefIndex - 1] != null) {
			PlayerPrefs.SetInt(levelName [GameObject.Find ("Photon").GetComponent<PhotonMovement> ().coefIndex - 1], 1);
			
			PlayerPrefs.SetInt(SceneManager.GetActiveScene().name	+ "to" +
				levelName [GameObject.Find ("Photon").GetComponent<PhotonMovement> ().coefIndex - 1], 1);
			SceneManager.LoadScene (levelName [GameObject.Find ("Photon").GetComponent<PhotonMovement> ().coefIndex - 1]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
