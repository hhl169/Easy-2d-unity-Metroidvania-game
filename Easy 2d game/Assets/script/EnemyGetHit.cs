using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetHit : MonoBehaviour
{
    [Header("Component")]
    public Animator EnemyAmi;
    public AudioSource Audiocon;
    public EnemyControler Controller;
     
    


    
    [Header("GetHit")]
    public GameObject GetHitEffect;
    public GameObject GetHitPosition;
    public AudioClip GetHitSound;
    public float WaitTime = 1.0f;
    public bool ISDead = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetHIT(collision);

    }
    public void GetHIT(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
            DoHP();
        }
    }

    public void InvokeGetHit()
    {
        Controller.State = EnemyState.MoveToPlayer ;
    }

    public void DoHP()
    {
        Controller.HPNow = Controller.HPNow - 25;
        if (Controller.HPNow >0)
        {
            Audiocon.PlayOneShot(GetHitSound, SoundValue.Auido);

            Controller.State = EnemyState.GetHit;

            CancelInvoke("InvokeGetHit");

            Invoke("InvokeGetHit", WaitTime);

            EnemyAmi.SetTrigger("GetHit");

            Instantiate(GetHitEffect, GetHitPosition.transform.position, GetHitPosition.transform.rotation);
        }
        else
        {
            if (ISDead == false)
            {

                Audiocon.PlayOneShot(GetHitSound, SoundValue.Auido);

                CancelInvoke("InvokeGetHit");

                ISDead = true;

                EnemyAmi.SetTrigger("Dead");

                Controller.State = EnemyState.Dead;

                Instantiate(GetHitEffect, GetHitPosition.transform.position, GetHitPosition.transform.rotation);

            }
        }
    }
}
