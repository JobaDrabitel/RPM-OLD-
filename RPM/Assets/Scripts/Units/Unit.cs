using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public abstract string Name { get; set;}
    public abstract int Lvl { get;}
    public abstract int MaxHP { get; set; }
    public abstract int CurrentHP { get;}
    public abstract int Sanity { get; set; }
    public abstract int Damage { get; set; }
    public abstract int Armor { get; set; }
    public abstract int EXP { get; }
    public abstract int Initiative { get; set; }
    public abstract void GetCurrentEffects();
    public abstract void SetCurrentEffects(IEffect effect);
    public abstract Skill GetSkill(int index);
    public abstract void SetSkill(int index, Skill skill);
    public enum StateMachine { WAIT, TURN, DEAD };
    public abstract StateMachine State { get; set; }
    public abstract void TakeDamage(int damage);
    public virtual void Die()
    {
        Debug.Log("Пук пук");
        this.gameObject.SetActive(false);
        this.State = StateMachine.DEAD;
    }
    public virtual void Atack(int damage, Unit target)
    {
        Debug.Log("НЫА");
        target.TakeDamage(damage);
    }
    protected abstract void LvlUp();
    public abstract void AddExp(int exp);
    public abstract void Heal(int heal);
}
