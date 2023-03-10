using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceControll : MonoBehaviour
{
    [SerializeField] private CompositeRoot root;
    [SerializeField] private Text CoinsInfo;

    private Dictionary<string, string> _Format;

    private void OnEnable()
    {
        _Format = new Dictionary<string, string>
        {
            { "Coins", "Coins - $" }
        };
    }

    public void UpdateValue()
    {
        CoinsInfo.text = Formating("Coins", root.GetCoins().ToString());
    }
    private string Formating(string key,  string value)
    {
        char[] data = _Format[key].ToCharArray();
        StringBuilder builder = new StringBuilder();
        foreach(char v in data){
            if(v != '$')
            {
                builder.Append(v);
            }
            else
            {
                builder.Append(value);
            }
        }
        return builder.ToString();
    }
}
