using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class SoundValue : MonoBehaviour
{
    public static float Auido = 0.8f;
    public static float Music = 0.8f;

    public Slider SliderAduio;
    public Slider SliderMusic;


    public AudioSource AudioSourceMain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioChange()
    {

        Auido = SliderAduio.value;
    
    }
    public void MusicChange()
    {
        Music = SliderMusic.value;
        AudioSourceMain.volume = Music ;

    }


}
