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
}

public enum SpecialAbility
{
    AutoReequip,
    PauseUnpauseCart,
    None,
    Dodge,

}
