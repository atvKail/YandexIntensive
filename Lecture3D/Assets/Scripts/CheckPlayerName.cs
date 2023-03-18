using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckPlayerName : MonoBehaviour
{
    [SerializeField] GameObject NameField;

    private void Start()
    {
        tickUp();
    }

    public void tickUp()
    {
        if (NameField.GetComponent<TMP_Text>().text != "")
        {
            gameObject.SetActive(false);
        }
    }
}
