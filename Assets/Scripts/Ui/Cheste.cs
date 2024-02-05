using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cheste : MonoBehaviour
{
    public static event Action<int> Scoree;
    public static int score;
    private void Start()
    {
        score = 0;
    }
    public static void Score(int a)
    {
        score += a;
        Scoree(score);
    }
}
