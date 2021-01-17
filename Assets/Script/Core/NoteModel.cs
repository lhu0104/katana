using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NoteModel : MonoBehaviour
{
    public Animator animator;
    public NoteData Note { get; set;}
    public static float speed = 10f;
    public Vector3 from;
    public Vector3 to;
    public void Set(NoteData note, Vector3 from, Vector3 to)
    {
        this.Note = note;
        this.from = from;
        this.to = to;
    }
    public void UpdatePosition()
    {
        var diff = this.Note.time - MusicSpanwer.Instance.musicSource.time;
        if(diff <= -GameMain.gameoverThr)
        {
            Time.timeScale =0;
            GameMain.Instance.paused = true;
            GameMain.Instance.GameOver();
        }
        float prob = Mathf.Clamp(diff, -1f, 1f);
        Vector3 position = from * (prob) + to * (1 - prob);
        this.transform.position = position;
        // this.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);    
    }
    #region Member Variables
    #endregion
    #region Properties
    #endregion
    #region Public Methods
    #endregion
    #region Protected Methods
    #endregion
    #region Private Methods
    #endregion
}