using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameOverScript : MonoBehaviour, IPointerDownHandler
{
    public TextMeshProUGUI bestScoreGUI;
    public TextMeshProUGUI currentScoreGUI;
    public TextMeshProUGUI savedPeopleGUI;
    public TextMeshProUGUI treasureGUI;
    public TextMeshProUGUI savedPeopleScoreGUI;
    public TextMeshProUGUI treasureScoreGUI;

    private int score;
    private int savedPeople;
    private int treasure;
    private int bestScore;
    private int currentScore;
    private int step;
    private int progressScore = 0;
    private bool scoreLoaded = false;

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        savedPeople = PlayerPrefs.GetInt("SavedPeople");
        savedPeopleGUI.text = savedPeople.ToString();
        savedPeopleScoreGUI.text = "+" + savedPeople * 500;
        treasure = PlayerPrefs.GetInt("Treasure");
        treasureGUI.text = treasure.ToString();
        treasureScoreGUI.text = "+" + treasure * 300;
        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreGUI.text = bestScore.ToString();
        currentScore = score + (savedPeople * 500) + (treasure * 300);
        step = (int) Mathf.Max(Mathf.Pow(10, Mathf.FloorToInt(Mathf.Log10(currentScore))) / 10 + Random.Range(0, Mathf.Pow(10, Mathf.FloorToInt(Mathf.Log10(currentScore))) / 10) * 0.2f, 1);
        StartCoroutine(Score());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!scoreLoaded)
        {
            scoreLoaded = true;
            StopCoroutine(Score());

            if (bestScore < currentScore) bestScore = currentScore;

            currentScoreGUI.text = currentScore.ToString();
            bestScoreGUI.text = bestScore.ToString();
        } else changeScene();
    }

    public void changeScene()
    {
        progressScore = 0;
        step = 0;
        SceneManager.LoadScene("Lobby");
    }

    IEnumerator Score()
    {
        while (true)
        {
            progressScore = Mathf.Min(currentScore, progressScore + step);
            currentScoreGUI.text = progressScore.ToString();

            yield return new WaitForSeconds(0.05f);
            if (scoreLoaded) break;
            if (currentScore == progressScore) break;
        }
        if (bestScore < currentScore) bestScore = currentScore;

        PlayerPrefs.SetInt("BestScore", bestScore);

        bestScoreGUI.text = bestScore.ToString();
        scoreLoaded = true;
    }

}