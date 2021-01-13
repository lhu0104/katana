using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MusicCreateScene : MonoBehaviour
{
    public string musicKey = "";
    private void Update() {
        if(musicKey == "")
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Stamp();
        }
    }
    public void Stamp()
    {
        var targetSheet = MusicConfiguration.Instance.musicSheets.Find(x => x.music_key == musicKey);
        if(targetSheet == null)
        {
            targetSheet = new MusicSheet(musicKey);
            MusicConfiguration.Instance.musicSheets.Add(targetSheet);
        }
        targetSheet.notes.Add(new NoteData(Time.time));
    }
}