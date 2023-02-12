using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    public Obstacle obstacle;
    public Background background;
    public float speed;

    private Animator m_animator;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        SetSpeed(speed);
    }

    private void Update()
    {
        SetSpeed(speed);
    }

    private void SetSpeed(float _value)
    {
        speed = _value;
        obstacle.speed = speed;
        obstacle.spawnTime = speed * 0.75f;
        m_animator.speed = speed;
        background.SetAnimationSpeed(speed);
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
