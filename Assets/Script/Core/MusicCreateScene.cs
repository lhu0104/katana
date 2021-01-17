using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicCreateScene : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Text counter;
    [SerializeField] Text timeText;
    public string musicKey = "";
    private void Update() {
        counter.text = Time.time.ToString();
        timeText.text = audioSource.time.ToString();
        if(musicKey == "")
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Stamp(-1);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Stamp(1);
        }
    }
    private void Start() {
        Invoke("PlayMusic", 1f);
    }
    void PlayMusic()
    {
        audioSource.enabled = true;
    }
    public void Stamp(int direction)
    {
        var targetSheet = MusicConfiguration.Instance.musicSheets.Find(x => x.music_key == musicKey);
        if(targetSheet == null)
        {
            targetSheet = new MusicSheet(musicKey);
            MusicConfiguration.Instance.musicSheets.Add(targetSheet);
        }
        targetSheet.notes.Add(new NoteData(audioSource.time, direction));
    }
}