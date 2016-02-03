using UnityEngine;
using System.Collections;

public class ElectronColorCycle : MonoBehaviour {
	public Color[] colors;
	public float duration;
	public int index;
	public int prevIndex;
	private float interval;
	private float t;
	
	void ColorChange() {
		GetComponent<Renderer>().material.color = Color.Lerp (colors [prevIndex], colors [index], t);
	}
	
	void IndexChange() {
		t = 0;
		prevIndex = index;
		index ++;
		if (index == colors.Length) {
			index = 0;
		}
	}
	
	// Use this for initialization
	void Start () {
		index = 0;
		interval = duration / GetComponent<DarkEnergyFade> ().duration;
		prevIndex = index;
	}

	// Update is called once per frame
	void Update () {
		t += Time.fixedDeltaTime / duration;

			if (GetComponent<DarkEnergyFade> ().GetFadeT () > interval * (float)(index + 1)) {
				IndexChange ();
			} else if (index == colors.Length - 1 && GetComponent<DarkEnergyFade> ().GetFadeT () > 0.999f) {
				IndexChange ();
			}

		if (t < 1) {
			ColorChange ();
		}
	}
}
