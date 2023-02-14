using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RopeGrab : MonoBehaviour
{
    [SerializeField] private LayerMask _LayerRope;
    [SerializeField] private float _Radius;
    private GameObject player;

    private void Start()
    {
        player = this.gameObject;
    }
    public void Grabbing()
    {
        if(GetComponent<DistanceJoint2D>() == null)
        {
            Collider2D _ = Physics2D.OverlapCircle(transform.position, _Radius, _LayerRope);
            if (_ != null) 
            {
                player.AddComponent<DistanceJoint2D>().connectedBody = _.gameObject.GetComponent<Rigidbody2D>();
            }
            else 
            {
                return;
            }
        }
        return;
    } 
}
