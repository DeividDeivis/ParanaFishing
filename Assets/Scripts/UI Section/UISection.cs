using DG.Tweening;
using UnityEngine;

public class UISection : MonoBehaviour
{
    public string SectionID;
    public GameObject SectionContainer;
    internal Sequence uiAnim;

    public virtual void OnSectionIN() 
    {
        SectionContainer.SetActive(true);
    }
    public virtual void OnSectionOUT() 
    {
        SectionContainer.SetActive(false);
    }
}
