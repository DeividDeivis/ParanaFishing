using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FishInfo", menuName = "Fishing Game Assets/Create FishInfo")]
public class FishInfo : ScriptableObject
{
    [SerializeField] private Sprite _spriteInv;
    public Sprite _Sprite => _spriteInv;
    [SerializeField] private string _name;
    public string _Name => _name;
    [SerializeField] private RarityType _rarity;
    public RarityType _Rarity => _rarity;

    [SerializeField] private List<Sprite> _spritesAnim;
    public List<Sprite> _SpritesAnim => _spritesAnim;

    [Header("Probability")]
    [Range(0f, 100f)][SerializeField] private float _chanceToAppearInGroup;
    public float _ChanceToAppear => _chanceToAppearInGroup;
}

[Serializable]
public class FishBait 
{
    public RarityType FishRarity;
    [Range(0, 100)] public int _chanceBait;
}

public enum BaitType { worm, liveBait, carlito }

public enum RarityType { trash, common, rare, epic, legendary }