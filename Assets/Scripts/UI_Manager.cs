using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currency;
    [SerializeField] private TextMeshProUGUI highScore;


    private void Awake()
    {
        currency.text = PlayerPrefs.GetInt("Coins").ToString();

        highScore.text = PlayerPrefs.GetInt("Highscore").ToString();

    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}


