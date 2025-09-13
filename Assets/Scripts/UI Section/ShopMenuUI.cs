using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuUI : UISection
{
    [SerializeField] private List<Image> _BaitsImg = new List<Image>();

    public override void OnSectionIN(bool anim)
    {
        base.OnSectionIN(true);
        ResetHub();
        FishingSystem.instance.Inv.OnBaitsModify += UpdateBaitsImgs;
    }

    public override void OnSectionOUT()
    {
        FishingSystem.instance.Inv.OnBaitsModify -= UpdateBaitsImgs;

        base.OnSectionOUT();
    }

    public void ResetHub()
    {
        foreach (var bait in _BaitsImg)
        {
            bait.gameObject.SetActive(false);
        }
    }

    public void UpdateBaitsImgs(List<BaitInfo> newBaits) 
    {
        for (int i = 0; i < newBaits.Count; i++) 
        {
            _BaitsImg[i].sprite = newBaits[i].m_Sprite;
            _BaitsImg[i].gameObject.SetActive(true);
        }
    }
}
