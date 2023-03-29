using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Resources: MonoBehaviour
{
    [SerializeField] private UIInteraction interaction;
    [SerializeField] private SelectionNewHuman selection;

    [SerializeField] private List<TextMeshProUGUI> criteriosText;
    [SerializeField] private List<TextMeshProUGUI> summaryTexts;

    public uint Victories;
    public uint Fails;

    public List<string> criterionSelected = new();
    public List<string> summary = new();

    public List<string> criterion = new() {
        "2 года работы",
        "4 года работы",
        "6 лет работы",
        "1 год работы",
        "Java",
        "Python",
        "C++",
        "Go",
        "Unity",
        "Rest",
        "web-fullstack разработчик",
        "web-frontend разработчик",
        "web-backend разработчик"
    };



    private void Start()
    {
        criterionSelected.Add(criterion[Random.Range(0, 4)]);
        criterionSelected.Add(criterion[Random.Range(4, 8)]);
        criterionSelected.Add(criterion[Random.Range(8, criterion.Count)]);
        UpdateTexts(criteriosText, criterionSelected);

        summary.Add(criterion[Random.Range(0, 4)]);
        summary.Add(criterion[Random.Range(4, 8)]);
        summary.Add(criterion[Random.Range(8, criterion.Count)]);
        UpdateTexts(summaryTexts, summary);
    }
    
    public void check(bool lot)
    {
        bool ok = true;
        for(int i = 0; i < 3; i++)
        {
            if (!criterionSelected.Contains(summary[i]))
            {
                ok = false;
                break;
            }
        }
        if (ok)
        {
            if (lot)
            {
                selection.SelectNextHuman();
                Victories++;
                criterionSelected = GenerateCriterionSel();
                UpdateTexts(criteriosText, criterionSelected);
            }
            else
            {
                Fails++;
            }
        }
        else
        {
            if (!lot)
            {
                selection.SelectNextHuman();
                Victories++;
            }
            else
            {
                Fails++;
            }
        }
        interaction.CounterUpdate(Fails);
        summary = GenerateSummary();
        UpdateTexts(summaryTexts, summary);
    }

    public List<string> GenerateSummary()
    {
        List<string> newsummary = new();
        newsummary.Add(criterion[Random.Range(0, 4)]);
        newsummary.Add(criterion[Random.Range(4, 8)]);
        newsummary.Add(criterion[Random.Range(8, criterion.Count)]);
        return newsummary;
    }

    public void UpdateTexts(List<TextMeshProUGUI> arr, List<string> newTexts)
    {
        int index = 0;
        foreach(TextMeshProUGUI v in arr) 
        {
            v.text = newTexts[index];
            index++;
        }
    }

    public List<string> GenerateCriterionSel()
    {
        List<string> NewCritarion = new();
        NewCritarion.Add(criterion[Random.Range(0, 4)]);
        NewCritarion.Add(criterion[Random.Range(4, 8)]);
        NewCritarion.Add(criterion[Random.Range(8, criterion.Count)]);
        return NewCritarion;
    }

}
