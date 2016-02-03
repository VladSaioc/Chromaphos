using UnityEngine;
using System.Collections;

public class DarkEnergyFade : MonoBehaviour {

	public Vector3 startPos, startScale;
	public Vector3 endPos, endScale;
	public float initT;
	private float t;
	public float duration;

	// Use this for initialization
	void Start () {
		transform.localPosition = startPos;
		transform.localScale = startScale;
		t = initT;
	}

	public float GetFadeT() {
		return t;
	}

	void Render()
	{
		t += Time.fixedDeltaTime / duration ;
		if (t >= 1)
			t = 0;
		transform.localPosition = Vector3.Lerp (startPos, endPos, t);
		transform.localScale = Vector3.Lerp (startScale, endScale, t);
	}

	// Update is called once per frame
	void Update () {
		Render ();
	}
}
