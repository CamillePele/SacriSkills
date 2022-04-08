using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Player player;
    
    public UnityEvent onResumeGame, onEndRound;

    private bool isGamePaused;
    
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isGamePaused = false;
        ResumeGame();
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1;
        onResumeGame.Invoke();
    }

    public void ProcessesGameState()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused) PauseGame();
        else ResumeGame();
    }

    public void EndBoard()
    {
        //TODO
    }

    public void StartBoard()
    {
        //TODO
    }
    public void EndRound()
    {
        Debug.Log("RoundEnded");
        onEndRound.Invoke();
        player.BlockInputs();
    }
    public void StartRound()
    {
        player.spawnPoint = spawnPosition.position;
        player.Spawn();
    }

}
