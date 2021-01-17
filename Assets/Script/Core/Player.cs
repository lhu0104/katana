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
    public void Look(int direction)
    {
        this.transform.localRotation = Quaternion.Euler(new Vector3(0, 90 * direction, 0));
    }
}