using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy_v2 : MonoBehaviour {

	Transform target;

	public float speed;
	public float playerRange;

	public LayerMask playerLayer;
	public bool playerInRange;


	bool attacking = false;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
		playerInRange = Physics2D.OverlapCircle (transform.position, playerRange, playerLayer);

		Vector2 direction = target.transform.position - transform.position;
		direction.Normalize();

		Vector3 newScale;
		if (playerInRange) {

			if (direction.x < 0f) { //facing left
				newScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
				transform.localScale = newScale;
			}

			if (direction.x > 0f) { //facing right
				newScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				transform.localScale = newScale;
			}

			transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);

		}
	}


	void OnDrawGizmosSelected(){

		Gizmos.DrawSphere (transform.position, playerRange);

	}
}
