using UnityEngine;
using System.Collections;

public class FrequencySelector : MonoBehaviour {


	public int coef;
//	private bool set;

	// Use this for initialization
	void Start () {
	}

	public int GetCoef()
	{
		return coef;
	}

	void CheckTouch()
	{
		if (Input.touchCount > 1) {
			Vector3 wp0 = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector3 wp1 = Camera.main.ScreenToWorldPoint (Input.GetTouch (1).position);
			Vector2 touchPos1 = new Vector2 (wp1.x, wp1.y);
			Vector2 touchPos0 = new Vector2 (wp0.x, wp0.y);
			if ((GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos0) 
			     && Input.GetTouch(0).phase == TouchPhase.Began)
			    || (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos1)
			    && Input.GetTouch(1).phase == TouchPhase.Began)) {
				if(GameObject.Find ("Photon").GetComponent<PhotonMovement>().getChangeable()
				   && GetComponent<UIGameMovement>().GetActive()) {
					GameObject.Find ("Photon").GetComponent<PhotonMovement> ().RegisterChange (
						GameObject.Find ("Photon").GetComponent<PhotonMovement> ().newCoefIndex + coef);
				//	GetComponent<AudioSource>().Play();
				}
			}
		} else {
			if (Input.touchCount == 1) {
				Vector3 wp0 = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				Vector2 touchPos0 = new Vector2 (wp0.x, wp0.y);
				if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos0)
				    && Input.GetTouch(0).phase == TouchPhase.Began) {
					if(GameObject.Find ("Photon").GetComponent<PhotonMovement>().getChangeable()
					   && GetComponent<UIGameMovement>().GetActive()) {
						GameObject.Find ("Photon").GetComponent<PhotonMovement> ().RegisterChange (
							GameObject.Find ("Photon").GetComponent<PhotonMovement> ().newCoefIndex + coef);
					//	GetComponent<AudioSource>().Play();
					}
				}
			} else
			if (Input.GetMouseButtonDown (0)) {
				Vector3 wp0 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector2 touchPos0 = new Vector2 (wp0.x, wp0.y);
				if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos0)) {
					if(GameObject.Find ("Photon").GetComponent<PhotonMovement>().getChangeable()
					   && GetComponent<UIGameMovement>().GetActive()) {
						GameObject.Find ("Photon").GetComponent<PhotonMovement> ().RegisterChange (
							GameObject.Find ("Photon").GetComponent<PhotonMovement> ().newCoefIndex + coef);
					//	GetComponent<AudioSource>().Play();
					}
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Photon").GetComponent<PhotonDeath>().alive == true)
			if((GameObject.Find ("Photon").GetComponent<PhotonMovement>().newCoefIndex + coef <= 6
		    && GameObject.Find ("Photon").GetComponent<PhotonMovement>().newCoefIndex + coef > 0)) CheckTouch ();
	}
}
