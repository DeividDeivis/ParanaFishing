using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "Fishing Game Assets/Create Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Player Settings")]
    [SerializeField] private float playerRotationSpeed;
    public float RotationSpeed => playerRotationSpeed;
    [SerializeField] private float maxRotationAngle;
    public float MaxRotationAngle => maxRotationAngle;

    [Header("Gameplay Animation Settings")]
    [SerializeField] private float initialPlayerPos;
    public float InitialPlayerPos => initialPlayerPos;
    [SerializeField] private float finishPlayerPos;
    public float FinishPlayerPos => finishPlayerPos;
    [SerializeField] private float playerMovAnimSpeed;
    public float PlayerMovAnimSpeed => playerMovAnimSpeed;

    [Header("Shoot Settings")]
    [SerializeField] private float minShootRange;
    public float MinShootRange => minShootRange;

    [SerializeField] private float maxShootRange;
    public float MaxShootRange => maxShootRange;

    [SerializeField] private float powerBarSpeed;
    public float PowerBarSpeed => powerBarSpeed;

    [Header("Fish Groups Settings")]
    [SerializeField] private int minFishGroup;
    public int MinFishGroup => minFishGroup;

    [SerializeField] private int maxFishGroup;
    public int MaxFishGroup => minFishGroup;

    [SerializeField] private float fishingRange;
    public float FishingRange => fishingRange;

    [Header("Fish Settings List")]
    [SerializeField] private List<FishInfo> fishesInGame;
    public List<FishInfo> FishesInfo => fishesInGame;

    [Header("Baits Settings List")]
    [SerializeField] private List<BaitInfo> baitsInGame;
    public List<BaitInfo> BaitsInGame => baitsInGame;

    [Header("Rarity Settings List")]
    [SerializeField] private List<RarityInfo> rarityInfos;
    public List<RarityInfo> RarityInfos => rarityInfos;
}

[Serializable]
public class RarityInfo 
{
    public RarityType rarity;
    public int points;
}
