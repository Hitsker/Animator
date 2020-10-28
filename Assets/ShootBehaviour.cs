using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : StateMachineBehaviour
{
    private const string ExitShootStr = "ExitShoot";
    private static readonly int ExitShootHash = Animator.StringToHash(ExitShootStr);
    
    private float colorTime = 2f;
    private float exitTime = 3f;
    private float timer;

    private bool isRed = false;

    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > colorTime && !isRed)
        {
            Debug.Log("COLORING");
            isRed = true;
            animator.GetComponent<Gun>().GunBody.material.color=Color.red;
        }

        if (timer>exitTime)
        {
            animator.SetTrigger(ExitShootHash);
            animator.GetComponent<Gun>().GunBody.material.color=Color.white;
            isRed = false;
            timer = 0f;
        }
    }

}
