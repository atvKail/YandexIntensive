using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameRotation : MonoBehaviour
{
    [SerializeField] private string Name = "";
    [SerializeField] private Camera TargetCamera;

    private float commonY;

    public GameObject parentObj;

    private void OnEnable()
    {
        commonY = transform.position.y;
    }

    private void Update()
    {
        GetComponent<TMP_Text>().text = Name;
        transform.LookAt(-(TargetCamera.transform.position - transform.position));
        transform.position = new Vector3(transform.position.x, commonY * parentObj.transform.localScale.y, transform.position.z);
    }

    public void SetName(string newName)
    {
        GetComponent<TMP_Text>().text = newName;
        Name = newName;
    }
    
    public void SetName(TMP_InputField field)
    {
        SetName(field.text);
    }
}
