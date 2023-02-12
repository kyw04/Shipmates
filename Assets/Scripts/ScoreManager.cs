using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeTimeText;
    public TextMeshProUGUI peopleCountText;
    public TextMeshProUGUI treasureText;
    public Ship Ship;

    [HideInInspector]
    public int score;
    [HideInInspector]
    public int savedPeopleCount;
    [HideInInspector]
    public int treasureCount;
    private float lifeTime;

    private void Start()
    {
        score = 0;
        savedPeopleCount = 0;
        treasureCount = 0;
        lifeTime = 0;
    }

    private void Update()
    {
        lifeTime = Time.time;
        score = (int)(lifeTime * 1.5f * Ship.speed);
        TextUpdate();
    }

    private void TextUpdate()
    {
        lifeTimeText.text = lifeTime.ToString("F2");
        scoreText.text = score.ToString();
        peopleCountText.text = savedPeopleCount.ToString();
        treasureText.text = treasureCount.ToString();
    }
}
