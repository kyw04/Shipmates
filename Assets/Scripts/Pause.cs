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

    public void OnClick()
    {
        if(isPause == false)
        {
            isPause = true;
            Time.timeScale = 0f;
            Debug.Log("pause");
        }
        else if(isPause == true && unpaused == false) 
        {
            Debug.Log("unpause");
            animator.Play("ShowTime");
            unpaused = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle") && unpaused == true)
        {
            unpaused = false;
            Time.timeScale = 1f;
        }
    }
}
