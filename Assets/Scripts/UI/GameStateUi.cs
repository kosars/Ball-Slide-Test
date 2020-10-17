using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateUi : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private GameObject _inGameUI;
    private void Awake()=> PauseGame();
    public void PauseGame()
    {
        _pauseUI.SetActive(true);
        _inGameUI.SetActive(false);
        PlayerInput.LockInput();
        Time.timeScale = 0f;
    }

    public void ExitGame() => Application.Quit();

    public void StartGame()
    {
        _pauseUI.SetActive(false);
        _inGameUI.SetActive(true);
        Time.timeScale = 1f;
        PlayerInput.UnlockInput();

    }
}
