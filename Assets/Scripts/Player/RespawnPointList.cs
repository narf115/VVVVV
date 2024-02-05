using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointList : MonoBehaviour
{
    //public static Transform[] pointList;
    public Transform[] RespawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        RespawnPoints = GetComponentsInChildren<Transform>();
    }
}
