using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{  // public InputField Name;
   
    public Toggle volume;
    public Toggle Music;
    
    public void saveOptions()
    {

        // PlayerPrefs.SetString("name", Name.text);
        // PlayerPrefs.SetFloat("volume",volume.value );
         int k = volume.isOn ? 1 : 0;
        PlayerPrefs.SetInt("volume", k);
       
        int f = Music.isOn ? 1 : 0;
       
        PlayerPrefs.SetInt("Music", f);
        PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetFloat("volume"));
        //Debug.Log(PlayerPrefs.GetString("name"));
       // Debug.Log(PlayerPrefs.GetInt("Volume"));
         //   Debug.Log(PlayerPrefs.GetInt("Music"));

    }
    public void LoadOptions()
    {

       // volume.value = PlayerPrefs.GetFloat("volume");
        // Name.text = PlayerPrefs.GetString("name");
        int k = PlayerPrefs.GetInt("volume");
        if (k == 0)
        {
            volume.isOn = false;
        }
        if (k == 1)
        {
            volume.isOn = true;
        }
        int f = PlayerPrefs.GetInt("Music");
        if (f == 0)
        {
            Music.isOn = false;
        }
        if (f == 1)
        {
            Music.isOn = true;
        }
    }
}
