using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PathologicalGames;
public class GameMain : MonoSingleton<GameMain>
{
    public const float gameoverThr = .2f;
    public bool paused;
    public string lastResult;
    public int combo;
    public Queue<NoteModel> leftQueue = new Queue<NoteModel>();
    public Queue<NoteModel> rightQueue = new Queue<NoteModel>();
    public List<NoteModel> managedModels = new List<NoteModel>();
    public NoteModel leftCurrent = null;
    public NoteModel rightCurrent = null;
    public void AddNote(NoteModel newModel)
    {
        newModel.enabled = true;
        managedModels.Add(newModel);
        if(newModel.Note.direction == -1)
        {
            leftQueue.Enqueue(newModel);
            if(leftCurrent == null)
            {
                leftCurrent = leftQueue.Dequeue();
            }
        }
        else
        {
            rightQueue.Enqueue(newModel);
            if(rightCurrent == null)
            {
                rightCurrent = rightQueue.Dequeue();
            }
        }
    }
    private void Update() {
        if(paused) return;
        
        List<NoteModel> remove = new List<NoteModel>();
        foreach(var item in managedModels)
        {
            if(item.enabled)
            {
                item.UpdatePosition();
            }
            else
            {
                remove.Add(item);
            }
        }
        foreach(var item in remove)
        {
            managedModels.Remove(item);

        }
    }

    public const float judgeThr = .2f;
    public void CheckRight()
    {
        NoteModel current = rightCurrent;
        if(current != null)
        {
            var diff = current.Note.time - MusicSpanwer.Instance.musicSource.time;
            // var diff = MusicSpanwer.Instance.musicSource.time - current.Note.time;
            if(-1f * gameoverThr <= diff && diff <= judgeThr)
            {
                AddCombo(current, rightQueue, diff);
                if(rightQueue.Count > 0)
                    rightCurrent = rightQueue.Dequeue();
                else
                    rightCurrent = null;
            }
        }
    }
    void AddCombo(NoteModel current, Queue<NoteModel> queue, float diff)
    {
        if(-1f * gameoverThr <= diff && diff <= judgeThr)
        {
            combo++;
            current.enabled =false;
            Vector3 targetPosition = new Vector3((float)current.Note.direction * Random.Range(0f, 2f), 0, Random.Range(15, 24)) + Vector3.up * Random.Range(3, 8);
            Vector3 targetTorgue = Vector3.up * 360 * Random.Range(0f, 4f);
            DOTween.Sequence().Append(current.transform.DOMove(current.transform.position + targetPosition, .5f).SetEase(Ease.OutCirc)).Append(current.transform.DOMoveY(-15, .7f).SetEase(Ease.InSine));
            current.transform.DOLocalRotate(targetTorgue, .5f, RotateMode.FastBeyond360).SetEase(Ease.OutCirc);
            current.animator.SetTrigger("Die");
            UIManager.Instance.OnAddCombo();
            WorldCamera.Instance.Shake();
        }
        else
        {

        }
    }
    public void CheckLeft()
    {
        NoteModel current = leftCurrent;
        if(current != null)
        {
            var diff = Mathf.Abs(MusicSpanwer.Instance.musicSource.time - current.Note.time);
            if(diff < .1f)
            {
                AddCombo(current, leftQueue, diff);
                if(leftQueue.Count > 0)
                    leftCurrent = leftQueue.Dequeue();
                else
                    leftCurrent = null;
            }
        }
    }
    public void GameOver()
    {
        MusicSpanwer.Instance.StopMusic();
        UIManager.Instance.OnGameOver();
    }
    private void GameStart() {
        MusicSpanwer.Instance.OnGameStart();   
    }
    public void Restart()
    {
        leftQueue.Clear();
        rightQueue.Clear();
        managedModels.Clear();
        leftCurrent = null;
        rightCurrent = null;

        combo = 0;
        PoolManager.Pools["Note"].DespawnAll();
        MusicSpanwer.Instance.OnGameStart();   

UIManager.Instance.CloseGameOver();
    }
    public void Home()
    {

    }
}