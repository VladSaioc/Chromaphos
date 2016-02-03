using UnityEngine;
using System.Collections;

public class GravityBehavior : MonoBehaviour {
	
	private bool touched;
	public int coefIndex;

	void Start () {
		
	}
	
	void Touch() {
		Vector2 photonPosition = GameObject.Find ("Photon").transform.position;
		if (GetComponent<Collider2D>().OverlapPoint (photonPosition)) {
			int index = GameObject.Find ("Photon").GetComponent<PhotonMovement> ().coefIndex;
			if (coefIndex - 1 + index >= 7
			    && index != 0
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
				GameObject.Find ("Photon").GetComponent<PhotonMovement> ().newCoefIndex + coefIndex - 1);
			GameObject.Find ("Photon").GetComponent<PhotonMovement>().setChangeable(true);
		}
	}

	void Update () {
		Touch ();
	}
}
