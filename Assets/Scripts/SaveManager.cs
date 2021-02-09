using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public static int coinsBalance;
    public static int highScore;
    public static int[] openedlevels;



    public static void UpdateHighscore(int newHighscore)
    {
        PlayerPrefs.SetInt("Highscore", newHighscore);

    }

    public static void SaveCurrency(int currencyToAdd)
    {
        coinsBalance = PlayerPrefs.GetInt("Coins");
        coinsBalance += currencyToAdd;

        PlayerPrefs.SetInt("Coins", coinsBalance);
        
    }
}
