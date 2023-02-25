using UnityEngine;

public class Jump : MonoBehaviour 
{
    [SerializeField] private float _JumpForce;

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
        if (Input.GetAxis("Jump") > 0 && _rigidbodyK._grounded)
        {
            _rigidbodyK.SetVelocity(_rigidbodyK.GetVelocity() + new Vector2(0, _JumpForce));
        }
    }
}
