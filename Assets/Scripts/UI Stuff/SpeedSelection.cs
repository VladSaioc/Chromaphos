using UnityEngine;
using System.Collections;

public class SpeedSelection : MonoBehaviour {

	public float speed;
	public GameObject previousPellet = null;
	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
		
	}

	void CheckTouch()
	{	
		if (Input.touchCount == 1) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos)) {
				PlayerPrefs.SetFloat("GameSpeed", speed);
			}
		}
		else if(Input.GetMouseButton (0)) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos)) {
				PlayerPrefs.SetFloat("GameSpeed", speed);
			}
		}
	}

	public void ChangeSprite(int unit)
	{
		GetComponent<SpriteRenderer>().sprite = sprites [unit];
		if (unit == 1 && speed > 1)	previousPellet.GetComponent<SpeedSelection> ().ChangeSprite (unit);
	}

	void PictureUpdate()
	{
		if (PlayerPrefs.GetFloat ("GameSpeed", 1) >= speed)
			ChangeSprite (1);
		else
			ChangeSprite (0);
	}

	// Update is called once per frame
	void Update () {
		CheckTouch ();
		PictureUpdate ();
	}
}
