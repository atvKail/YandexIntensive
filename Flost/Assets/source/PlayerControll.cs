using UnityEngine;

[RequireComponent(typeof(RigidBodyKinematic))]
public class PlayerControll : MonoBehaviour 
{
    [SerializeField] private CompositeRoot root;
    [SerializeField] private float _JumpForce;
    [SerializeField] private float _Speed;

    private RigidBodyKinematic _rigidbodyK;

    private void Start()
    {
        _rigidbodyK = gameObject.GetComponent<RigidBodyKinematic>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _rigidbodyK._grounded)
        {
            _rigidbodyK.SetVelocity(_rigidbodyK.GetVelocity() + new Vector2(0, _JumpForce));
        }
        else
        {
            _rigidbodyK.SetTargetVelocity(new Vector2(Input.GetAxis("Horizontal") * _Speed, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            root.SetCoins(root.GetCoins() + 5);
            Destroy(other.gameObject);
        }
    }
}
