using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject cardContainer;

    public TextMeshProUGUI currentPowerText;

    public void UpdatePowerBalance(int currentBalance)
    {
        currentPowerText.text = "Power: " + currentBalance;
    }
}
