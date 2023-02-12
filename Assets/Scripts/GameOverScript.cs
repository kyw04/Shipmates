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

    private int score;
    private int people;
    private int treasure;
    private int bestScore;
    private int currentScore;
    private int step;
    private int progressScore = 0;

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        people = PlayerPrefs.GetInt("People");
        treasure = PlayerPrefs.GetInt("Treasure");
        bestScore = PlayerPrefs.GetInt("BestScore");
<<<<<<< Updated upstream
        bestScoreGUI.text = bestScore.ToString();
        currentScore = score + (people * 500) + (treasure * 300);
        step = (int) Mathf.Max(Mathf.Pow(10, Mathf.FloorToInt(Mathf.Log10(currentScore))) / 10 + Random.Range(0, Mathf.Pow(10, Mathf.FloorToInt(Mathf.Log10(currentScore))) / 10) * 0.2f, 1);

=======
        currentScore = score + (people * 500) + (treasure * 300);
        step = (int) Mathf.Max(Mathf.Pow(10, Mathf.FloorToInt(Mathf.Log10(currentScore))) / 1000 + Random.Range(-100, 100), 1);
>>>>>>> Stashed changes
        StartCoroutine(Score());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        changeScene();
    }

    public void changeScene()
    {
        progressScore = 0;
<<<<<<< Updated upstream
        step = 0;
=======
>>>>>>> Stashed changes
        SceneManager.LoadScene("Lobby");
    }

    IEnumerator Score()
    {
        while (true)
        {
            progressScore = Mathf.Min(currentScore, progressScore + step);
            currentScoreGUI.text = progressScore.ToString();

            yield return new WaitForSeconds(0.05f);

            if (currentScore == progressScore) break;
        }
<<<<<<< Updated upstream
        if (bestScore < currentScore) bestScore = currentScore;

        PlayerPrefs.SetInt("BestScore", bestScore);
=======

        if (bestScore < currentScore) bestScore = currentScore;

>>>>>>> Stashed changes
        bestScoreGUI.text = bestScore.ToString();
    }

}