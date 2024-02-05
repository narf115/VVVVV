using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoteController : MonoBehaviour
{
    //public static Transform[] pointList;
    public Transform[] pointList;
    // Start is called before the first frame update
    void Start()
    {
        pointList = GetComponentsInChildren<Transform>();
    }

}
