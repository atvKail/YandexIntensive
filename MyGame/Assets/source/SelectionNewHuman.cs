using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionNewHuman : MonoBehaviour
{
    private int IndexSelected = 0;

    public List<Sprite> humans = new();

    private void Start()
    {
        SetSprite(humans[IndexSelected]);
    }

    public GameObject SelectNextHuman()
    {
        if (humans.Count - 1 == IndexSelected + 1)
        {
            IndexSelected = Random.Range(0, humans.Count);
        }
        SetSprite(humans[++IndexSelected]);
        return gameObject;
    }

    public void SetSprite(Sprite sprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
