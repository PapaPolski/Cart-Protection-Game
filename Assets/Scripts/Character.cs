using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObjects/Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;
    public float speed;
    public float craftSpeedModifier;
    public float cartSpeedModifier;
    public float scoreModifier;
    public SpecialAbility specialAbility;
    public bool unlockedFromStart;
    public int unlockConditionAmount;
    public string unlockText;
    public string playerPrefKey;
    public string flavorText;
}

public enum SpecialAbility
{
    AutoReequip,
    PauseUnpauseCart,
    None,
    Dodge
}

