using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticLaserScript : MonoBehaviour {

	public float moveSpeed;
	public float laserDelay;
	public bool isVertical;

	float timer;
	bool laserOn;
	bool movingUp;
	Rigidbody2D rigidBody;
	// Use this for initialization
	void Start () {
		laserOn = true;
		movingUp = true;
		rigidBody = GetComponent<Rigidbody2D> ();
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= laserDelay && laserOn) {

			gameObject.tag = "Untagged";
			GetComponent<SpriteRenderer> ().enabled = false;
			laserOn = false;
			timer = 0;

		} else if (timer >= laserDelay && !laserOn) {

			gameObject.tag = "Damageable";
			GetComponent<SpriteRenderer> ().enabled = true;
			laserOn = true;
			timer = 0;

		}

		if (!isVertical) {
			if (movingUp) {

				rigidBody.velocity = new Vector2 (0, moveSpeed);

			} else {

				rigidBody.velocity = new Vector2 (0, -moveSpeed);
			}
		} else {
			if (movingUp) {

				rigidBody.velocity = new Vector2 (moveSpeed, 0);

			} else {

				rigidBody.velocity = new Vector2 (-moveSpeed, 0);
			}
		}
		/*
		Vector3 pos = transform.localPosition;

		float newY = Mathf.Sin (Time.time * moveSpeed);
		transform.localPosition = new Vector3 (pos.x, newY, pos.z);
		*/
	}

	void OnTriggerEnter2D(Collider2D collision){

		if (collision.tag == "Ceiling") {
			movingUp = false;
		}
		if (collision.tag == "Floor") {
			movingUp = true;
		}

	}
}
