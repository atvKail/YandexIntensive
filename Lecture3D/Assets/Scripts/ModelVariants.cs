using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModelVariants : MonoBehaviour
{

    [SerializeField] private GameObject[] _models;
    [SerializeField] private GameObject _nick;
    private GameObject _currenSelected;
    [SerializeField] private TMP_Dropdown _dropdown;

    private void Start()
    {
        _currenSelected = _models[0];
        _dropdown.onValueChanged.AddListener(Select);
    }

    public void Select(int index) {
        _currenSelected.SetActive(false);
        _currenSelected = _models[index];
        _currenSelected.SetActive(true);

        _nick.GetComponent<NameRotation>().parentObj = _models[index];
    }


}
