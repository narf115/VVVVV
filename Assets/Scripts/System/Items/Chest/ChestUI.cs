using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ChestUI : MonoBehaviour
{
    public static event Action<int> Chestui;
    public static int score;
    private void Start()
    {
        score = 0;
    }
    public static void Score(int a)
    {
        score += a;
        Chestui(score);
    }
}
