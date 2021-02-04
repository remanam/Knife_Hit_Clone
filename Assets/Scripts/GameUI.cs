using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject toMainMenuButton;

    [Header("Knife Count Display")]
    [SerializeField] private GameObject panelKnives;
    
    [SerializeField] private GameObject iconKnife; // Prefab icon knife

    [SerializeField] Color usedKnifeIconColor;

    
    
    public void ShowButtons()
    {
        restartButton.SetActive(true);
        toMainMenuButton.SetActive(true);
    }

    public void SetInitialDisplayedKnifeCount(int count)
    {
        for (int i = 0; i < count; i++) {
            Instantiate(iconKnife, panelKnives.transform);
        }
    }

    private int knifeIconIndexToChange = 0; // this int is keeping track of the last icon representing an Unthrouwn knife
    public void DecrementDisplayedKnifeCount()
    {
        panelKnives.transform.GetChild(knifeIconIndexToChange)
            .GetComponent<Image>().color = usedKnifeIconColor;

        knifeIconIndexToChange++;
    }
}
