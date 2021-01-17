using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 to;
    Vector3 diff;
    private void Start() {
        SetDiff();    
    }
    void SetDiff()
    {
        diff = this.transform.position - target.transform.position;
    }
    void LateUpdate()
    {
        to = diff + target.transform.position;
        this.transform.position = Vector3.Lerp(to, this.transform.position, .1f);
    }
}
