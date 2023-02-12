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
            Debug.Log("left");
        }
        if (direction < -condition)
        {
            index++;
            Debug.Log("right");
        }

        
        if (index <= 0)
        {
            m_Animator.Play("LeftBoat");
            index = 0;
        }
        else if(index == 1)
        {
            m_Animator.Play("StandingBoat");
        }
        else
        {
            m_Animator.Play("RightBoat");
            index = postions.Length - 1;
        }

        ship.transform.position = postions[index].position;
    }
}