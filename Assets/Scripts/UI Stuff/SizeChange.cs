using UnityEngine;
using System.Collections;

public class SizeChange : MonoBehaviour {

	private Vector3 oldsize;
	public Vector3[] sizes;
	private int index;
//	private int oldindex; 
	public float transition;
	private float t;
	
	// Use this for initialization
	void Start () {
//		oldindex = 0;
		oldsize = transform.localScale;
		index = 0;
		SetNewIndex ();
	}
	
	public void SetNewIndex()
	{
		oldsize = transform.localScale;
		index = GameObject.Find ("Photon").GetComponent<PhotonMovement> ().coefIndex;
		t = 0;
	}
	
	public int GetIndex()
	{
		return index;
	}
	
	void Update () {
		transform.localScale = Vector3.Lerp(oldsize, sizes[index], t);
		if (t <= 1) {
			t += Time.fixedDeltaTime / transition;
		}
	}
}
