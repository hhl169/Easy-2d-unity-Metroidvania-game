using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetHit : MonoBehaviour
{
    // Start is called before the first frame update
  
    [Header("Component")]
    public Animator PlayerAmi;
    public AudioSource Audiocon;
    public myfirst PlayScript;



    [Header("GetHit")]
    public GameObject GetHitEffect;
    public GameObject GetHitPosition;
    public AudioClip GetHitSound;
    public float GetHitTime = 0.5f;
    public bool ISDead = false; 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetHIT(collision);

    }
    public void GetHIT(Collider2D collision)
    {
        if (collision.tag == "EnemyAttack")
        {
            if (!PlayScript.Skill3ConB )
            {
                DoHP();
            }
            
        }
    }

    public void EndGetHit() 
    {
        PlayScript.ISAttack = false;
    }

    public void DoHP()
    {
        PlayScript.HPNow = PlayScript.HPNow - 20;

        if (PlayScript.HPNow > 0)
        {
            Audiocon.PlayOneShot(GetHitSound, SoundValue.Auido);

            PlayerAmi.SetTrigger("GetHit");

            PlayScript.ISAttack = true;

            CancelInvoke("EndGitHit");

            Invoke("EndGitHit", GetHitTime);

            Instantiate(GetHitEffect, GetHitPosition.transform.position, GetHitPosition.transform.rotation);
        }
        else
        {
            if (!ISDead)
            {
                ISDead = true;

                CancelInvoke("EndGitHit");

                PlayScript.ISAttack = true;

                PlayerAmi.SetTrigger("Dead");

                Audiocon.PlayOneShot(GetHitSound, SoundValue.Auido);

                Instantiate(GetHitEffect, GetHitPosition.transform.position, GetHitPosition.transform.rotation);
            }
        }
    }
}
