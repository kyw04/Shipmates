using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject numberImage;
    public GameObject SettingsPage;
    public GameObject PauseButton;
    public bool isPause = false;
    public bool unpaused = false; 
    
    private Animator animator;

    private void Start()
    {
        SettingsPage.SetActive(false);
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

    public void OnClickPause()
    {
        if (isPause == true && unpaused == false)
        {
            Debug.Log("unpause");
            animator.Play("ShowTime");
            SettingsPage.SetActive(false);
            PauseButton.SetActive(true);
            unpaused = true;
        }
        if (isPause == false)
        {
            isPause = true;
            SettingsPage.SetActive(true);
            PauseButton.SetActive(false);
            Time.timeScale = 0f;
            Debug.Log("pause");
        } 
    }
}
