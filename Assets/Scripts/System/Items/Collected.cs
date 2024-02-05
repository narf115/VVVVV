using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collected : MonoBehaviour
{
   
    public abstract void ItemCollected();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemCollected();
        
    }
}
