using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameUI))]
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public int knifeCount;

    [Header("KnifeSpawning")]
    [SerializeField] private Vector2 knifeSpawnPosition;

    [SerializeField] private GameObject knifeObject;

    public GameUI GameUI { get; private set; }

    private void Awake()
    {
        Instance = this;

        GameUI = GetComponent<GameUI>();
    }

    private void Start()
    {
        GameUI.SetInitialDisplayedKnifeCount(knifeCount);
        SpawnKnife();
    }

    private void SpawnKnife()
    {
        knifeCount--;
        Instantiate(knifeObject, knifeSpawnPosition, Quaternion.identity);
    }

    public void OnSuccessfulKnifeHit()
    {
        if (knifeCount > 0) {
            SpawnKnife();
        }
        else {
            StartGameOverSequence(true);
            Debug.Log("Won the game!");
        }
    }

    public void StartGameOverSequence(bool win)
    {
        StartCoroutine(GameOverSequenceCoroutine(win));
    }

    private IEnumerator GameOverSequenceCoroutine(bool win)
    {
        if (win == true) {
            Time.timeScale = 0;
            yield return new WaitForSecondsRealtime(0.5f);
            RestartGame();
        }
        else {
            Time.timeScale = 0;
            yield return new WaitForSecondsRealtime(0.5f);
            GameUI.ShowRestartButton();
            Debug.Log("Restartbutton called");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single); // Перезагружаем текущую сцену
    }
}
