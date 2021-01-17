using PathologicalGames;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MusicSpanwer : MonoSingleton<MusicSpanwer>
{
    public AudioSource musicSource;
    [SerializeField] NoteModel noteModelPrefab;
    protected const float spawnDistance = 12;
    protected const float judgeDistance = 1.9f;
    protected Vector3 spawnPointLeft = Vector3.left * spawnDistance;
    protected Vector3 spawnPointRight = Vector3.right * spawnDistance;
    protected Vector3 judgePointLeft = Vector3.left * judgeDistance;
    protected Vector3 judgePointRight = Vector3.right * judgeDistance;
    [SerializeField] LineRenderer lineLeft;
    [SerializeField] LineRenderer lineRight;
    
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
                Spawn(currentNote.direction, currentNote);
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
    public IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(3f);
        musicSource.enabled = true;
    }
    public void Spawn(int direction, NoteData note)
    {
        var spawnPoint = direction == -1 ? spawnPointLeft : spawnPointRight;
        var judgePoint = direction == -1 ? judgePointLeft : judgePointRight;
        var newModel = PoolManager.Pools["Note"].Spawn("NoteModel", spawnPoint, Quaternion.identity).GetComponent<NoteModel>();
        // var newModel = Instantiate(noteModelPrefab, spawnPoint, Quaternion.identity);
        newModel.Set(note, spawnPoint, judgePoint);
        newModel.transform.LookAt(judgePoint);
        GameMain.Instance.AddNote(newModel);
    }
    public string musicKey;
    public void OnGameStart()
    {
        MusicSheet sheet = MusicConfiguration.Instance.musicSheets.Find(x => x.music_key == musicKey);
        if(sheet != null)
        {
            StartCoroutine(ReadMusicSheet(sheet));
            StartCoroutine(PlayMusic());
        }
        lineLeft.SetPosition(0, new Vector3(-1 * judgeDistance, -15, 0));
        lineLeft.SetPosition(1, new Vector3(-1 * judgeDistance, 15, 0));
        lineRight.SetPosition(0, new Vector3(judgeDistance, -15, 0));
        lineRight.SetPosition(1, new Vector3(judgeDistance, 15, 0));
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    
}