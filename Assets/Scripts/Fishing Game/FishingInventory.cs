using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FishingInventory : MonoBehaviour
{
    [SerializeField] private List<BaitInfo> m_Baits = new List<BaitInfo>();
    [SerializeField] private int maxBaits = 8;
    [SerializeField] private List<FishObtainedInfo> m_FishObtained = new List<FishObtainedInfo>();
    public List<FishObtainedInfo> FishInv => m_FishObtained;
    [SerializeField] private int maxFish = 3;

    public Action<List<BaitInfo>> OnBaitsModify;
    public Action OnBaitsComplete;
    public Action OnBaitsEmpty;

    public Action<List<FishObtainedInfo>> OnFishModify;
    public Action OnFishComplete;

    public void ResetInventory() 
    {
        m_Baits.Clear();
        m_FishObtained.Clear();
        OnBaitsModify?.Invoke(m_Baits);
        OnFishModify?.Invoke(m_FishObtained);
    }

    public void AddBait(BaitInfo newBait) 
    {
        if (m_Baits.Count < maxBaits) 
        {
            m_Baits.Add(newBait);
            OnBaitsModify?.Invoke(m_Baits);
        }         
        else
            OnBaitsComplete?.Invoke();
    }

    public void SubtractBait(BaitInfo oldBait)
    {
        if (m_Baits.Count < 0)
        {
            BaitInfo baitToRemove = m_Baits.First(x => x.m_BaitType == oldBait.m_BaitType);
            m_Baits.Remove(baitToRemove);
            OnBaitsModify?.Invoke(m_Baits);
        }
        else
            OnBaitsEmpty?.Invoke();
    }

    public void AddFish(FishInfo newFish)
    {
        FishObtainedInfo fish = new FishObtainedInfo(newFish);
        RarityInfo rarityInfo = GameManager.instance.Settings.RarityInfos.First(x => x.rarity == newFish._Rarity);
        fish.SetPoints(rarityInfo.points);
        m_FishObtained.Add(fish);


        if (m_FishObtained.Count < maxFish)        
            OnFishModify?.Invoke(m_FishObtained);       
        else
            OnFishComplete?.Invoke();
    }

    public bool Complete() 
    {
        if (m_FishObtained.Count < maxFish)
            return false;
        else
            return true;
    }
}

[Serializable]
public class BaitInfo 
{
    public Sprite m_Sprite;
    public string m_Name;
    public BaitType m_BaitType;

    [Header("Fish Bait Chances Settings List")]
    [SerializeField] private List<FishBait> _baitModify;
    public List<FishBait> _BaitModify => _baitModify;
}

[Serializable]
public class FishObtainedInfo
{
    public Sprite m_SpriteInv;
    public string m_Name;
    public RarityType m_Rarity;
    public int m_Points;

    public FishObtainedInfo(FishInfo fishInfo) 
    {
        m_SpriteInv = fishInfo._Sprite;
        m_Name = fishInfo._Name;
        m_Rarity = fishInfo._Rarity;
    }

    public void SetPoints(int point) => m_Points = point;
}
