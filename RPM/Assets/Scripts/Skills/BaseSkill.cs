using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill : MonoBehaviour, IEffect
{
    public int skillId;
    public string skillName;
    public string skillDescription;
    public int skillLevel;
    public bool onEnemy;
}
