﻿using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidBodyKinematic : MonoBehaviour
{
    [SerializeField] private float _gravityModifier = 1f;
    [SerializeField] private LayerMask _layerMask;

    private const float MinMoveDistance = 0.001f;
    private const float ShellRadius = 0.01f;
    private float _minGroundNormalY = .65f;
    private ContactFilter2D _contactFilter;

    private Rigidbody2D _rb2d;
    private Vector2 _targetVelocity;
    private Vector2 _velocity;

    private RaycastHit2D[] _hitBuffer = new RaycastHit2D[16];
    private List<RaycastHit2D> _hitBufferList = new(16);

    [HideInInspector] public bool _grounded;
    [HideInInspector] public Vector2 _groundNormal;


    private void OnEnable()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _contactFilter.useTriggers = true;
        _contactFilter.SetLayerMask(_layerMask);
        _contactFilter.useLayerMask = true;
    }

    private void FixedUpdate()
    {
        _velocity += _gravityModifier * Physics2D.gravity * Time.deltaTime;
        _velocity.x = _targetVelocity.x;

        _grounded = false;

        Vector2 deltaPosition = _velocity * Time.deltaTime;
        Vector2 moveAlongGround = new(_groundNormal.y, -_groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > MinMoveDistance)
        {
            int count = _rb2d.Cast(move, _contactFilter, _hitBuffer, distance + ShellRadius);

            _hitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                _hitBufferList.Add(_hitBuffer[i]);
            }

            for (int i = 0; i < _hitBufferList.Count; i++)
            {
                Vector2 currentNormal = _hitBufferList[i].normal;
                if (currentNormal.y > _minGroundNormalY)
                {
                    _grounded = true;
                    if (yMovement)
                    {
                        _groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(_velocity, currentNormal);
                if (projection < 0)
                {
                    _velocity -= projection * currentNormal;
                }

                float modifiedDistance = _hitBufferList[i].distance - ShellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        _rb2d.position = _rb2d.position + move.normalized * distance;
    }


    public void SetVelocity(Vector2 velocity)
    {
        _velocity = velocity;
    }
    public void SetTargetVelocity(Vector2 targetVelocity)
    {
        _targetVelocity = targetVelocity;
    }
    public Vector2 GetVelocity()
    {
        return _velocity;
    }
    public Vector2 GetTargetVelocity()
    {
        return _targetVelocity;
    }
}