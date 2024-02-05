using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    private MovementBeheivor _mvb;

    public GameObject pointList;

    private int point;

    public bool PingPong;
    int n = 1;
    // Start is called before the first frame update
    void Start()
    {
        _mvb = GetComponent<MovementBeheivor>();

        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = pointList.GetComponent<RouteController>().pointList[point].transform.position - transform.position;
        dir.Normalize();

        _mvb.Move(dir);

        if (Vector3.Distance(transform.position, pointList.GetComponent<RouteController>().pointList[point].transform.position) < 0.1)
        {
            if (PingPong == false)
            {
                if (point == pointList.GetComponent<RouteController>().pointList.Length - 1)
                    point=0;

                else
                {
                    point++;
                    Debug.Log(point);
                }
            }
            if(PingPong==true)
            {
                if (point == pointList.GetComponent<RouteController>().pointList.Length -n)

                {
                    point--;
                    n++;
                    
                    if(point==0)
                    {
                        n = 1;
                    }

                }
                else
                {
                    point++;
                    Debug.Log(point);
                }
            }
        }

    }
}
