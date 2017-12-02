using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {

    public Transform[] patrolPoints;
    Transform currentPatrolPoint;
    int currentPatrolIndex;
    public float speed;


    // Use this for initialization
    void Start () {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
    }
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 1f)
        {
            if (currentPatrolIndex + 1 < patrolPoints.Length)
            {
                currentPatrolIndex++;
            }
            else
            {
                currentPatrolIndex = 0;
            }
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }

        Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
        Quaternion newRotation;


        if (patrolPointDir.x < 0f)
        {
            
            newRotation = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = newRotation;
            transform.Translate(-transform.right * Time.deltaTime * speed, Space.Self);
            
        }
        if (patrolPointDir.x > 0f)
        {
            newRotation = Quaternion.Euler(0f, 180f, 0f);
            transform.rotation = newRotation;
            transform.Translate(transform.right * Time.deltaTime * speed, Space.Self);
            
        }
    }
}
