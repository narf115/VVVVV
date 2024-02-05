using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RespawnManager : MonoBehaviour
{
    
    public WarriorController war;
    //public Transform points;
   
    public  Vector3 Check;
    public GameObject po;
    public int point;
    public int lastcheck;
   
    // Start is called before the first frame update
    private void Start()
    {
        // war = GetComponent<WarriorController>();
      
    }
    private void Update()
    {
      
        if((Input.GetKey(KeyCode.R)))
        {

            
            Respawn(war);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            Check = new Vector3(0, 0, 0);
            Check = po.GetComponent<RespawnPointList>().RespawnPoints[point].transform.position;
            war.CheckPoint = Check;
            Debug.Log(Check);
       
    }
  
    public void Respawn(WarriorController war)
    {

        Debug.Log(Check);
       
        war.transform.position = war.CheckPoint;
        
        // rb.velocity = new Vector2(0, 0);

    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Check = new Vector3(this.po.transform.position.x, this.po.transform.position.y, this.po.transform.position.z);
        
       
    }
  
    public void Respawn()
    {

        Debug.Log(Check);
        war.CheckPoint = Check;
        war.transform.position = war.CheckPoint;
        
        // rb.velocity = new Vector2(0, 0);

    }
    */
}
