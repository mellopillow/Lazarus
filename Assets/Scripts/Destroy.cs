using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Destoryed");
        Destroy(this.gameObject);
    }
}
