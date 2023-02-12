using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

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
        currentScore = score + (people * 500) + (treasure * 300); 
        step = (int) Mathf.Max(Mathf.Pow(10, Mathf.FloorToInt(Mathf.Log10(currentScore))) / 1000 + Random.Range(-100, 100), 1);
    }

    private void Update()
    {

        progressScore = Mathf.Min(currentScore, progressScore + step);
        currentScoreGUI.text = progressScore.ToString();

        if (progressScore != currentScore) return;
        if (bestScore < currentScore) bestScore = currentScore;

        bestScoreGUI.text = bestScore.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        changeScene();
    }

    public void changeScene()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
        SceneManager.LoadScene("Lobby");
    }
}