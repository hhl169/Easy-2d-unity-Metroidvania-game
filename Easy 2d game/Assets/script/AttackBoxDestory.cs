using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxDestory : MonoBehaviour
{
    // Start is called before the first frame update
    public float DestoryTime = 1.0f;
    void Start()
    {
        Destroy(gameObject, DestoryTime);
    }

  
}
