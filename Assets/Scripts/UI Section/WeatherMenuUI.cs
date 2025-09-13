using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeatherMenuUI : UISection
{
    [SerializeField] private Image m_BG;

    public override void OnSectionIN(bool anim)
    {
        base.OnSectionIN(true);
    }

    public override void OnSectionOUT()
    {
        base.OnSectionOUT();
    }
}
