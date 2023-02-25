using System.Data;
using UnityEngine;

public class MoveRL: MonoBehaviour
{
    [SerializeField] private float _speed;

    private RigidBodyKinematic _rigidbodyK;
    private Slide _slide;

    private void Start()
    {
        _rigidbodyK = gameObject.GetComponent<RigidBodyKinematic>();
        _slide = gameObject.GetComponent<Slide>();
        if (_rigidbodyK == null)
        {
            throw new MissingComponentException("Need RigidBodyKinematic!");
        }
    }
    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Vector2 alongSurface = new Vector2(Input.GetAxis("Horizontal"), 0) * _speed;
            if (_slide == null)
            {
                _rigidbodyK.SetTargetVelocity(alongSurface);
            }
            else
            {
                _slide.AddMove(alongSurface);
            }
        }
    }
}