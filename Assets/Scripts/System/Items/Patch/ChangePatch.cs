using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangePatch : MonoBehaviour
{
    
    private void OnEnable()
    {

        PatchUi.Patchscore += UpdateScore;
    }
    private void OnDisable()
    {
        PatchUi.Patchscore -= UpdateScore;
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
