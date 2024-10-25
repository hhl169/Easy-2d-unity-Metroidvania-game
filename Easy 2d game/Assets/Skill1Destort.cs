using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Destort : MonoBehaviour
{
    public GameObject Obj;
    public float DestroyTime = 0.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Enemy") 
        {
            Destroy(Obj, DestroyTime);
        }
       
    }


}