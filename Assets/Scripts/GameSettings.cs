using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "Fishing Game Assets/Create Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Shoot Settings")]
    [SerializeField] private float minShootRange;
    public float MinShootRange => minShootRange;
    [SerializeField] private float maxShootRange;
    public float MaxShootRange => maxShootRange;
    [SerializeField] private float powerBarSpeed;
    public float PowerBarSpeed => powerBarSpeed;
}
