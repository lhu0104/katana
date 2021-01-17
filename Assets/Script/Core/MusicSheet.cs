using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class MusicSheet
{
    public string music_key;
    public List<NoteData> notes = new List<NoteData>();
    public MusicSheet(string key)
    {
        this.music_key = key;
    }
}