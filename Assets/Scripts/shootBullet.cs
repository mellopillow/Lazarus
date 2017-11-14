using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBullet : MonoBehaviour {

    public GameObject projetile;
    public float shootCooldown;
    public int chanceToShoot;
    public Transform shootFrom;

    float nextShootTime;

	// Use this for initialization
	void Start () {
        nextShootTime = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && nextShootTime < Time.time)
        {
            nextShootTime = Time.time + shootCooldown;
            if(Random.Range(0,10) >= chanceToShoot)
            {
                Instantiate(projetile, shootFrom.position, Quaternion.identity);
            }
        }
    }
}
