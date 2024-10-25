using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnd : MonoBehaviour
{
    [Header("Component")]
    public Animator CharacterAni;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag =="Ground") 
        {
            CharacterAni.SetBool("ISJump", false);
        }
    }
    void OnTriggerExit2D(Collider2D collision)

    {
        if (collision.tag == "Ground")
        {
            CharacterAni.SetBool("ISJump", true);

        }
    }
}
