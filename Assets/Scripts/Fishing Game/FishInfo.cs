using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FishInfo", menuName = "Fishing Game Assets/Create FishInfo")]
public class FishInfo : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    public Sprite _Sprite => _sprite;
    [SerializeField] private string _name;
    public string _Name => _name;

    [Header("Probability")]
    [Range(0f, 100f)][SerializeField] private float _chanceToAppearInGroup;
    public float _ChanceToAppear => _chanceToAppearInGroup;
    [SerializeField] private List<BaitModify> _baitsModify;
    public List<BaitModify> _BaitsModify => _baitsModify;
}

[Serializable]
public class BaitModify
{
    [SerializeField] private BaitType _bait;
    public BaitType _Bait => _bait;
    [SerializeField] private float _chanceModify;
    public float _ChanceModify => _chanceModify;
}

public enum BaitType { worm, burger }