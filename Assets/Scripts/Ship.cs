using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("GameOver");
            Debug.Log("collision");
        }
    }
}
