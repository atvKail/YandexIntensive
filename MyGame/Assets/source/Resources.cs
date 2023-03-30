using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Resources : MonoBehaviour
{
    [SerializeField] private UIInteraction interaction;
    [SerializeField] private SelectionNewHuman selection;

    [SerializeField] private List<TextMeshProUGUI> criteriosText;
    [SerializeField] private List<TextMeshProUGUI> summaryTexts;

    private int First;
    private int Second;
    private int Third;
    private int Fourth;

    public float RoboticityPublic;
    public float Roboticity;

    public List<string> criterionSelected = new();
    public List<string> summary = new();

    public List<string> workingHours = new() {
        "2 года работы",
        "4 года работы",
        "6 лет работы",
        "1 год работы",
     };
    public List<string> programmingLanguage = new()
    {
        "Java",
        "Python",
        "C++",
        "Go",
        "C#"
    };
    public List<string> technology = new() {
        "Unity",
        "Rest",
        "Django",
        "Node.js"
    };
    public List<string> profession = new() {
        "web-fullstack разработчик",
        "web-frontend разработчик",
        "web-backend разработчик",
        "game developer"
    };



    private void Start()
    {
        First = Random.Range(0, workingHours.Count - 1);
        Second = Random.Range(0, programmingLanguage.Count - 1);
        Third = Random.Range(0, technology.Count - 1);
        Fourth = Random.Range(0, profession.Count - 1);

        criterionSelected.Add(workingHours[First]);
        criterionSelected.Add(programmingLanguage[Second]);
        criterionSelected.Add(technology[Third]);
        criterionSelected.Add(profession[Fourth]);
        UpdateTexts(criteriosText, criterionSelected);

        summary.Add(workingHours[Random.Range(0, First)]);
        summary.Add(programmingLanguage[Random.Range(Second, programmingLanguage.Count)]);
        summary.Add(technology[Random.Range(Third, technology.Count)]);
        summary.Add(profession[Random.Range(0, Fourth)]);
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
                Roboticity += 1.5f;
                criterionSelected = GenerateCriterionSel();
            }
            else
            {
                Roboticity -= 0.4f;
                summary = GenerateSummary();
            }
        }
        else
        {
            if (!lot)
            {
                selection.SelectNextHuman();
                Roboticity += 0.15f;
                summary = GenerateSummary();
            }
            else
            {
                Roboticity -= 0.7f;
                summary = GenerateSummary();
            }
        }
        RoboticityPublic += Roboticity;
        interaction.CounterUpdate(false);
        UpdateTexts(summaryTexts, summary);
        UpdateTexts(criteriosText, criterionSelected);
    }

    public List<string> GenerateSummary()
    {
        List<string> newsummary = new();
        newsummary.Add(workingHours[Random.Range(Comparison(First - 1, workingHours), Comparison(First + 1, workingHours))]);
        newsummary.Add(programmingLanguage[Random.Range(Comparison(Second - 1, programmingLanguage), Comparison(Second + 1, programmingLanguage))]);
        newsummary.Add(technology[Random.Range(Comparison(Third, technology), Comparison(Third, technology))]);
        newsummary.Add(profession[Random.Range(Comparison(Fourth - 1, profession), Comparison(Fourth + 1, profession))]);
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
        First = Random.Range(0, workingHours.Count);
        Second = Random.Range(0, programmingLanguage.Count);
        Third = Random.Range(0, technology.Count);
        Fourth = Random.Range(0, profession.Count);

        List<string> NewCritarion = new();
        NewCritarion.Add(workingHours[First]);
        NewCritarion.Add(programmingLanguage[Second]);
        NewCritarion.Add(technology[Third]);
        NewCritarion.Add(profession[Fourth]);
        return NewCritarion;
    }

    private int Comparison(int el, List<string> arr)
    {
        if(el >= arr.Count)
        {
            return arr.Count;
        }
        else if(el < 0) 
        {
            return 0;
        }
        else
        {
            return el;
        }
    }
}
