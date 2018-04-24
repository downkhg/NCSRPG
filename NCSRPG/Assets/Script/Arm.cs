using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//코루틴을 사용하지않고 공격하기
public class Arm : MonoBehaviour {
    float m_fAttackSpeed;
    float m_fMaxRot = 45;
    float m_fCurRot = 0;
    bool m_bAttack = false;
    bool m_bRelease = false;

    private void Update()
    {
        if (m_bRelease)
            ReleaseArmUpdate();
        else if (m_bAttack)
            AttackArmUpdate();
    }

    void MoveArm(float rotSpeed)
    {
        transform.Rotate(Vector3.right * rotSpeed);
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
            m_bAttack = true;
    }

    public void Init(float Attack)
    {
        m_fAttackSpeed = Attack;
    }
}
