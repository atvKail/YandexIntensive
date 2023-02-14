using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float RepulsiveForce;
    private RopeGrab _GrabScript;

    private void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _GrabScript = this.GetComponent<RopeGrab>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _rigidbody.AddForce(Vector2.right * RepulsiveForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _rigidbody.AddForce(Vector2.left * RepulsiveForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Destroy(GetComponent<DistanceJoint2D>());
        }
        if (Input.GetKey(KeyCode.G)) 
        {
            _GrabScript.Grabbing();
        }
    }
}
