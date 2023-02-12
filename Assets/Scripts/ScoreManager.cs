using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI lifeTimeText;
    public Ship Ship;

    private int score;
    private float lifeTime;
    private int savedPeopleCount;
    private int treasure;


    private void Update()
    {
        lifeTime = Time.time;
        score = (int)(lifeTime * 1.5f * Ship.speed);
        TextUpdate();
    }

    private void TextUpdate()
    {
        lifeTimeText.text = lifeTime.ToString("F2");
        ScoreText.text = score.ToString();
    }
}
