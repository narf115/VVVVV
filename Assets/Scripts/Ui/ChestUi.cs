using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestUi : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        Cheste.Scoree += UpdateScore;
    }
    private void OnDisable()
    {
        Cheste.Scoree -= UpdateScore;
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
