using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UIInteraction : MonoBehaviour
{
    [SerializeField] private Resources res;

    [SerializeField] private TMP_Text RoboticityCounter;
    [SerializeField] private GameObject EndWindow;
    [SerializeField] private TextMeshProUGUI Score;

    public void CounterUpdate(bool end)
    {
        if (end)
        {
            EndWindow.SetActive(true);
            Score.text = $"Заработано репутации:\n{res.RoboticityPublic}";
        }
        else
        {
            string comb = (res.Roboticity > 0) ? "+" : "-";
            RoboticityCounter.text = $"{comb}{Math.Round(Math.Abs(res.Roboticity), 3)}";
        }
    }

}
