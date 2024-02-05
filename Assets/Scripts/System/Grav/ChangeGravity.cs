using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    public WarriorController player;
    GameObject player2;
    private int a = 1;
    public float localx, localy;
    // Start is called before the first frame update
    void Start()
    {
        player2 = GameObject.Find("Ninja");
        player = GetComponent<WarriorController>();
       localx = player2.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1 * a;
        Debug.Log("XD");
        
        player2.transform.localScale = new Vector3(localx, -player2.transform.localScale.y, player2.transform.localScale.z);
        
    }

}
