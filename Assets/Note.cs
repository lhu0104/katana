using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NoteData
{
    public float time;
    public int direction;
    public NoteData(float time)
    {
        this.time = time;
        direction = 1;
    }
}