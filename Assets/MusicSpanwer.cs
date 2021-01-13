using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MusicSpanwer : Spawner
{
    [SerializeField] NoteModel noteModelPrefab;
    public Transform spawnPoint;
    public Transform endPoint;
    public IEnumerator ReadMusicSheet(MusicSheet musicSheet)
    {
        float timer = 0f;
        Queue<NoteData> noteQueue = new Queue<NoteData>();
        
        foreach(var item in musicSheet.notes)
        {
            noteQueue.Enqueue(item);
        }
        NoteData currentNote = null;

        while(true)
        {
            if(noteQueue.Count > 0 && currentNote == null)
            {
                currentNote = noteQueue.Dequeue();
            }
            if(currentNote.time <= timer)
            {
                Spawn();
                currentNote = null;
                if(noteQueue.Count == 0)
                {
                    yield break;
                }
            }
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
    public override void Spawn()
    {
        var newModel = Instantiate(noteModelPrefab, spawnPoint.position, Quaternion.identity);
        newModel.transform.LookAt(endPoint);
    }
    public string musicKey;
    private void Start()
    {
        MusicSheet sheet = MusicConfiguration.Instance.musicSheets.Find(x => x.music_key == musicKey);
        if(sheet != null)
        {
            StartCoroutine(ReadMusicSheet(sheet));
        }
    }
}