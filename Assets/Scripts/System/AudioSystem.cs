using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private static bool created = false;
    private OptionsManager mg;
    void Awake()
    {
        if (!created)
        {

            DontDestroyOnLoad(this.gameObject);
            created = true;

        }

    }
    private void OnDisable()
    {
        
    }
}
