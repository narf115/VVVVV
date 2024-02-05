using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public Transform groundChecker;
    public float radius;
    public LayerMask layerground;
    public bool _isOnGround;

    public bool isOnGround()
    {
        return _isOnGround;

    }
   

    // Update is called once per frame
    void Update()
    {
        _isOnGround = Physics2D.OverlapCircle(groundChecker.position, radius, layerground);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundChecker.position, radius);
    }


}
