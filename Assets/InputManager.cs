using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    [SerializeField] Player player;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            int i = Random.Range(0, 4);
            player.SetTrigger("OnAttack" + i);
        }
    }
}