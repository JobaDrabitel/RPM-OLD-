using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : BaseUnit
{
    public int _level;
    public string _name;
    public int _maxHP;
    public int _currentHP;
    public enum State {WAIT, TURN, DEAD}
}
