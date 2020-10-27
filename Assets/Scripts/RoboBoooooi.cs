using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RoboBoooooi : MonoBehaviour
{
    private Animator _animator;
    
    private const string IsMovingStr = "IsMoving";
    private static readonly int IsMovingHash = Animator.StringToHash(IsMovingStr);
    
    private const string IsJumpingStr = "IsJumping";
    private static readonly int IsJumpingHash = Animator.StringToHash(IsJumpingStr);
    
    private const string IsCrouchingStr = "IsCrouching";
    private static readonly int IsCrouchingHash = Animator.StringToHash(IsCrouchingStr);
    
    private bool _isMoving;
    private bool _isJumping;
    private bool _isCrouching;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private bool IsMoving
    {
        get => _isMoving;
        set
        {
            _isMoving = value;
            _animator.SetBool(IsMovingHash, _isMoving);
        }
    }

    private bool IsJumping
    {
        get => _isJumping;
        set
        {
            _isJumping = value;
            _animator.SetBool(IsJumpingHash, _isJumping);
        }
    }

    private bool IsCrouching
    {
        get => _isCrouching;
        set
        {
            _isCrouching = value;
            _animator.SetBool(IsCrouchingHash, _isCrouching);
        }
    }
    void Update()
    {
        IsMoving = Input.GetAxis("Horizontal")>0;

        if (Input.GetKeyDown(KeyCode.W))
        {
            IsJumping = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            IsJumping = false;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            IsCrouching = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            IsCrouching = false;
        }
    }
}
