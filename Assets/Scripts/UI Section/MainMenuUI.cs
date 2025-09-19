using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : UISection
{
    [SerializeField] private TextMeshProUGUI m_Title;
    [SerializeField] private TextMeshProUGUI m_StartGame;
    [SerializeField] private float m_AnimDelay = 1.0f;

    public override void OnSectionIN(bool anim)
    {
        m_Title.color = new Color(m_Title.color.r, m_Title.color.g, m_Title.color.b, 0f);
        m_StartGame.color = new Color(m_StartGame.color.r, m_StartGame.color.g, m_StartGame.color.b, 0f);
        base.OnSectionIN(true);
        OnSectionAnimFinish += MenuAnim;
    }

    public override void OnSectionOUT()
    {
        uiAnim.Kill();
        base.OnSectionOUT();
    }

    private void MenuAnim() 
    {
        uiAnim = DOTween.Sequence().SetEase(Ease.Linear).SetDelay(m_AnimDelay)
            .Append(m_Title.transform.DOScale(Vector3.one * 1.3f, .25f))
            .Join(m_Title.DOFade(1, .25f))
            .Append(m_Title.transform.DOScale(Vector3.one, .25f))
            .Append(m_StartGame.DOFade(1, 2).SetDelay(1).SetLoops(-1, LoopType.Yoyo));
    }
}
