using DG.Tweening;
using System;
using UnityEngine;

public class UISection : MonoBehaviour
{
    public string SectionID;
    public GameObject SectionContainer;
    public CanvasGroup UIContainer;
    public Action OnSectionAnimFinish;
    internal Sequence uiAnim;
    public UIOptionsSystem Options;

    public virtual void OnSectionIN(bool InAnim = false) 
    {
        if (InAnim)
        {
            UIContainer.alpha = 0;
            UIContainer.DOFade(1, .15f).SetDelay(.5f).OnComplete(()=> OnSectionAnimFinish?.Invoke());
        }
        else
            UIContainer.alpha = 1;
        SectionContainer.SetActive(true);
    }
    public virtual void OnSectionOUT() 
    {
        OnSectionAnimFinish = null;
        UIContainer.alpha = 0;
        SectionContainer.SetActive(false);      
    }
}
