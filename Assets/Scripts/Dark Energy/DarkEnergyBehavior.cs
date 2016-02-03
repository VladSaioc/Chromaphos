using UnityEngine;
using System.Collections;

public class DarkEnergyBehavior : MonoBehaviour {

	private bool touched;
	public int coefIndex;

	// Use this for initialization
	void Start () {
	
	}

	void Touch() {
		Vector2 photonPosition = GameObject.Find ("Photon").transform.position;
		if (GetComponent<Collider2D>().OverlapPoint (photonPosition)) {
			if (coefIndex > GameObject.Find ("Photon").GetComponent<PhotonMovement> ().coefIndex
			    && GameObject.Find ("Photon").GetComponent<PhotonMovement> ().coefIndex != 0
			    && GameObject.Find ("Photon").GetComponent<PhotonDeath> ().alive == true) {
				GameObject.Find ("Photon").GetComponent<PhotonMovement>().setChangeable(true);
				touched = false;
				GameObject.Find ("Photon").GetComponent<PhotonDeath> ().KillPhoton ();
			} 
			else 
			if(GameObject.Find ("Photon").GetComponent<PhotonDeath> ().alive == true) {
				GameObject.Find ("Photon").GetComponent<PhotonMovement>().setChangeable(false);
				touched = true;
			}
		}
		else if (touched
		           && GameObject.Find ("Photon").GetComponent<PhotonDeath> ().alive) {
			touched = false;
			GameObject.Find ("Photon").GetComponent<PhotonMovement> ().RegisterChange (
				GameObject.Find ("Photon").GetComponent<PhotonMovement> ().newCoefIndex - coefIndex + 1);
			GameObject.Find ("Photon").GetComponent<PhotonMovement>().setChangeable(true);
		}
	}

	// Update is called once per frame
	void Update () {
		Touch ();
	}
}
