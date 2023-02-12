using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShipMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject ship;
    public Transform[] postions;
    public int condition;

    private Animator m_Animator;
    private float x;
    private int index;

    private void Start()
    {
        m_Animator = ship.GetComponent<Animator>();
        index = 1;

        ship.transform.position = postions[index].position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        x = eventData.position.x;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        float direction = x - eventData.position.x;
        if (direction > condition)
        {
            index--;
            m_Animator.Play("LeftBoat");
            Debug.Log("left");
        }
        if (direction < -condition)
        {
            index++;
            m_Animator.Play("RightBoat");
            Debug.Log("right");
        }
        if (index == 1)
        {
            m_Animator.Play("StandingBoat");
        }

        ship.transform.position = postions[index].position;
    }
}