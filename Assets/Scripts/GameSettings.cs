using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "Fishing Game Assets/Create Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Player Settings")]
    [SerializeField] private float playerRotationSpeed;
    public float RotationSpeed => playerRotationSpeed;

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
}
