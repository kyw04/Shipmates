using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Ship : MonoBehaviour
{
    public GameObject ship;
    public Slider slider;
    public Transform[] postions;

    private Animator m_Animator;
    private int index;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        index = 1;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (slider.value <= 0.4f && index > 0)
            {
                index--;
                m_Animator.Play("LeftBoat");
            }
            else if (slider.value >= 0.6f && index < postions.Length - 1)
            {
                index++;
                m_Animator.Play("RightBoat");
            }
            if (index == 1)
            {
                m_Animator.Play("StandingBoat");
            }

            ship.transform.position = postions[index].position;
        }
        if (!Input.GetMouseButton(0))
        {
            slider.transform.position = Input.mousePosition;
            slider.value = 0.5f;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("GameOver");
            Debug.Log("collision");
        }
    }
}
