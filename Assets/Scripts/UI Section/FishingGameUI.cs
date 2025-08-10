using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishingGameUI : UISection
{
    [SerializeField] private Slider powerBar;
    [SerializeField] private GameObject fishInfoContainer;
    [SerializeField] private Image fishImg;
    [SerializeField] private TextMeshProUGUI fishName;
    [SerializeField] private GameObject failedContainer;

    public override void OnSectionIN()
    {
        base.OnSectionIN();
    }

    public override void OnSectionOUT()
    {
        base.OnSectionOUT();
    }

    public void SetPowerBar(float value)
    {
        powerBar.value = value;
    }

    public void ShowFishInfo(FishInfo fish) 
    {
        fishImg.sprite = fish._Sprite;
        fishName.text = fish._Name;
        fishInfoContainer.SetActive(true);
    }

    public void ShowFailed()
    {
        failedContainer.SetActive(true);
    }

    public void HideMessages()
    {
        fishInfoContainer.SetActive(false);
        failedContainer.SetActive(false);
    }
}
