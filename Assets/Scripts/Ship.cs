using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    public GameObject ship;
    public Slider slider;
    public Transform[] postions;
    private int index;

    private void Start()
    {
        index = 1;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (slider.value <= 0.25f && index > 0)
            {
                index--;
            }
            else if (slider.value >= 0.55f && index < postions.Length - 1)
            {
                index++;
            }
            Debug.Log(index);

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
