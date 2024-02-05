using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : Collected
{
    public bool IsCaught;
    public PlaySound AS;
    private void Start()
    {
        AS = GetComponent<PlaySound>();
        OrbUI.Score(0);
    }
    public override void ItemCollected()
    {
         AS.PlaySounds();
        CollectedController.AddOrb();
        IsCaught = true;
        gameObject.SetActive(false);
        OrbUI.Score(1);
       


    }
    private void Update()
    {
        if (IsCaught == true)
        {
            gameObject.SetActive(false);
        }

    }
}
