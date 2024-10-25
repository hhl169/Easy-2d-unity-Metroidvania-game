using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSkill2 : MonoBehaviour
{

    public float Rep = 0.5f;
    public float Delay = 0.5f;
    public GameObject DamageBox;
    public GameObject StartPosition;
    public GameObject EndPosition;
  
    void Start()
    {
        InvokeRepeating("CreatBox", Delay, Rep);
    }
    public void CreatBox() 
    {
        GameObject Box = Instantiate(DamageBox, 
            StartPosition.transform .position ,
            StartPosition.transform .rotation );
        Box.transform.DOMove(EndPosition.transform.position,Rep);
    }
 
}
