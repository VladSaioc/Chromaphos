using UnityEngine;
using System.Collections;

public class TitleSizeChange : MonoBehaviour {

	public Vector3[] sizes;
	public float duration;
	public float delay;
	private int index;
	private int prevIndex;
	private float t;
	private int modifier;
	
	void SizeChange() {
		transform.localScale = Vector3.Lerp (sizes [(int)prevIndex], sizes [(int)index], t);
	}
	
	void IndexChange() {
		prevIndex = index;
		index += modifier;
		if (index == 5 || index == 0) {
			modifier *= -1;
		}
	}
	
	// Use this for initialization
	void Start () {
		index = 0;
		modifier = 1;
		prevIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.fixedDeltaTime / duration;
		if(t <= 1) SizeChange ();
		if (t > delay + 1) {
			t = 0;
			IndexChange ();
		}
	}
}
