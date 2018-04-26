using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//코루틴을 사용하지않고 공격하기
public class Arm : MonoBehaviour {
    public Player m_cPlayer;
    public Player m_cTarget;
    public Wepon m_cWepon;
    float m_fAttackSpeed;
    float m_fMaxRot = 45;
    float m_fCurRot = 0;
    bool m_bAttack = false;
    bool m_bRelease = false;

    private void Update()
    {
        //if (m_bRelease)
        //    ReleaseArmUpdate();
        //else if (m_bAttack)
        //    AttackArmUpdate();

        //if (m_cWepon.Hit && m_cTarget != null)
        //{
        //    m_cPlayer.Attack(m_cTarget);
        //    Debug.Log("Attcak:"+m_cTarget.Name);
        //}
    }

    void MoveArm(float rotSpeed)
    {
        transform.Rotate(Vector3.right * rotSpeed);
    }
    //코루틴을 사용하면, 매 프레임마다 반복문의 한스탭이 실행되므로,
    //따로 끝날때 처리를 하지않아도되고, 해당반복의 스탭이 끝나면 실행이 끝난다.
    //실행중 지역변수들은 코루틴이 끝날때까지 유지된다.
    IEnumerator AttackArm()
    {
        float fMaxRot = 45;
        float fCurRot = 0;

        while (fCurRot < fMaxRot)
        {
            //매프레임마다 실행
            MoveArm(m_fAttackSpeed);
            fCurRot += m_fAttackSpeed;
            yield return null; //다음 프레임으로.
        }

        StartCoroutine("ReleaseArm");
    }
    IEnumerator ReleaseArm()
    {
        float fMaxRot = 45;
        float fCurRot = 0;

        while (fCurRot < fMaxRot)
        {
            MoveArm(-m_fAttackSpeed);
            fCurRot += m_fAttackSpeed;
            yield return null;
        }

        m_bAttack = false;
    }

    //코루틴을 사용하지않은 경우 멤버변수로 만들어, 
    //매프레임마다 호출확인을 해야한다.
    void AttackArmUpdate()
    {
        if (m_fCurRot < m_fMaxRot)
        {
            MoveArm(m_fAttackSpeed);
            m_fCurRot += m_fAttackSpeed;
            Debug.Log(string.Format("CurRot:{0}/{1}", m_fCurRot, m_fMaxRot));
        }
        else
        {
            m_fCurRot = 0;
            m_bRelease = true;
        }
    }
    void ReleaseArmUpdate()
    {
        if (m_fCurRot < m_fMaxRot)
        {
            MoveArm(-m_fAttackSpeed);
            m_fCurRot += m_fAttackSpeed;
            Debug.Log(string.Format("CurRot:{0}/{1}", m_fCurRot, m_fMaxRot));
        }
        else
        {
            m_bAttack = false;
            m_bRelease = false;
            m_fCurRot = 0;
        }
    }

    public void Attack()
    {
        if (m_bAttack == false)
        {
            m_bAttack = true;
            
            StartCoroutine("AttackArm");
        }
    }

    public void Init(float Attack,Player cPlayer)
    {
        m_fAttackSpeed = Attack;
        m_cPlayer = cPlayer;
    }
}
