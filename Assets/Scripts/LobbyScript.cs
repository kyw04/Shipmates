using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Threading;
using TMPro;

public class LobbyScript : MonoBehaviour, IPointerDownHandler
{
    public TextMeshProUGUI bestScoreGUI;
    private Animator m_Animator;
    private int bestScore;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        bestScore = PlayerPrefs.GetInt("BestScore");
    }

    private void Update()
    {
        bestScoreGUI.text = "Best Score: " + bestScore.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene("InGame");
    }
}
