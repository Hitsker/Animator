using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private Animator _animator;
    
    private const string Trigger = "trigger";
    private static readonly int TriggerHash = Animator.StringToHash(Trigger);

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(TriggerHash);
        }
    }
}
