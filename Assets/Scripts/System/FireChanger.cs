using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireChanger : MonoBehaviour
{
    public GameObject fire;
    public WarriorController player;
    private SpriteRenderer spr;
    private Animator anim;
    GameObject playerfire;
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerfire = GameObject.Find("Ninja");
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("State", playerfire.GetComponent<WarriorController>().firestate);
    }
   
    
}
