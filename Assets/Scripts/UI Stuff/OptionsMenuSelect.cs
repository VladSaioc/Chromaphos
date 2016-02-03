using UnityEngine;
using System.Collections;

public class OptionsMenuSelect : MonoBehaviour {

	private GameObject mainCamera;
	private bool startTimer;
	private float t;
	public float fadeTimer;
	public Vector3 offset = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find ("Main Camera");
	}

	void FadeIn()
	{
		startTimer = false;
		t = 0;
		foreach(MenuColorChange obj in GetComponentsInChildren<MenuColorChange>())
		{
			obj.check = false;
		}
	}

	void FadeOut()
	{
		startTimer = true;
		t = 0;
		foreach(MenuColorChange obj in GetComponentsInChildren<MenuColorChange>())
		{
			obj.ChangeColor();
		}
	}

	void CheckTouch()
	{		
		if (Input.touchCount == 1) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos)) {
				GameObject.Find("Quit").GetComponent<QuitGame>().SetMenuLock(true);
				mainCamera.GetComponent<MenuCameraMovement>().MoveCamera(offset);
			}
		}
		else 
		if (Input.GetMouseButton (0)) {
			Vector3 wp0 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 touchPos0 = new Vector2 (wp0.x, wp0.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos0)) {
				GameObject.Find("Quit").GetComponent<QuitGame>().SetMenuLock(true);
				mainCamera.GetComponent<MenuCameraMovement>().MoveCamera(offset);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameObject.Find("Quit").GetComponent<QuitGame>().GetMenuLock()) CheckTouch ();
		t += Time.deltaTime;
		if (t > fadeTimer && startTimer)
			FadeIn ();
		if (t > fadeTimer && !startTimer)
			FadeOut ();
	}
}
