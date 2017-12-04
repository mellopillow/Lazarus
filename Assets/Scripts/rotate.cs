using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

    private Transform transformRenderer;
    public int speed;
    public float speedDamp;
	// Use this for initialization
	void Start () {
        transformRenderer = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        transformRenderer.Rotate(0, Time.deltaTime / speed * speedDamp, 0);
	}
}
