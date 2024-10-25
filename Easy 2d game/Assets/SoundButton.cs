using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    public GameObject SoundUI;
    public bool SoundTrue = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Down()
    {
        if (SoundTrue)
        {
            SoundUI.SetActive(false);
            SoundTrue = false;
        }
        else
        {
            SoundUI.SetActive(true);
            SoundTrue = true;
        }
    
    }
}
