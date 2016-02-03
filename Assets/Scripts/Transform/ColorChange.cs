using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

	public Color[] colors;
	private int index;
	private Color oldcolor;
	public float transition;
	private float t;
	
	// Use this for initialization
	void Start () {
		oldcolor = colors [0];
		index = 0;
	}

	public void SetNewIndex()
	{
		oldcolor = GetComponent<Renderer>().material.color;
		index = GameObject.Find ("Photon").GetComponent<PhotonMovement> ().coefIndex;
		t = 0;
	}

	public int GetIndex()
	{
		return index;
	}

	void Update () {
		GetComponent<Renderer>().material.color = Color.Lerp(oldcolor, colors[index], t);
		if (t <= 1) {
			t += Time.fixedDeltaTime / transition;
		}
	}
}
