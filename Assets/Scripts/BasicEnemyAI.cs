using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour {

    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;

    public Transform target;
    public float chaseRange;

    public bool shooting;
    public bool patrolling;
    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;

    public GameObject projectile;
    public float projectileForce;
    public Transform raycastPoint;
    private bool right;

    private Animator animator;

	// Use this for initialization
	void Start () {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
	}
	void Awake () {
        animator = GetComponent<Animator>();
    }
	// Update is called once per frame
	void Update () {
        //Patrolling
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
        Vector3 newScale;
        Quaternion newRotation;
        if (shooting != true)
        {
            patrolling = true;
            animator.SetBool("patrolling", patrolling);
            if (patrolPointDir.x < 0f)
            {
                newRotation = Quaternion.Euler(0f, 0f, 0f);
                transform.rotation = newRotation;
                transform.Translate(-transform.right * Time.deltaTime * speed, Space.Self);
                right = false;
                //newScale = new Vector3(0.3320676f, 0.4630453f, 1);
                //transform.localScale = newScale;
            }
            if(patrolPointDir.x > 0f)
            {
                newRotation = Quaternion.Euler(0f, 180f, 0f);
                transform.rotation = newRotation;
                transform.Translate(transform.right * Time.deltaTime * speed, Space.Self);
                right = true;
                //newScale = new Vector3(-0.3320676f, 0.4630453f, 1);
                //transform.localScale = newScale;
            }
        }
        else
        {
            patrolling = false;
            animator.SetBool("patrolling", patrolling);
        }

        //Check if player is in range
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (right)
        {
            Debug.DrawLine(raycastPoint.position, raycastPoint.position + new Vector3(5f, 0f, 0f));
        }
        else
        {
            Debug.DrawLine(raycastPoint.position, raycastPoint.position + new Vector3(-5f, 0f, 0f));
        }
        if (distanceToPlayer < attackRange)
        {
            RaycastHit2D hit;
            if (Time.time > lastAttackTime + attackDelay)
            {
                //Check if there is a clear line of sight to player
                
                if (right)
                {
                    
                    hit = Physics2D.Raycast(raycastPoint.position, new Vector2(1,0), attackRange);
                }
                else
                {
                    
                    hit = Physics2D.Raycast(raycastPoint.position, new Vector2(-1, 0), attackRange);
                }
                
                
                
                if (hit.transform == target)
                {
                    shooting = true; 
                    animator.SetBool("shooting", shooting);  
                    print("hit");
                    GameObject newBullet = Instantiate(projectile, raycastPoint.position, transform.rotation);
                    
                    if (right)
                    {
                      
                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(projectileForce, 0f));
                    }
                    else
                    {
                        
                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-projectileForce, 0f));

                    }
                    lastAttackTime = Time.time;
                }
                else
                {
                    shooting = false;
                    animator.SetBool("shooting", shooting);  
                    print("not found");
                }
            }
        }
        else
        {
            shooting = false;
            animator.SetBool("shooting", shooting);  
        }
    }
}
