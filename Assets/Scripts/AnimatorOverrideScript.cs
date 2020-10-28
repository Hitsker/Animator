using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorOverrideScript : MonoBehaviour
{
    public AnimationClip NewClip;
    private Animator _Animator;
    private AnimatorOverrideController _AnimatorOverrideController;
    
    void Start()
    {
        _Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _AnimatorOverrideController =
            new AnimatorOverrideController(_Animator.runtimeAnimatorController) {["State"] = NewClip};
        _Animator.runtimeAnimatorController = _AnimatorOverrideController;
    }
}
