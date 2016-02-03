using UnityEngine;
using System.Collections;

public class UIGameMovement : MonoBehaviour {
	
	public Vector3 offset;
	public Vector3 speed;
	public Vector3 slide;
	public float offsetX;
	public float offsetY;
	public float offsetZ;
	private float t;
	private bool active;
	public float duration;
	// Use this for initialization
	void Start () {
		
		offset = new Vector3 (offsetX, offsetY, offsetZ);
		speed.y = GameObject.Find ("Photon").GetComponent<PhotonMovement> ().speed.y;
		t = 0;
		if (!slide.Equals (Vector3.zero))
			active = false;
		else {
			active = true;
			transform.position = offset;
		}
	}

	public bool GetActive()
	{
		return active;
	}

	public void Reset()
	{
		transform.position = offset;
	}
	
	// Update is called once per frame
	void Update () {
		if (!active) {
			t += Time.fixedDeltaTime / duration;
			transform.position = Vector3.Lerp (slide, offset, t);
			if(t >= 1) active = true;
		}
		if (GameObject.Find ("Photon").GetComponent<PhotonMovement> ().coefIndex != 0 && active) {
			transform.position += speed * Mathf.Round (Time.deltaTime * 10000) / 10000;
			}
	}
}
