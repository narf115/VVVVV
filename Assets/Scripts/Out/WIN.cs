using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIN : MonoBehaviour
{
    int t;
    private CollectedController Cs;
    private void Start()
    {
        t = 0;
        Cs = GetComponent<CollectedController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        Cs.gete(t);
        Debug.Log(Cs.gete(t));
        if (Cs.gete(t) >= 17)
        {
            Debug.Log("Pipo Vive, la Lucha Sigue");
           
            SceneManager.LoadScene("Win");
        }
        else
        {
            
            SceneManager.LoadScene("GameOver");
        }
    }
}
