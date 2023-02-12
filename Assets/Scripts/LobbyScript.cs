using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Threading;

public class LobbyScript : MonoBehaviour, IPointerDownHandler
{
    private Animator m_Animator;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene("InGame");
    }
}
