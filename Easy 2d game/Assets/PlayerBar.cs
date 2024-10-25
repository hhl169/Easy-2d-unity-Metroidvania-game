using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBar : MonoBehaviour
{

    public myfirst PlayScr;
    public Slider Slider1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Slider1.value = PlayScr.HPNow / PlayScr.HP;
    }
}
