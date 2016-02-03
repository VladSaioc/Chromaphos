using UnityEngine;
using System.Collections;

public class PhotonMovement : MonoBehaviour {

	private bool changeable;
	public Vector3 speed = new Vector3(0, 0, 0);
	public int coefIndex;
	public float[] coef;
	public float baseSpeed;
	public float orientation;
	public float amplitude;
	public int oldCoefIndex;
	public int newCoefIndex = 0;

	// Use this for initialization
	void Start () {
		changeable = true;
		Vector3 cameraPosition = transform.position;
		cameraPosition.x = 0;
		cameraPosition.y = cameraPosition.y + 24;
		GameObject.Find ("Main Camera").transform.position = cameraPosition;
		orientation = 1;
		speed.x = baseSpeed * coef[coefIndex];
	}

	public bool getChangeable() {
		return changeable;
	}

	public void setChangeable(bool change) {
		changeable = change;
	}

	void SwitchMovement()
	{
		if (Mathf.Abs (transform.position.x) >= amplitude) {
			Vector3 newPos = transform.position;
			newPos.x = amplitude * orientation - 0.001f * orientation;
			transform.position = newPos;
			orientation = orientation * (-1);
			speed.x = speed.x * (-1);
		}
	}

	void Move ()
	{
		if (coefIndex != 0) {
			Vector3 temp = speed;
			temp.x = temp.x * (1 + 0.9f * (amplitude - Mathf.Abs(transform.position.x))) / 5;
			transform.position += temp * Mathf.Round (Time.deltaTime * 10000) / 10000;
			/*(2 + 0.8f * (amplitude - Mathf.Abs(transform.position.x))) / 10*/ 
			Vector3 cameraPosition = transform.position;
			cameraPosition.x = 0;
			cameraPosition.y = cameraPosition.y + 24;
			GameObject.Find ("Main Camera").transform.position = cameraPosition;
			if (newCoefIndex != coefIndex) {
				ChangeCoefficient ();
			}
		} else {
			if (newCoefIndex != coefIndex) {
				ChangeCoefficient ();
			}
		}
	}

	public void RegisterChange(int newCoef)
	{
		newCoefIndex = newCoef;
	}


	public void ChangeCoefficient()
	{
		oldCoefIndex = coefIndex;
		coefIndex = newCoefIndex;
		speed.x = coef[newCoefIndex] * baseSpeed * orientation;
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("UI Element")) {
			if(obj.GetComponent<ColorChange>() != null) {
				obj.GetComponent<ColorChange>().SetNewIndex();
				foreach(ColorChange chng in obj.GetComponentsInChildren<ColorChange>()) {
					chng.SetNewIndex();
				}
			}
		}
		GetComponent<ColorChange> ().SetNewIndex ();
		foreach (ColorChange obj in GetComponentsInChildren<ColorChange>()) {
			obj.SetNewIndex();
		}
		GameObject.Find ("BackGround Tint").GetComponent<SizeChange> ().SetNewIndex ();
	}

	// Update is called once per frame
	void Update () {
		SwitchMovement ();
		Move ();
	}
}
