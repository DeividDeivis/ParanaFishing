using System;
using System.Collections.Generic;
using UnityEngine;

public class FishGroupController : MonoBehaviour
{
    [SerializeField] private List<FishInfo> fishInGroup = new List<FishInfo>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FishingRodController.OnBaitInWater += CheckFishingChances;
        //BuildGroup();
    }

    private void CheckFishingChances(Vector3 baitPos)
    {
        /*float range = GameManager.instance.Settings.FishingRange;
        float currentDistance = Vector3.Distance(transform.position, baitPos);

        if (currentDistance < range)
        {*/
            BuildGroup();
        /*}
        else
            return;*/
    }

    private void BuildGroup() 
    {
        var settings = GameManager.instance.Settings;
        int fishAmount = UnityEngine.Random.Range(settings.MinFishGroup, settings.MaxFishGroup + 1);

        var randomFishList = new List<FishInfo>(settings.FishesInfo);

        for (int i = 0; i < fishAmount; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, randomFishList.Count + 1);
            fishInGroup.Add(randomFishList[randomIndex]);
            randomFishList.Remove(randomFishList[randomIndex]);
        }
    }

    public FishInfo GetRandomFish() 
    {
        int randomIndex = UnityEngine.Random.Range(0, fishInGroup.Count);
        return fishInGroup[randomIndex];
    }

#if UNITY_EDITOR
    public FishInfo GetFishByIndex(int index) 
    {
        return fishInGroup[index];
    }
    public int FishAmount() { return fishInGroup.Count; }
#endif
}
