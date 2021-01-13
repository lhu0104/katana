using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void SetTrigger(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
    public void Look(Direction direction)
    {

    }
}