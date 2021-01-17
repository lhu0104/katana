using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class UIManager : MonoSingleton<UIManager>
{
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI judgeText;
    public RectTransform gameOverPanel;
    public RectTransform tiembar;
    public void OnAddCombo()
    {
        comboText.transform.DOKill();
        DOTween.Sequence().Append(comboText.transform.DOScale(Vector3.one * 1.05f, .05f).SetEase(Ease.OutBack)).Append(comboText.transform.DOScale(Vector3.one, .05f).SetEase(Ease.Linear));
        comboText.text = string.Format("{0}", GameMain.Instance.combo.ToString());

        judgeText.transform.DOKill();
        DOTween.Sequence().Append(judgeText.transform.DOScale(Vector3.one * 1.05f, .05f).SetEase(Ease.OutBack)).Append(judgeText.transform.DOScale(Vector3.one, .05f).SetEase(Ease.Linear));
        judgeText.text = string.Format("{0}!", GameMain.Instance.lastResult);
    }
    public void OnGameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
    }
    public void CloseGameOver()
    {

        gameOverPanel.gameObject.SetActive(false);
    }
    private void Update() {
        tiembar.localScale = new Vector3(MusicSpanwer.Instance.musicSource.time / MusicSpanwer.Instance.musicSource.clip.length, 1f, 1f);
        
    }
}