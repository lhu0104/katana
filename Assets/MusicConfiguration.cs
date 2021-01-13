using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MusicConfiguration : ScriptableObject
{
    private static MusicConfiguration instance = null;
    public static MusicConfiguration Instance
    {
        get
        {
            if(instance == null)
            {
                instance = Resources.Load("MusicConfiguration") as MusicConfiguration;
            }
            return instance;
        }
    }
    public List<MusicSheet> musicSheets = new List<MusicSheet>();
}