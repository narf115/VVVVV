using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spr;
    private MovementBeheivor mvn;
    //private PoolingManager pmg;
    private Vector3 dir,s1,s2;
    //private HealthBeheivor hc;
  //  private Shoot sh;
    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        mvn = GetComponent<MovementBeheivor>();
      //  pmg = GetComponent<PoolingManager>();
       // sh = GetComponent<Shoot>();
        //hc = GetComponent<HealthBeheivor>();
       
    }

    private void FixedUpdate()
    {
         dir.Normalize();
        mvn.MovePosition(dir);
        
    }
    // Update is called once per frame
    void Update()
    {
       float hor= Input.GetAxisRaw("Horizontal"); // eje a-d  <- ->
        float ver= Input.GetAxisRaw("Vertical"); // eje w-s ^ v 
        
        dir = new Vector3(hor, ver, 0);

        if (hor>0)
        {
            anim.SetInteger("state", 1);
            spr.flipX = false;
        }
        if(hor<0)
        {
            anim.SetInteger("state", 1);
            spr.flipX = true;
        }
        if(ver>0)
        {
            anim.SetInteger("state", 2);
            spr.flipX = false;
        }
        if(ver<0)
        {
            anim.SetInteger("state", 3);
            spr.flipX = false;
        }
        if (ver == 0 && hor == 0)
        {
            anim.SetInteger("state", 0);
        }
        if(Input.GetKeyDown(KeyCode.Space))
         {
            if (dir == new Vector3(0, 0, 0))
            {
                
               // sh.Shoots(transform.position, -transform.up);

            }
            else
            {
               // sh.Shoots(transform.position, dir);
              
                
            }
        }
       
        
       /* if (hc.health<=0)
        {
            anim.SetInteger("state", 5);

            if (hc.health <= 0)
            {
                player.GetComponent<HealthBeheivor>().DeathPlayer();
            }
        } 
      */
        
        /* if (Input.GetKey(KeyCode.A))
         {
            anim.SetInteger("state", 1);
             spr.flipX = false;
             mvn.MovePosition(Vector3.left);
         }
         if (Input.GetKey(KeyCode.D))
         {
             anim.SetInteger("state", 1);
             spr.flipX = true;
             mvn.MovePosition(Vector3.right);

         }
         
         if (Input.GetKey(KeyCode.W))
         {
             anim.SetInteger("state", 2);
             mvn.MovePosition(Vector3.up);

         }
         if (Input.GetKey(KeyCode.S))
         {
             anim.SetInteger("state", 3);
             mvn.MovePosition(Vector3.down);

         }
         if (!Input.anyKey)
         {
             anim.SetInteger("state", 0);
         }
        */
    }
      
    
}
