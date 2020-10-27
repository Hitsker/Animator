using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Animator))]
public class RandomBlend : MonoBehaviour
{
    private Animator _animator;
    private Button _button;
    
    private const string Color = "Color";
    private static readonly int ColorHash = Animator.StringToHash(Color);
    
    private const string Size = "Size";
    private static readonly int SizeHash = Animator.StringToHash(Size);
    
    private const string Rotation = "Rotation";
    private static readonly int RotationHash = Animator.StringToHash(Rotation);
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetRandomValues);

        SetRandomValues();
    }

    private void SetRandomValues()
    {
        _animator.SetFloat(ColorHash, Random.Range(0f, 1f));
        _animator.SetFloat(SizeHash, Random.Range(0f, 1f));
        _animator.SetFloat(RotationHash, Random.Range(0f, 1f));
    }
}
