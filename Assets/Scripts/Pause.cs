using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pause : MonoBehaviour
{
    public GameObject numberImage;
    public bool isPause = false;
    public bool unpaused = false;
    
    private Animator animator;

    private void Start()
    {
        animator = numberImage.GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            Debug.Log("2");
            unpaused = false;
            isPause = false;
            Time.timeScale = 1f;
        }
    }

    public void OnClick()
    {
        if (isPause == true && unpaused == false)
        {
            Debug.Log("unpause");
            animator.Play("ShowTime");
            unpaused = true;
        }
        if (isPause == false)
        {
            isPause = true;
            Time.timeScale = 0f;
            Debug.Log("pause");
        }

       
    }
}
