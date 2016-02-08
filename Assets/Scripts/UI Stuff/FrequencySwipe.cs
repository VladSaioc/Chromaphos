using UnityEngine;
using System.Collections;

public class FrequencySwipe : MonoBehaviour {

	public float minSwipeDistY;
	private Vector2 startPos;
	private bool started = false;

	void Start() {
		started = false;
	}

	void Update()
	{
		if (Input.touchCount > 0 && GameObject.Find ("Photon").GetComponent<PhotonMovement>().getChangeable()) 
		{			
			Touch touch = Input.touches[0];	
			switch (touch.phase) 
			{				
			case TouchPhase.Began:				
				startPos = touch.position;	
					started = true;
				break;				
			case TouchPhase.Ended:
				if(started) {
				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;				
				if (swipeDistVertical > minSwipeDistY) 
				{					
					float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
						int index = GameObject.Find ("Photon").GetComponent<PhotonMovement>().newCoefIndex;
					if (swipeValue > 0 &&  index <= 6 - Input.touchCount ) {
						GameObject.Find ("Photon").GetComponent<PhotonMovement> ().RegisterChange (
							index + Input.touchCount);
					}
					else if (swipeValue < 0 && index >= 1 + Input.touchCount) {
						GameObject.Find ("Photon").GetComponent<PhotonMovement> ().RegisterChange (
							index - Input.touchCount);
					}
				}
					started = false;
				}
				break;
			}
		}
	}
}
