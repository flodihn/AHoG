using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon : MonoBehaviour {
    
    public Hero hero;
    public List<Living> enemies =  new List<Living>();
    public List<Living> damagedEnemies = new List<Living>();


    public void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
    }
   public void Attack()
    { 
        // Living Enemys list
        foreach (Living enemy in enemies)
        {
            enemy.AddDamage(hero.damage);
            enemy.Knockback(hero.dirWalk);
            damagedEnemies.Add(enemy);
        }

        foreach (Living enemy in damagedEnemies)
        {
            if (!enemy.isDead)
                continue;
            enemies.Remove(enemy);
            GameObject.Destroy(enemy.gameObject);
            //SpawnCoin();
            Debug.Log("Destory Enemy?");
            
            

        }
        damagedEnemies.Clear();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            Living enemy = col.gameObject.GetComponent<Living>();
            if (enemy == null)
                return;

            enemies.Add(enemy);
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            Living enemy = col.gameObject.GetComponent<Living>();
            enemies.Remove(enemy);
        }
    }  
}
