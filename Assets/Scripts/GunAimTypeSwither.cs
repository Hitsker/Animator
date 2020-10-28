using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAimTypeSwither : MonoBehaviour
{
    [SerializeField] private String _clipName = "GunAim1";
    [SerializeField] private AnimationClip _aimVariant;
    
    private Animator _animator;
    private AnimatorOverrideController _animatorOverrideController;
    private RuntimeAnimatorController _defaultController;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _defaultController = _animator.runtimeAnimatorController;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _animatorOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
            var test = _animatorOverrideController[_clipName];
            _animatorOverrideController[_clipName] = _aimVariant;
            _animator.runtimeAnimatorController = _animatorOverrideController;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _animator.runtimeAnimatorController = _defaultController;
        }
        
    }
}
