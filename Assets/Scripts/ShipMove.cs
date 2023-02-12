using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShipMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject ship;
    public Transform[] postions;
    public GameObject shildImage;
    public int condition;
    [HideInInspector]
    public bool flip;
    [HideInInspector]
    public int index;

    private Animator m_Animator;
    private Animator shild_Animator;
    private float x;

    private void Start()
    {
        m_Animator = ship.GetComponent<Animator>();
        shildImage = ship.transform.GetChild(0).gameObject;
        shild_Animator = shildImage.GetComponent<Animator>();
        index = 1;
        flip = false;
        ship.transform.position = postions[index].position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        x = eventData.position.x;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        float direction = x - eventData.position.x;
        if (flip)
        {
            direction = -direction;
        }

        Move(direction);
    }

    public void Move(float direction)
    {
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
            if (shildImage.activeSelf == true)
            {
                shildImage.transform.localPosition = new Vector3(0.3f, 0.6f, 0);
                shildImage.transform.localScale = new Vector3(-1, 1, 1);
                shild_Animator.Play("Shild_2");
            }

            index = 0;
        }
        else if (index == 1)
        {
            m_Animator.Play("StandingBoat");

            if (shildImage.activeSelf == true)
            {
                shildImage.transform.localPosition = new Vector3(0, 0.5f, 0);
                shildImage.transform.localScale = Vector3.one;
                shild_Animator.Play("Shild_1");
            }
        }
        else
        {
            m_Animator.Play("RightBoat");
            if (shildImage.activeSelf == true)
            {
                shildImage.transform.localPosition = new Vector3(-0.3f, 0.6f, 0);
                shildImage.transform.localScale = new Vector3(1, 1, 1);
                shild_Animator.Play("Shild_2");
            }

            index = postions.Length - 1;
        }

        ship.transform.position = postions[index].position;
    }
}