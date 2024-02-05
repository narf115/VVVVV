using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patch : Collected
{
    public bool IsCaught;
    public PlaySound AS;
    
    private void Start()
    {
        AS = GetComponent<PlaySound>();
        PatchUi.Score(0);
    }
    public override void ItemCollected()
    {
        AS.PlaySounds();
        CollectedController.AddPatch();
        IsCaught = true;
        PatchUi.Score(1);
        
    }
    private void Update()
    {
        if (IsCaught == true)
        {
            // gameObject.layer = LayerMask.NameToLayer("Default");
            gameObject.SetActive(false);
           
        }
        if(gameObject.activeInHierarchy== false)
        {
            Debug.Log("you");
        }
    }
    public bool GetIsCaught(bool e)
    {
        e = IsCaught;
        return e;
    }
    
}
