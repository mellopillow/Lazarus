using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {


    public float distance;
    public float shootInterval;
    public float projSpeed;
    public float projTimer;

    public bool lookingRight = true;

    public GameObject bullet;
    public Transform target;
    public Transform shootPointLeft, shootPointRight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //For animations
        /*
        RangeCheck();

        if (target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }


        if (target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }
        */
	}

    //For animations
    /*
    void RangeCheck()
    {

        distance = Vector3.Distance(transform.position, target.transform.position);


    }
    */

    public void Attack(bool attackingRight)
    {

        projTimer += Time.deltaTime;

        if (projTimer >= shootInterval)
        {

            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            Vector3 newScale;
            if (!attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * projSpeed;

                newScale = new Vector3(transform.localScale.x, 1, 1);
                transform.localScale = newScale;
                projTimer = 0;
            }

            if (attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * projSpeed;

                newScale = new Vector3(-transform.localScale.x, 1, 1);
                transform.localScale = newScale;
                projTimer = 0;
            }


        }

    }
}
