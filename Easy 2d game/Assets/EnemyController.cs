using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyMoveDir
{
    PatrolIdle,
    MoveLeft,
    MoveRight

}

public enum EnemyState
{
    Patrol,
    MoveToPlayer,
    Attack,
    GetHit,
    Dead
}


public class EnemyControler : MonoBehaviour
{
    [Header("Location")]
    public GameObject LocationCenter;
    public GameObject LocationLeft;
    public GameObject LocationRight;
    public GameObject LocationTarget;

    public float EnemyDistance = 0;
    public float CenterDistance = 0;
    public float WalkDistance =5;
    public float AttackDistance =1;
    public float WaitTime = 2;
    
    public EnemyMoveDir MoveDir = EnemyMoveDir.MoveLeft;
    public EnemyState State = EnemyState.Patrol;

    [Header("Enemy")]
    public float Speed = 1;
    public float AttackTime = 2;
    public float HP = 100;
    public float HPNow = 100;




    [Header("Component")]
    public Animator EnemyAni;
    public GameObject EnemyObjects;
    public GameObject EnemyModle;

    private GameObject Player;
    private bool CanAttack=true;
    private bool ISDeadC = false;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Distance();
        if (State == EnemyState.Patrol)
        {
            PatrolMove();
            if (CenterDistance<= WalkDistance)
            {
                State = EnemyState.MoveToPlayer;
            }
        }

        else if (State == EnemyState.MoveToPlayer)
        {
            MoveTo();
            if (CenterDistance > WalkDistance)
            {
                State = EnemyState.Patrol;
            }
            else if (EnemyDistance <= AttackDistance)
            {
                State = EnemyState.Attack;
            }
        }
        else if (State == EnemyState.Attack )
        {
            Attack();      
        }

        else if (State == EnemyState.GetHit )
        {
            EnemyAni.SetBool("IsRun", false );
        }
        else if (State == EnemyState.Dead )
        {
            if (ISDeadC == false)
            {
                ISDeadC = true;
                Destroy(EnemyObjects, 2.0f);
            }
        }
    }
    
    public void Distance ()
    {
        EnemyDistance = Vector2.Distance(transform.position, Player.transform.position);

        CenterDistance = Vector2.Distance(transform.position, Player.transform.position);
    }
    #region  Patrol
    public void PatrolMove()
    {

        if (MoveDir == EnemyMoveDir.MoveLeft)
        {
            LocationTarget = LocationLeft;
            EnemyAni.SetBool("IsRun", true);
            PatrolMoveLAR();
            if (transform.position.x == LocationLeft.transform.position.x)
            {
                MoveDir = EnemyMoveDir.PatrolIdle;
                Invoke("InvokeLeft", WaitTime);
            }
        }
        else if (MoveDir == EnemyMoveDir.MoveRight)
        {
            LocationTarget = LocationRight;
            EnemyAni.SetBool("IsRun", true);
            PatrolMoveLAR();
            if (transform.position.x == LocationRight.transform.position.x)
            {
                MoveDir = EnemyMoveDir.PatrolIdle;
                Invoke("InvokeRight", WaitTime);
            }
        }
        else
        {
            EnemyAni.SetBool("IsRun", false);
        }  

    }
    public void PatrolMoveLAR()
    {
        Vector3 LocationEnd = LocationTarget.transform.position;
        LocationEnd.y = transform.position.y;

        transform.position = Vector2.MoveTowards(transform.position, LocationEnd, Speed * Time.deltaTime);

        Vector3 Dirction = (LocationEnd - transform.position).normalized;

        if (Dirction.x > 0)
        {

            EnemyModle.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Dirction.x < 0)
        {
            EnemyModle.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }

    public void InvokeLeft()
    {
        MoveDir = EnemyMoveDir.MoveRight;


    }
    public void InvokeRight()
    {
        MoveDir = EnemyMoveDir.MoveLeft;

    }

    #endregion

    public void MoveTo()
    {
        EnemyAni.SetBool("IsRun", true);
        Vector3 LocationEnd = Player.transform.position;

        LocationEnd.y = transform.position.y;

        transform.position = Vector2.MoveTowards(transform.position, LocationEnd, Speed * Time.deltaTime);

        Vector3 Dirction = (LocationEnd - transform.position).normalized;

        if (Dirction.x > 0)
        {

            EnemyModle.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Dirction.x < 0)
        {
            EnemyModle.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }

    public void Attack()
    {
        EnemyAni.SetBool("IsRun", false );
        if (CanAttack == true)
        {
            CanAttack = false;
            EnemyAni.SetTrigger("Attack");
            Invoke("AttackEnd", AttackTime);
        }
    
    }
    public void AttackEnd()
    {
        CanAttack = true;
        if (EnemyDistance > AttackDistance)
        {
            State = EnemyState.MoveToPlayer;
        }
        else if (CenterDistance > WalkDistance)
        {
            State = EnemyState.Patrol;
        }
    }
}
