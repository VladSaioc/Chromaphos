using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PhotonDeath : MonoBehaviour {

	public bool alive;
	private Vector3 size;
	private Vector3 death;
	private float t;

	// Use this for initialization
	void Start () {
		size = transform.localScale;
		death = size;
		death.y = 0;
		death.x /= 2;
		alive = true;
	}

	public void KillPhoton()
	{
		alive = false;
		t = 0;
	}

	public void Setup()
	{
        //		transform.position = Vector3.zero;
        //		Vector3 camera = new Vector3 (0, 24, 0);
        //		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("UI Element"))
        //		{	
        //			if(obj.GetComponent<UIGameMovement>() != null)
        //				obj.GetComponent<UIGameMovement>().Reset();
        //		GameObject.Find ("Main Camera").transform.position = camera;
        //		}
        //		GameObject.Find ("Main Camera").transform.position = camera;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	// Update is called once per frame
	void Update () {
		if (alive == false) {
			if (t < 1.5f) {
				if(t > 0.25f)  GetComponent<PhotonMovement> ().RegisterChange (0);
				transform.localScale = Vector3.Lerp(size, death, t * 4);
				t += Time.deltaTime;
			} else {
				transform.localScale = size;
				alive = true;
				Setup ();
			}
		}
	}
}
