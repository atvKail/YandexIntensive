using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DeathCheck: MonoBehaviour
{
    public LayerMask _DeathLayer;
    public GameObject EndObjectImage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject deathPlace = collision.gameObject;
        if ((_DeathLayer.value & (1 << deathPlace.layer)) > 0) 
        {
            GameObject _Obj = Instantiate(EndObjectImage);
            _Obj.transform.position = transform.position;
        }
    }
}
