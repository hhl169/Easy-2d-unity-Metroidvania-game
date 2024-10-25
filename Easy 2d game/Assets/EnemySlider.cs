using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySlider : MonoBehaviour
{

    public EnemyControler EnemyScr;
    public Slider Slider2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Slider2.value = EnemyScr.HPNow / EnemyScr.HP;
    }
}
