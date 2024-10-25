using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill1 : MonoBehaviour
{

    public float Speed = 1.0f;
    public GameObject Rotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Rotation.transform.rotation.y >= -1 && Rotation.transform.rotation.y < 180)
        {
            transform.Translate(new Vector3(1, 0, 0) * Speed * Time.deltaTime);
        }
        else 
        {
            transform.Translate(new Vector3(-1, 0, 0) * Speed * Time.deltaTime);
        }
    }
}
