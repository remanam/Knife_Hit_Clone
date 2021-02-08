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

    //Чтоб передавать общее количество очков за игру
    public int sum = 0;

    public GameUI GameUI { get; private set; }

    private void Awake()
    {
        Time.timeScale = 1;

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

            // При каждом попадании обновляем общее количество валюты
           SaveManager.SaveCurrency(Convert.ToInt32(Score));


        }
        else {
            Debug.Log(PlayerPrefs.GetInt("Highscore"));
            //Проверяем Highscore
            if (PlayerPrefs.GetInt("Highscore") < Convert.ToInt32(Score.text))
                SaveManager.UpdateHighscore(Convert.ToInt32(Score.text));

            //Разрушаем LogObject
            LogProperties.Instance.destroyLog();

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
            //Вибрация
            Handheld.Vibrate();


            yield return new WaitForSecondsRealtime(1f);
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
