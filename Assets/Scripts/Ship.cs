using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    public Obstacle obstacle;
    public Background background;
    public ScoreManager scoreManager;
    public ShipMove shipMove;
    [Range(1f, 5f)]
    public float speed;

    private Animator m_animator;
    private bool shild;
    private float flipDelay;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        SetSpeed(speed);
    }

    private void Update()
    {
        speed += 5f / 180f * Time.deltaTime;
        SetSpeed(speed);

        if (flipDelay < Time.time)
        {
            shipMove.flip = false;
            flipDelay = 0;
        }

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
                shipMove.shildImage.SetActive(false);
                return;
            }
            PlayerPrefs.SetInt("Score", scoreManager.score);
            PlayerPrefs.SetInt("SavedPeople", scoreManager.savedPeopleCount);
            PlayerPrefs.SetInt("Treasure", scoreManager.treasureCount);
            SceneManager.LoadScene("GameOver");
        }
        if (collision.gameObject.CompareTag("Trash"))
        {
            Destroy(collision.gameObject);
            shipMove.flip = true;
            flipDelay = Time.time + 3;
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
            shipMove.shildImage.SetActive(true);

            Destroy(collision.gameObject);
        }
    }
}
