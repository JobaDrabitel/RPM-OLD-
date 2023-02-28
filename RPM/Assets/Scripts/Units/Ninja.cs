using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Unit 
{
    private int _level = 1;
    public override int Level { get => _level; set => _level = value; }
    private string _name = "Ниндзя";
    public override string Name { get =>_name; set =>_name = value; } 
    private int _maxHP = 20;
    public override int MaxHP { get => _maxHP; set => _maxHP = value; }
    private int _currentHP = 20;
    public override int СurrentHP { get => _currentHP; set => _currentHP = value; }
    private int _sanity = 100;
    public override int Sanity { get => _sanity; set => _sanity = value; }
    private int _damage = 10;
    public override int Damage { get => _damage; set => _damage = value ; }
    private int _armor = 0;
    public override int Armor { get => _armor; set => _armor = value; }
    [SerializeField] private Skill[] _skills = new Skill[3];
    public override Skill GetSkill(int index)
    {
        return _skills[index];
    }
    public override void SetSkill(int index, Skill skill)
    {
        _skills[index] = skill;
    }
    private StateMachine _state = StateMachine.TURN;
    public override StateMachine State { get => _state; set => _state = value; }
    public override void Atack(int damage, Unit target)
    {
        base.Atack(damage, target);
        Debug.Log("Я твоя тень, кагами");
    }
    public override void TakeDamage(int damage)
    {
        _currentHP -= damage-_armor;
        if (_currentHP <= 0)
            Die();
    }
    public override void Die()
    {
        Debug.Log("Похуй проебали");
        this.gameObject.SetActive(false);
    }

}
