using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    private Animator anim;
    private MovementBeheivor mv;
    private SpriteRenderer spr;
    private Rigidbody2D _Rb;
    private GroundChecker GC;
    [SerializeField]
    public float Jumpspeed = 0;
    public float Grav;
    private float localx;
    
    public int firestate;
    public Vector3 CheckPoint;
    
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        mv = GetComponent<MovementBeheivor>();
        _Rb = GetComponent<Rigidbody2D>();
        GC = GetComponent<GroundChecker>();
        localx = transform.localScale.x;
       
        
    }

    // Update is called once per frame
    void Update()
    {   
        float dirx = Input.GetAxisRaw("Horizontal");
        mv.MoveRB( new Vector3(dirx*mv.GetVelocity(),_Rb.velocity.y, 0));
       // _Rb.velocity = new Vector3(5 * dirx, _Rb.velocity.y, 0);
       
        if (dirx > 0)
        {
            
            anim.SetInteger("State", 1);
            //spr.flipX = false;
            transform.localScale = new Vector3(localx, transform.localScale.y, transform.localScale.z);
        }
       
        if (dirx < 0)
        {
            
            anim.SetInteger("State", 1);
            //spr.flipX = true;
            transform.localScale = new Vector3(-localx, transform.localScale.y, transform.localScale.z);
        }
        
        if (dirx==0)
        {
            dirx = 0;
            anim.SetInteger("State", 0);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Physics2D.gravity = new Vector2(0, 9.8f * -1);
            
            // _Rb.velocity += new Vector2(0, Jumpspeed);
            _Rb.velocity += new Vector2(0, Jumpspeed);
            _Rb.gravityScale = _Rb.gravityScale *Grav;
            transform.localScale = new Vector3(localx, -transform.localScale.y, transform.localScale.z);
            firestate = firestate * -1;
            
        }
      /*  if (Input.GetKeyDown(KeyCode.Space) && (GC._isOnGround == true))
        {
            //Physics2D.gravity = new Vector2(0, 9.8f * -1);

            // _Rb.velocity += new Vector2(0, Jumpspeed);
            _Rb.velocity += new Vector2(0, Jumpspeed);
            _Rb.gravityScale = _Rb.gravityScale * Grav;
            transform.localScale = new Vector3(localx, -transform.localScale.y, transform.localScale.z);
        }
      */
    }
    public void ChangeSprite()
    {
        
            transform.localScale = new Vector3(localx, transform.localScale.y, transform.localScale.z);

        
    }
}
