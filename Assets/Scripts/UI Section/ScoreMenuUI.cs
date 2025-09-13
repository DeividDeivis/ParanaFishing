using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreMenuUI : UISection
{
    [SerializeField] private TextMeshProUGUI m_Title;
    [SerializeField] private TextMeshProUGUI m_Point;

    public override void OnSectionIN(bool anim)
    {
        m_Title.color = new Color(m_Title.color.r, m_Title.color.g, m_Title.color.b, 0f);
        m_Point.color = new Color(m_Point.color.r, m_Point.color.g, m_Point.color.b, 0f);
        base.OnSectionIN(true);
        OnSectionAnimFinish += ScoreAnim;
    }

    public override void OnSectionOUT()
    {
        uiAnim.Kill();
        base.OnSectionOUT();
    }

    private void ScoreAnim()
    {
        uiAnim = DOTween.Sequence().SetEase(Ease.Linear)
            .Append(m_Title.transform.DOScale(Vector3.one * 1.3f, .25f))
            .Join(m_Title.DOFade(1, .25f))
            .Append(m_Title.transform.DOScale(Vector3.one, .25f))
            .Append(m_Point.transform.DOScale(Vector3.one * 1.3f, .25f))
            .Join(m_Point.DOFade(1, .25f))
            .Append(m_Point.transform.DOScale(Vector3.one, .25f));
    }

    public void SetScore(int score) { m_Point.text = $"{score} PUNTOS"; }
}
