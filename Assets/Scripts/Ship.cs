using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class Ship : MonoBehaviour
{
    public Obstacle obstacle;
    public Background background;
    public ScoreManager scoreManager;
    public ShipMove shipMove;
    public Animator oilAnimator;
    public GameObject arrow;
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
            arrow.SetActive(false);
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
        if (collision.gameObject.CompareTag("Treasure"))
        {
            scoreManager.treasureCount++;
        }
        else if (collision.gameObject.CompareTag("People"))
        {
            scoreManager.savedPeopleCount++;
        }
        else if (collision.gameObject.CompareTag("HitPeople"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
        else if (collision.gameObject.CompareTag("Shild"))
        {
            shild = true;
            shipMove.shildImage.SetActive(true);
        }
        else 
        {
            if (shild)
            {
                shild = false;
                shipMove.shildImage.SetActive(false);
                Destroy(collision.gameObject);
                return;
            }
            
            if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("LightHouse"))
            {
                PlayerPrefs.SetInt("Score", scoreManager.score);
                PlayerPrefs.SetInt("SavedPeople", scoreManager.savedPeopleCount);
                PlayerPrefs.SetInt("Treasure", scoreManager.treasureCount);
                SceneManager.LoadScene("GameOver");
            }
            if (collision.gameObject.CompareTag("Trash"))
            {
                shipMove.flip = true;
                arrow.SetActive(true);
                flipDelay = Time.time + 3;
            }
            if (collision.gameObject.CompareTag("Oil"))
            {
                oilAnimator.Play("ShowOil");
            }
            if (collision.gameObject.CompareTag("Tire"))
            {
                int condition = shipMove.condition + 1;
                if (shipMove.index == 1)
                {
                    int pos = UnityEngine.Random.Range(0, 2);
                    Debug.Log(pos);
                    pos = pos == 0 ? -condition : condition;

                    shipMove.Move(pos);
                }
                else if (shipMove.index == 0)
                {
                    shipMove.Move(-condition);
                }
                else
                {
                    shipMove.Move(condition);
                }
            }
        }

        Destroy(collision.gameObject);
    }
}
