using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInteraction : MonoBehaviour
{
    [SerializeField] private Resources res;
    [SerializeField] private Image FirstLife;
    [SerializeField] private Image SecondLife;
    [SerializeField] private Image ThirdLife;

    [SerializeField] private GameObject EndWindow;
    [SerializeField] private TextMeshProUGUI Score;

    public void CounterUpdate(uint LifeCount)
    {
        if (LifeCount == 1)
        {
            FirstLife.color = Color.red;
        }
        else if (LifeCount == 2)
        {
            SecondLife.color = Color.red;
        }
        else if (LifeCount >= 3)
        {
            ThirdLife.color = Color.red;
            ThirdLife.transform.parent.gameObject.SetActive(false);
            EndWindow.SetActive(true);
            Score.text = $"Score: {res.Victories}";
        }
    }

}
