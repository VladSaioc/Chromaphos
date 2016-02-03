using UnityEngine;
using System.Collections;

public class EnergyBarBehavior : MonoBehaviour {

	public float[] coef;
	public Vector3 decrementSpeed;
	public Vector3 energyBarSize;

	// Use this for initialization
	void Start () {
		transform.localScale = energyBarSize;
	}

	public void EnergyDecrementation(int newCoef, int oldCoef)
	{
		if (newCoef != 0 && newCoef != oldCoef) {
			if(newCoef > oldCoef) 
				transform.localScale -= decrementSpeed * coef [newCoef];
		}
	}
		
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x < 1) {
			transform.localScale = Vector3.zero;
	/*		if(GameObject.Find ("Photon").GetComponent<PhotonDeath>().alive == true)
				GameObject.Find("Photon").GetComponent<PhotonDeath>().KillPhoton();*/
		}
	}
}
