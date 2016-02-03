using UnityEngine;
using System.Collections;

public class MenuSlideAnimation : MonoBehaviour {

	public Vector3 slidePos;
	private Vector3 endPos;
	private float t;
	public float duration;

	// Use this for initialization
	void Start () {
		t = 0;
		endPos = transform.position;
		transform.position = slidePos;
	}

	void Slide() {
		transform.position = Vector3.Lerp(slidePos, endPos, t);
	}

	// Update is called once per frame
	void Update () {
		if (t < 1)
			t += Time.fixedDeltaTime / duration;
		Slide ();

	}
}
