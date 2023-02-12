using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Animator m_Animator;

    private void Start()
    {
        m_Animator = GetComponentInChildren<Animator>();
    }

    public void SetAnimationSpeed(float _speed)
    {
        m_Animator.speed = _speed;
    }
}
