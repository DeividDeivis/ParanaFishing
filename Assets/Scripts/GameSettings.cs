using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "Fishing Game Assets/Create Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Player Settings")]
    [SerializeField] private float playerRotatioSpeed;
    public float RotatioSpeed => playerRotatioSpeed;

    [Header("Shoot Settings")]
    [SerializeField] private float minShootRange;
    public float MinShootRange => minShootRange;
    [SerializeField] private float maxShootRange;
    public float MaxShootRange => maxShootRange;
    [SerializeField] private float powerBarSpeed;
    public float PowerBarSpeed => powerBarSpeed;

    [Header("Fish Groups Settings")]
    [SerializeField] private float minFishGroup;
    public float MinFishGroup => minFishGroup;
    [SerializeField] private float maxFishGroup;
    public float MaxFishGroup => minFishGroup;
}
