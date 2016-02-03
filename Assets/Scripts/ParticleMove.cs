using UnityEngine;
using System.Collections;

public class ParticleMove : MonoBehaviour {

	private Vector3 speed;
	private Vector3 size;
	public Vector3 respawn;
	public float threshold;

	// Use this for initialization
	void Start () {
		size = new Vector3 (0, 0, 0);
		respawn.x = Random.Range (-10, 10);
		transform.position = respawn;
		size = transform.localScale;
		size.x = size.x * Random.Range (0.75f, 1.25f);
		size.y = size.x;
		transform.localScale = size;
		speed.y = Random.Range (-100, -200);
		Vector3 sizeSpeed = new Vector3 (transform.localScale.x / (speed.y / (-100)), transform.localScale.y * (speed.y / (-100)), transform.localScale.z);
		transform.localScale = sizeSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += speed * Time.deltaTime / Time.timeScale;
		if (transform.position.y < threshold) {
			transform.localScale = size;
			respawn.x = Random.Range(-10, 10);
			speed.y = Random.Range (-100, -200);
			transform.position = respawn;
			Vector3 sizeSpeed = new Vector3 (transform.localScale.x / (speed.y / (-100)), transform.localScale.y * (speed.y / (-100)), transform.localScale.z);
			transform.localScale = sizeSpeed;
		}
	}
}
