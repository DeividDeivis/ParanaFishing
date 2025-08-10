using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : UISection
{
    [SerializeField] private Image m_BG;
    [SerializeField] private TextMeshProUGUI m_Title;
    [SerializeField] private TextMeshProUGUI m_StartGame;

    public override void OnSectionIN()
    {
        base.OnSectionIN();
    }

    public override void OnSectionOUT()
    {
        base.OnSectionOUT();
    }
}
