using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity1 : MonoBehaviour
{
    public WarriorController player;
    private int a = 1;
    public float localx,localy;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<WarriorController>();
        localx = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1*a;
        Debug.Log("XD");
        localy = transform.localScale.y * -1;
        transform.localScale = new Vector3(localx, -localy, transform.localScale.z);
        if(a==1)
        {
            
            a = -1;
        }
        if(a==-1)
        {
            
            a = 1;
        }
    }
   
}
