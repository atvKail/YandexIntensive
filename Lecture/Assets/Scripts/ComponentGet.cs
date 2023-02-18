using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ComponentGet : MonoBehaviour
{
    public Rigidbody2D Box;
    private void Start()
    {
        Rigidbody2D prev = Box;
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject go = gameObject.transform.GetChild(i).gameObject;
            go.AddComponent<Rigidbody2D>();
            go.AddComponent<BoxCollider2D>();
            go.AddComponent<DistanceJoint2D>();
            DistanceJoint2D _distJoint = go.GetComponent<DistanceJoint2D>();
            _distJoint.connectedBody = prev;
            _distJoint.maxDistanceOnly = true;
            Rigidbody2D _rigidbody = go.GetComponent<Rigidbody2D>();
            BoxCollider2D collider2D = go.GetComponent<BoxCollider2D>();
            _rigidbody.mass = 0.0001f;
            collider2D.isTrigger = true;
            prev = _rigidbody;
        }
    }
}
