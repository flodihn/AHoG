using UnityEngine;
using System.Collections;
using System;

public class Enemy : Living {

    

    public Coin coin;
    private Transform myTransform;
    public float projCooldown = 3;
    public Vector3 startPos;
    public GameObject dropPrefab;
    public GameObject hero;
    public GameObject projectilePrefab;
    public float timeToChange = 2f;
    public bool bCanSeeHero = false;

    Rigidbody2D rbody;

    void Awake()
    {
        myTransform = transform;
    }

	// Use this for initialization
	void Start () {
       //ooin = GameObject.FindGameObjectWithTag("Coin").GetComponent<Coin>();
        startPos = transform.position;
        dirWalk = (MoveDirection)UnityEngine.Random.Range(1, 5);
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    }
	
	// Update is called once per frame
	 void Update () {
        UpdateLiving();
        MovementLogic();
        
	}
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Hero")
            return;
        Living hero = col.gameObject.GetComponent<Living>();
        hero.AddDamage(damage);
        Vector3 dir = transform.position -col .gameObject.transform.position;
        hero.Knockback(dirWalk);
    }
    public void MovementLogic()
    {
        projCooldown -= Time.deltaTime;
        rbody = GetComponent<Rigidbody2D>();
        float distance = Vector3.Distance(transform.position, startPos);
        timeToChange -= Time.deltaTime;

        if (timeToChange <= 0)
        {
            if (distance < 3.0f)
            {
                dirWalk = (MoveDirection)UnityEngine.Random.Range(1, 5);
            }
            else
            {
                dirWalk = GetWalkBackDirection();
            }
            timeToChange = 1f;
        }
    }

    public void FireProj()
    {
        GameObject projectileObj = (GameObject)Instantiate(
            projectilePrefab,
            transform.position,
            transform.rotation);
        Projectile projectile = projectileObj.GetComponent<Projectile>();
        projectile.direction = dirWalk;
        projectile.damage = damage;
        projCooldown = 3f;
    }

    MoveDirection GetWalkBackDirection()
    {
        Vector3 dirFromStartPos = transform.position - startPos;
        if (Mathf.Abs(dirFromStartPos.x) > Mathf.Abs(dirFromStartPos.y))
        {
            if (dirFromStartPos.x > 0)
            {
                return MoveDirection.LEFT;
            }
            else
            {
                return MoveDirection.RIGHT;
            }
        }
        else
        {
            if (dirFromStartPos.y > 0)
            {
                return MoveDirection.DOWN;
            }
            else
            {
                return MoveDirection.UP;
            }
        }
        //return MoveDirection.NONE;
    }

    public virtual void SpawnCoin()
    {
        Debug.Log("Spawned a coin");
        GameObject coinObj = (GameObject)GameObject.Instantiate(
            dropPrefab,
            transform.position,
            Quaternion.identity);
        Coin coin = coinObj.GetComponent<Coin>();
    }
    
    /*public override void Die()
    {
        isDead = true;
        //SpawnCoin();
        
        


    }*/


}
