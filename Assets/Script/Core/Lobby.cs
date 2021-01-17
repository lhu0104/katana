using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lobby : MonoBehaviour
{
    public string selectedMusicName;
    public AudioSource bgmSource;
    private void Start() {
        PlayBGM();    
    }
    public void PlayBGM()
    {
        bgmSource.time = 27;
        bgmSource.enabled = true;
    }
    public void SetBGM()
    {

    }
}