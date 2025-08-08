using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : UISection
{
    [SerializeField] private Image m_BG;
    [SerializeField] private Button m_StartGame;

    public override void OnSectionIN()
    {
        base.OnSectionIN();
        m_StartGame.onClick.AddListener(StartClicked);
    }

    public override void OnSectionOUT()
    {
        m_StartGame.onClick.RemoveAllListeners();
        base.OnSectionOUT();
    }

    private void StartClicked() 
    {
        
    }
}
