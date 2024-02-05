using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PatchUi : MonoBehaviour
{
    public static event Action<int> Patchscore;
    public static int score;
    private void Start()
    {
        score = 0;
    }
    public static void Score(int a)
    {
        score += a;
        Patchscore(score);
    }
}
