using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public TextMeshProUGUI Score;

    public GameUI GameUI { get; private set; }

    private void Awake()
    {
        Instance = this;

        Score.text = "0";

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
        GameObject knifePref = Instantiate(knifeObject, knifeSpawnPosition, Quaternion.identity);
        knifePref.GetComponent<Animator>().SetBool("isNeedToFade", true);

    }

    public void OnSuccessfulKnifeHit()
    {
        if (knifeCount > 0) {
            SpawnKnife();
            // Обновляем сохраненные общие очки
            SaveManager.SaveCurrency(Convert.ToInt32(Score));
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


            yield return new WaitForSecondsRealtime(0.5f);
            Time.timeScale = 0;
            RestartGame();
        }
        else {
            
            yield return new WaitForSecondsRealtime(0.5f);
            Time.timeScale = 0;
            GameUI.ShowButtons();
            Debug.Log("Restartbutton called");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single); // Перезагружаем текущую сцену
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
