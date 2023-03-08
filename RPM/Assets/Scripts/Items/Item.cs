using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Item", fileName = "ItemData")]
public class Item : ScriptableObject
{
    [SerializeField] private int _iD;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    private enum EquipSlop {HEAD, NECK, BODE, LEGS, FEET, LEFTARM, RIGHTARM }
    [SerializeField] private EquipSlop _equipSlop;
    private enum QUALITY {POOR, COOMON, GOOD, WELL, MASTERLY, ARTEFACT }
    [SerializeField] private QUALITY _quality;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Skill _effect;
}
