using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public static int coinsBalance;
    public static int highScore;
    public static int[] openedlevels;

    private void Awake()
    {
        
    }

    public static void SaveCurrency(int currencyToAdd)
    {
        coinsBalance = PlayerPrefs.GetInt("Coins");
        coinsBalance += currencyToAdd;

        PlayerPrefs.SetInt("Coins", coinsBalance);
    }
}
