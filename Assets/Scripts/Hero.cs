using UnityEngine;
using System.Collections;


public class Hero : Living {

    public Weapon weapon;
    public int Gold;
    public string Glory = "";
    public bool canAttack = true;
    public float weaponCoolDown = 0.5f;
    //public SpriteRenderer spriteRend;

   
    MoveDirection moveDirection = MoveDirection.NONE;
    void Attack()
    {
    }
    // Use this for initialization
    void Start()
    {

    }
	// Update is called once per frame
	void Update () {
        UpdateLiving();

       if (Input.GetKey(KeyCode.Space))
       { 
            weapon.Attack();

       }
       if (Input.GetKey(KeyCode.W))
        {
            dirWalk = MoveDirection.UP;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dirWalk = MoveDirection.DOWN;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dirWalk = MoveDirection.RIGHT;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dirWalk = MoveDirection.LEFT;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            dirWalk = MoveDirection.NONE;
        }

        if(dirWalk == MoveDirection.UP)
            weapon.transform.localPosition = new Vector3(0, 0.35f, 0);  
        if (dirWalk == MoveDirection.DOWN)
            weapon.transform.localPosition = new Vector3(0, -0.35f, 0);
        if (dirWalk == MoveDirection.RIGHT)
            weapon.transform.localPosition = new Vector3(0.35f, 0, 0);
        if (dirWalk == MoveDirection.LEFT)
            weapon.transform.localPosition = new Vector3(-0.35f, 0, 0);


        if(isDead)
        {
            // Youre dead, go to main Menu?
            //bug.Log("Hero has died");   
        }
            
	}
}
