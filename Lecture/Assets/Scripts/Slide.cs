using UnityEngine;

public class Slide : MonoBehaviour
{
    [SerializeField] private float _SlideSpeed;

    private RigidBodyKinematic _rigidbodyK;

    private void Start()
    {
        _rigidbodyK = gameObject.GetComponent<RigidBodyKinematic>();
        if (_rigidbodyK == null)
        {
            throw new MissingComponentException("Need RigidBodyKinematic!");
        }
    }

    private void Update()
    {
        Vector2 alongSurface = -_rigidbodyK._groundNormal.x * _SlideSpeed * Vector2.Perpendicular(_rigidbodyK._groundNormal); 

        _rigidbodyK.SetTargetVelocity(alongSurface);
    }
    public void AddMove(Vector2 move)
    {
        Vector2 alongSurface = -_rigidbodyK._groundNormal.x * _SlideSpeed * Vector2.Perpendicular(_rigidbodyK._groundNormal);

        _rigidbodyK.SetTargetVelocity(alongSurface + move);
    }
}