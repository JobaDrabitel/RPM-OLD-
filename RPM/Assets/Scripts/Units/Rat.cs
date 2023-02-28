using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Unit
{
    private int _level = 1;
    public override int Level { get => _level; set => _level = value; }
    private string _name = "Крысо";
    public override string Name { get => _name; set => _name = value; }
    private int _maxHP = 10;
    public override int MaxHP { get => _maxHP; set => _maxHP = value; }
    public int _currentHP = 10;
    public override int СurrentHP { get => _currentHP; set => _currentHP = value; }
    public int _sanity = 100;
    public override int Sanity { get => _sanity; set => _sanity = value; }
    private int _damage = 5;
    public override int Damage { get => _damage; set => _damage = value; }
    private int _armor = 0;
    public override int Armor { get => _armor; set => _armor = value; }

    private StateMachine _state;
    public override StateMachine State { get => _state; set =>_state = value; }

   [SerializeField] private Skill[] _skills = new Skill[3];
    public override Skill GetSkill(int index)
    {
        return _skills[index];
    }
    public override void SetSkill(int index, Skill skill)
    {
        _skills[index] = skill;
    }
    public override void TakeDamage(int damage)
    {
        _currentHP -= damage-_armor;
        if (_currentHP <= 0)
            Die();

    }
    
}
