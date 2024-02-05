using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collected
{
    public bool IsCaught;
    public PlaySound AS;
    private void Start()
    {
        AS = GetComponent<PlaySound>();
        Cheste.Score(0);

        
    }
    private void Update()
    {
       if(IsCaught==true)
        {
            gameObject.SetActive(false);
        } 

    }
    public override void ItemCollected()
    {
        
        CollectedController.AddChest();
        AS.PlaySounds();
        IsCaught = true;
        gameObject.SetActive(false);
       
        Cheste.Score(1);
    }
    
}
