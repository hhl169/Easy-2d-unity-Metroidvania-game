using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public GameObject AttackBox;
    public GameObject AttackLocation;
    public void Attack() 
    {
        Instantiate(AttackBox, AttackLocation.transform.position, AttackLocation.transform.rotation);
    }
}
