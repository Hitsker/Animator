using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private MeshRenderer _gunBody;
    private Animator _animator;
    
    private const string IsMovingStr = "Move";
    private static readonly int IsMovingHash = Animator.StringToHash(IsMovingStr);
    
    private const string IsShootingStr = "Shoot";
    private static readonly int IsShootingHash = Animator.StringToHash(IsShootingStr);
    
    private bool _isMoving;
    private bool _isShooting;

    public MeshRenderer GunBody => _gunBody;

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

    private bool IsShooting
    {
        get => _isShooting;
        set
        {
            _isShooting = value;
            _animator.SetBool(IsShootingHash, _isShooting);
        }
    }
    void Update()
    {
        IsMoving = Input.GetAxis("Vertical")>0;

        if (Input.GetMouseButtonDown(0))
        {
            IsShooting = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsShooting = false;
        }
    }
}
