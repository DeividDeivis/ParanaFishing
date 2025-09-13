using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishingGameUI : UISection
{
    [Header("Bait Cam")]
    [SerializeField] private GameObject baitCam;
    [SerializeField] private Animator _splash;
    [SerializeField] private Animator _bait;

    [Header("Inventory")]
    [SerializeField] private List<Image> fishInventoryImg;
    [SerializeField] private List<TextMeshProUGUI> fishInventoryText;
    [SerializeField] private List<Color> textColors;

    [SerializeField] private Slider powerBar;
    [SerializeField] private GameObject fishInfoContainer;
    [SerializeField] private Image fishImg;
    [SerializeField] private TextMeshProUGUI fishName;
    [SerializeField] private GameObject failedContainer;

    public override void OnSectionIN(bool anim)
    {
        base.OnSectionIN();

        foreach (var item in fishInventoryImg)
        {
            item.gameObject.SetActive(false);
        }

        foreach (var text in fishInventoryText)
        {
            text.text = "";
        }

        FishingSystem.instance.Inv.OnFishModify += UpdateInventory;
    }

    public override void OnSectionOUT()
    {
        base.OnSectionOUT();
    }

    public void SetPowerBar(float value)
    {
        powerBar.value = value;
    }

    public void SplashAnim() { _splash.SetTrigger("Splash"); }

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

    public void UpdateInventory(List<FishObtainedInfo> fishObtaineds) 
    {
        foreach (var item in fishInventoryImg)       
            item.gameObject.SetActive(false);
        foreach (var text in fishInventoryText)      
            text.text = "";

        for(int i = 0; i < fishObtaineds.Count; i++)
        {
            fishInventoryImg[i].sprite = fishObtaineds[i].m_SpriteInv;
            fishInventoryImg[i].gameObject.SetActive(true);
            RarityInfo rarityInfo = GameManager.instance.Settings.RarityInfos.First(x => x.rarity == fishObtaineds[i].m_Rarity);
            fishInventoryText[i].text = $"{rarityInfo.points}P";
        }
    }
}
