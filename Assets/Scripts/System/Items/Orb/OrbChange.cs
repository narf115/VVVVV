using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrbChange : MonoBehaviour
{
    
    private void OnEnable()
    {
       
        OrbUI.Orbscore += UpdateScore;
    }
    private void OnDisable()
    {
        OrbUI.Orbscore -= UpdateScore;
    }

    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "=0";
       
    }

    public void UpdateScore(int score)
    {
        GetComponent<TextMeshProUGUI>().text = "=" + score;
    }
}
