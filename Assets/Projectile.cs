using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour
{
    public int damage = 1;
    // the object that will be spawned
    public Rigidbody2D rbody;
    public float projSpeed = 2f;
    public MoveDirection direction;
    public Vector3 startPos;

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case MoveDirection.RIGHT:
                transform.Translate(Vector3.right * projSpeed * Time.deltaTime);
                break;
            case MoveDirection.LEFT:
                transform.Translate(Vector3.right * -projSpeed * Time.deltaTime);
                break;
            case MoveDirection.UP:
                transform.Translate(Vector3.up * projSpeed * Time.deltaTime);
                break;
            case MoveDirection.DOWN:
               transform.Translate(Vector3.up * -projSpeed * Time.deltaTime);
                break;
        }
        float distance = Vector3.Distance(transform.position, startPos);
        if (distance > 10f)
        {
            GameObject.Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Hero")
        {
            Hero hero = col.gameObject.GetComponent<Hero>();
            hero.AddDamage(damage);
            hero.Knockback(hero.dirWalk);
        }
    }
}