using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    public Obstacle obstacle;
    public Background background;
    public ScoreManager scoreManager;
    [Range(1f, 5f)]
    public float speed;

    private GameObject shildImage;
    private Animator m_animator;
    private bool shild;

    private void Start()
    {
        shildImage = transform.GetChild(0).gameObject;
        m_animator = GetComponent<Animator>();
        SetSpeed(speed);
    }

    private void Update()
    {
        speed += 5f / 180f * Time.deltaTime;
        SetSpeed(speed);
    }

    private void SetSpeed(float _value)
    {
        speed = _value;
        obstacle.speed = speed;
        obstacle.spawnTime = 1.5f - (speed * 0.2f);
        m_animator.speed = speed;
        background.SetAnimationSpeed(speed);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (shild)
            {
                Destroy(collision.gameObject);
                shild = false;
                shildImage.SetActive(false);
                return;
            }
            PlayerPrefs.SetInt("Score", scoreManager.score);
            PlayerPrefs.SetInt("People", scoreManager.savedPeopleCount);
            PlayerPrefs.SetInt("Treasure", scoreManager.treasureCount);
            SceneManager.LoadScene("GameOver");
        }
        if (collision.gameObject.CompareTag("Treasure"))
        {
            Destroy(collision.gameObject);
            scoreManager.treasureCount++;
        }
        if (collision.gameObject.CompareTag("People"))
        {
            Destroy(collision.gameObject);
            scoreManager.savedPeopleCount++;
        }
        if (collision.gameObject.CompareTag("HitPeople"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
        if (collision.gameObject.CompareTag("Shild"))
        {
            shild = true;
            shildImage.SetActive(true);

            Destroy(collision.gameObject);
        }
    }
}
