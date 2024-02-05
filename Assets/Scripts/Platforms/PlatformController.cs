using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private MovementBeheivor _mvb;

    public GameObject pointList;

    private int point;

    // Start is called before the first frame update
    void Start()
    {
        _mvb = GetComponent<MovementBeheivor>();

        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = pointList.GetComponent<RoteController>().pointList[point].transform.position - transform.position;
        dir.Normalize();

        _mvb.Move(dir);

        if (Vector3.Distance(transform.position, pointList.GetComponent<RoteController>().pointList[point].transform.position) < 0.1)
        {
            if (point == pointList.GetComponent<RoteController>().pointList.Length - 1)
                point = 0;
            else
                point++;
        }
         
    }
}
