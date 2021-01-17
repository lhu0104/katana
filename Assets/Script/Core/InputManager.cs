using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoSingleton<InputManager>
{
    [SerializeField] Player player;
    public void OnInputLeft()
    {
            int i = Random.Range(0, 4);
            this.player.SetTrigger("OnAttack" + i);
            this.player.Look(-1);
            GameMain.Instance.CheckLeft();

    }
    public void OnInputRight()
    {
        int i = Random.Range(0, 4);
            this.player.SetTrigger("OnAttack" + i);
            this.player.Look(1);
            GameMain.Instance.CheckRight();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnInputLeft();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnInputRight();
        }
    }
}