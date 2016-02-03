using UnityEngine;
using System.Collections;

public class ColorCycleScript: MonoBehaviour {
	public Color[] colors;
	public float duration;
	public int index;
	public int prevIndex;
	public float delay;
	private int modifier;
	private float t;

	// Use this for initialization
	void Start () {
		index = 0;
		modifier = 1;
		prevIndex = index;
	}

	void ColorChange() {
		foreach (Transform obj in GetComponentInChildren<Transform>()) {
			obj.GetComponent<Renderer>().material.color = Color.Lerp (colors [prevIndex], colors [index], t);
		}
	}
			                                                              
	void IndexChange() {
		prevIndex = index;
		index += modifier;
		if (index == colors.Length - 1 || index == 0) {
			modifier *= -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.fixedDeltaTime / duration;
		if(t <= 1) ColorChange ();
		if (t > delay + 1) {
			t = 0;
			IndexChange();
		}
	}
}
