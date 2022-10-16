using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance => instance ?? (instance = FindObjectOfType<GameManager>());

    private bool isGameStart = false;
    private bool isGameOver = false;

    [SerializeField] private GameObject onGameStartUI, failedPanel, successPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsGameStart()
    {
        return isGameStart;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void OnGameStart()
    {
        isGameStart = true;
        DeactivateOnGameStartUI();
    }

    public void OnGameFailed()
    {
        isGameOver = true;
        ActivatePanel(failedPanel);
    }

    public void OnGameFinished()
    {
        isGameOver = true;
        ActivatePanel(successPanel);
    }

    private void DeactivateOnGameStartUI()
    {
        onGameStartUI.SetActive(false);
    }

    private void ActivatePanel(GameObject panel)
    {       
        panel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
