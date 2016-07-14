using UnityEngine;
using System.Collections;

public enum MoveDirection
{
    NONE,
    DOWN,
    UP,
    RIGHT,
    LEFT
};

public class Living : MonoBehaviour {
    public Enemy enemy;
    public MoveDirection dirWalk;
    public int damage;
    public int health;
    public int defenseRate = 0;
    public bool isDead = false;
    public float speed;
    public float knockbackTime = 2.0f;
    public float currentknockbackTime = 0;
    public SpriteRenderer spriterend;
    MoveDirection knockbackDir;

    

    public virtual void Die()
    {
        isDead = true;
        //enemy.SpawnCoin();
       
        
        //GameObject.Destroy(this);
    }

    public void KnockbackUpdate()
    {
		
        if (currentknockbackTime <= 0)
             return;
        if (currentknockbackTime > 0)
        {
            if (Time.time % 0.2 > 0.1)
            {
                spriterend.enabled = false;
            }
            else
            {
                spriterend.enabled = true;
            }
        }
        switch (knockbackDir)
        {
            case MoveDirection.RIGHT:
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;
            case MoveDirection.LEFT:
                transform.Translate(Vector3.right * -speed * Time.deltaTime);
                break;
            case MoveDirection.UP:
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                break;
            case MoveDirection.DOWN:
                transform.Translate(Vector3.up * -speed * Time.deltaTime);
                break;
        }
        
        currentknockbackTime -= Time.deltaTime;
        if(currentknockbackTime <= 0)
        {
            spriterend.enabled = true;
        }
    }
    public void Knockback(MoveDirection dir)
    { 
        currentknockbackTime = knockbackTime;
        knockbackDir = dir;
    }

    public void AddDamage(int damage)
    {
        if (currentknockbackTime > 0)
            return;
        damage -= defenseRate;
        if(damage > 0)
        {
            health -= damage;
            if(health <= 0)
            {
                Die();
            }
        }
    }
	
	// Update is called once per frame
	protected void UpdateLiving() {
        WalkUpdate();
        KnockbackUpdate();
    }

    public void WalkUpdate()
    {
        if (currentknockbackTime > 0)
            return;
        switch (dirWalk)
        {
            case MoveDirection.RIGHT:
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;
            case MoveDirection.LEFT:
                transform.Translate(Vector3.right * -speed * Time.deltaTime);
                break;
            case MoveDirection.UP:
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                break;
            case MoveDirection.DOWN:
                transform.Translate(Vector3.up * -speed * Time.deltaTime);
                break;
        }
    }
}
