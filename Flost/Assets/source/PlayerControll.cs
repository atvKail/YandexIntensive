using System.Net.NetworkInformation;
using UnityEngine;

[RequireComponent(typeof(RigidBodyKinematic))]
public class PlayerControll : MonoBehaviour 
{
    [SerializeField] private CompositeRoot root;
    [SerializeField] private Animator animator;
    [SerializeField] private float _JumpForce;
    [SerializeField] private float _Speed;

    private RigidBodyKinematic _rigidbodyK;

    private void Start()
    {
        _rigidbodyK = gameObject.GetComponent<RigidBodyKinematic>();
    }

    private void Update()
    {
        animator.SetBool("run", false);
        animator.SetBool("jump", false);
        animator.SetBool("atack", false);
        if (Input.GetKeyDown(KeyCode.Space) && _rigidbodyK._grounded)
        {
            _rigidbodyK.SetVelocity(_rigidbodyK.GetVelocity() + new Vector2(0, _JumpForce));
        }
        else if(Input.GetAxis("Horizontal") != 0)
        {
            Vector2 direction = new Vector2(Input.GetAxis("Horizontal") * _Speed, 0);
            _rigidbodyK.SetTargetVelocity(direction);
            animator.SetBool("run", true);
            if (direction.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
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
