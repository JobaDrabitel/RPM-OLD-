using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Unit
{
    public int _level = 1;
    public  string _name = "Крыса";
    public int _maxHP = 10;
    public int _currentHP = 10;
    public int _sanity = 100;

    public override void TakeDamage(int damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0)
            Die();

    }
    public enum State { WAIT, TURN, DEAD }
}
