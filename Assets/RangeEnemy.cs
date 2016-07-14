using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class RangeEnemy : Enemy {
    
    public float projSpeed = 1;
    public GameObject Hero;
    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }
	// Use this for initialization
	void Start () {
        startPos = transform.position;
        dirWalk = (MoveDirection) UnityEngine.Random.Range(1, 5);

    }
	// Update is called once per frame
	void Update()
    {
        UpdateLiving();
        MovementLogic();
        if (Time.deltaTime >= projCooldown)
        {
            FireProj();
            

        }
    }
    
}
