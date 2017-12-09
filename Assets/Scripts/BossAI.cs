using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {

	public Health health;
    public Transform player;
    public bool attackable = true;
    public bool canFire = true;

    public float lazorCooldownMax = 10f;
    public float lazorCooldown;

    public GameObject lazorLower;
    private SpriteRenderer lazorLowerSprite;
    private lazorScript lazorLowerScript;

    public GameObject lazorMiddle;
    private SpriteRenderer lazorMiddleSprite;
    private lazorScript lazorMiddleScript;

    public GameObject lazorTop;
    private SpriteRenderer lazorTopSprite;
    private lazorScript lazorTopScript;

    public lazorScript firstShot;
	public lazorScript secondShot;

	// Use this for initialization
	void Start () 
	{
		lazorCooldown = lazorCooldownMax;
		health = GetComponent<Health>();
		lazorLowerScript = lazorLower.GetComponent<lazorScript>();
		lazorMiddleScript = lazorMiddle.GetComponent<lazorScript>();
		lazorTopScript = lazorTop.GetComponent<lazorScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!health.dead)
		{
			if (attackable == false)
			{
				lazorLowerScript.fireBeam();
				attackable = true;
			}

			if (canFire)
			{
				if (firstShot == null)
				{
					firstShot = randomFire();
					firstShot.lazorState = LazorState.Ready;
				}
				else
				{
					if (firstShot.lazorState == LazorState.Dormant)
					{
						firstShot = null;
					}
					else
					{
						firstShot.fireBeam();
					}
				}
				if (secondShot == null)
				{
					secondShot = randomFire();
					secondShot.lazorState = LazorState.Ready;
				}
				else
				{
					if (secondShot.lazorState == LazorState.Dormant)
					{
						secondShot = null;
					}
					else
					{
						secondShot.fireBeam();
					}
				}

				if (secondShot == null && firstShot == null)
				{
					canFire = false;
				}
			}
		}
	}


	private void OnTriggerEnter2D(Collider2D collision)
    {
    	print(collision.gameObject.tag);
        if(collision.gameObject.tag == "PlayerAttack")
        {
        	attackable = false;
        	canFire = true;
			print ("Hit");

            health.takeDamage(collision.gameObject.GetComponent<Damage>().damage);
        }
    }

    lazorScript randomFire()
    {
		float platform = Random.Range(0f, 100f);
		if (platform < 33f)
		{
			return lazorLowerScript;
		}
		else if (platform < 66f)
		{
			return lazorMiddleScript;
		}
		else
		{
			return lazorTopScript;
		}
    }
}