using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myfirst : MonoBehaviour
{
    #region parameters

    [Header("Character")]

    public float Speed = 1.0f;
    public float JumpForce = 10.0f;
    public float HP = 100;
    public float HPNow = 100;


    [Header("Teleportation")]
    public bool CanTel=true ;
    public bool Teling = false;
    public float TelDe = 1.0f;
    public float TelInterval = 2.0f;
    public float TelRead = 1.2f;
    public float TelSpeed = 18.0f;
    public AudioClip TelSound;

   [Header("Attack")]
    public float AttackInterval = 1.0f;
    public GameObject AttackBox;
    public GameObject AttackLocation;
    public AudioClip AttackSound;


    [Header("Skill1")]
    public bool CanSkill1 = true;
    public float  Skill1Read = 1.2f;
    public float Skill1Interval = 5.0f;
    public GameObject Skill1Box;
    public GameObject Skill1Location;
    public AudioClip Skill1Sound;

    [Header("Skill2")]
    public bool CanSkill2 = true;
    public float Skill2Read = 1.2f;
    public float Skill2Interval = 5.0f;
    public GameObject Skill2Box;
    public GameObject Skill2Location;
    public AudioClip Skill2Sound;

    [Header("Skill3")]
    public bool CanSkill3 = true;
    public bool Skill3ConB = false;
    public float Skill3Read = 1.0f;
    public float Skill3Interval = 10.0f;
    public float Skill3ConTime = 2.0f;
    public GameObject Skill3Box;
    public GameObject Skill3Location;
    public AudioClip Skill3Sound;

    [Header("Component")]

    public Rigidbody2D CharacterRig;
    public Animator CharacterAni;
    public GameObject CharacterModel;
    public GameObject SkillEffect;
    public AudioSource AudioCon;
    public AudioClip SkillConSound;
   

    public  bool ISAttack = false;
    private bool CanAttack = true;

    #endregion
    void Start()
    {
        HPNow = HP;
    }

    // Update is called once per frame
    void Update()
    {

        Move();//�ƶ��߼�
        Jump();//��Ծ�߼�
        Attack();
    }

    #region CharacterColtrol

    public void Move()
    {
        //(�ƶ��߼�)��ȡ�������
        float XInput = Input.GetAxisRaw("Horizontal");
        float YInput = Input.GetAxisRaw("Vertical");

       
        if (Teling ==true) 
        {
            //���
            CharacterRig.velocity = new Vector2(TelSpeed*TelDe , 0);
        }
        else
        {
            if (ISAttack == true)  //�������Ƿ��ڹ���״̬ ��ֹ��������
            {
                XInput = 0;

            }
            //(�ƶ��߼�)����������߿���
            CharacterRig.velocity = new Vector2(XInput * Speed, CharacterRig.velocity.y);
            CharacterAni.SetFloat("RunBlend", Mathf.Abs(XInput));
 
            //�����л��߼�
            if (XInput > 0)
            {
                TelDe = 1;
                CharacterModel.transform.rotation = Quaternion.Euler(0, 0, 0);
                
            }
            else if (XInput < 0)
            {
                TelDe = -1;
                CharacterModel.transform.rotation = Quaternion.Euler(0, 180, 0);
                
            }
            else
            {

            }

        }
        
      
    }

    public void Jump()
    {
        //��Ծ�߼�
        bool ISJump = CharacterAni.GetBool("ISJump");
        if (ISAttack == false)   //�������Ƿ��ڹ���״̬  ��ֹ��Ծ����
        {
            if (Input.GetKeyDown(KeyCode.Space) && !ISJump)
            {

                CharacterRig.velocity = new Vector2(CharacterRig.velocity.x, JumpForce);
            }
        }
        
    }

    #endregion
    
    public void Attack() 
    {
        if (CanAttack)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {

                CanAttack = false;
                CharacterAni.SetTrigger("Attack");
                Invoke("AttackEnd", AttackInterval);  //�������invoke �������Ҷ���ʱ����ʵ�ּ��
                AudioCon.PlayOneShot(AttackSound,SoundValue.Auido );
            }

            else if (Input.GetKeyDown(KeyCode.K))
            {
                if (CanSkill1)
                {
                    CanSkill1 = false;
                    CanAttack = false;
                    CharacterAni.SetTrigger("SkillStart");
                    Invoke("Skill1End", Skill1Read);
                    AttackStartEvent();
                    SkillStartEffect();

                }
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                if (CanSkill2)
                {
                    CanSkill2 = false;
                    CanAttack = false;
                    CharacterAni.SetTrigger("SkillStart");
                    Invoke("Skill2End", Skill2Read);
                    AttackStartEvent();
                    SkillStartEffect();

                }
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                if (CanSkill3)
                {
                    CanSkill3 = false;
                    CanAttack = false;
                    CharacterAni.SetTrigger("SkillStart");
                    Invoke("Skill3End", Skill3Read);
                    AttackStartEvent();
                    SkillStartEffect();

                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (CanTel)
                {
                    AudioCon.PlayOneShot(TelSound, SoundValue.Auido);
                    CanTel = false;
                    CanAttack = false;
                    Teling = true;
                    CharacterAni.SetTrigger("TelStart");
                    Invoke("AttackEnd", AttackInterval);
                    Invoke("TelEnd", TelRead);
                    AttackStartEvent();
                   

                }
            }
        }
    }
    #region Attack
    public void AttackEnd() 
    {
        CanAttack = true;

    }
    public void AttackStartEvent()
    {

        ISAttack = true;
        AudioCon.PlayOneShot(SkillConSound, SoundValue.Auido);

     }
    public void AttackingEvent()
    {
        Instantiate(AttackBox, AttackLocation.transform.position, AttackLocation.transform.rotation);//�������ָ��λ�����ɶ�����Ч��ָ����Ч��λ�ã�

    }
    public void AttackEndEvent() 
    { 
        ISAttack =false;

    }


    public void SkillStartEffect()
    {
        SkillEffect.SetActive (true) ;
        AudioCon.PlayOneShot(SkillConSound, SoundValue.Auido);

    }
    public void SkillEndEffect()
    {
        SkillEffect.SetActive (false);

    }
    #endregion

    #region Skill
    public void Skill1End() 
    {
        AudioCon.PlayOneShot(Skill1Sound, SoundValue.Auido);
        CharacterAni.SetTrigger("SkillEnd");
        Instantiate(Skill1Box, Skill1Location.transform.position, Skill1Location.transform.rotation);
        Invoke("AttackEnd", AttackInterval);
        Invoke("Skill1Restart", Skill1Interval);
        AttackEndEvent();
        SkillEndEffect();
    }
    public void Skill1Restart()
    {
        CanSkill1 = true;
    }
    public void Skill2End()
    {
        AudioCon.PlayOneShot(Skill2Sound, SoundValue.Auido);
        CharacterAni.SetTrigger("SkillEnd");
        Instantiate(Skill2Box, Skill2Location.transform.position, Skill2Location.transform.rotation);
        Invoke("AttackEnd", AttackInterval);
        Invoke("Skill2Restart", Skill2Interval);
        AttackEndEvent();
        SkillEndEffect();
    }
    public void Skill2Restart()
    {
        CanSkill2 = true;
    }

    public void Skill3End()
    {
        AudioCon.PlayOneShot(Skill3Sound, SoundValue.Auido);
        CharacterAni.SetTrigger("SkillEnd");
        //Instantiate(Skill3Box, Skill3Location.transform.position, Skill3Location.transform.rotation);
        Skill3Box.SetActive(true);
        Invoke("Skill3Con", Skill3ConTime);//���ܳ���ʱ��
        Invoke("AttackEnd", AttackInterval);
        Invoke("Skill3Restart", Skill3Interval);
        Skill3ConB = true;  
        AttackEndEvent();
        SkillEndEffect();
    }
    public void Skill3Con() 
    {
        Skill3ConB = false ;

        Skill3Box.SetActive(false);

    }

    public void Skill3Restart()
    {
        CanSkill3 = true;
    }


    #endregion



    public void TelEnd()
    {
        Teling = false;
        CharacterAni.SetTrigger("TelEnd");
        Invoke("TelRestart", TelInterval);
        AttackEndEvent();
       

    }
    public void TelRestart()
    {
        CanTel = true;
    }

}

//�����߼��л������
//CharacterAni.Play("Idle");
//ʹ�ø��߼���Ծʱ����ײǽ��Ҳ�������Ծ����  ֱ�Ӹ�ĸ���һ���ŵ�С����trigger�����ƽŵ��Ƿ���ײ��������Ծ����
//void OnCollisionEnter2D(Collision2D collision)
//{
//    CharacterAni.SetBool("ISJump", false );
//}