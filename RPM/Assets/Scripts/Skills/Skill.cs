using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour, IEffect
{
    private int _skillId;
    private string _skillName;
    private string _skillDescription;
    private int _skillLevel;
    private bool _onEnemy;
    private int _coolDown;
}
