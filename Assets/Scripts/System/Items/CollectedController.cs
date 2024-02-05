using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedController : MonoBehaviour
{
    static int Chest, Patch, Orb;
    // Start is called before the first frame update
    void Start()
    {
        Chest = 0;
        Patch = 0;
        Orb = 0;
        
    }
    public static void AddChest()
    {
        Chest++;
        
    }
    public static void AddPatch()
    {
        Patch++;
    }
    public static void AddOrb()
    {
        Orb++;
    }
   
    public int gete(int e)
    {
        e = Chest + Patch + Orb;
        Debug.Log(e);
        return e;
    }
    public int getC(int e)
    {
        e = Chest ;
        Debug.Log(e);
        return e;
    }
    public int getO(int e)
    {
        e =  Orb ;
        Debug.Log(e);
        return e;
    }
    public int getP(int e)
    {
        e =  Patch;
        Debug.Log(e);
        return e;
    }
}
