using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public abstract string Name { get; set;}
    public abstract int Level { get; set; }
    public abstract int MaxHP { get; set; }
    public abstract int ÑurrentHP { get; set; }
    public abstract int Sanity { get; set; }
    public abstract int Damage { get; set; }
    public abstract int Armor { get; set; }
    public abstract Skill GetSkill(int index);
    public abstract void SetSkill(int index, Skill skill);
    public enum StateMachine { WAIT, TURN, DEAD };
    public abstract StateMachine State { get; set; }
    public abstract void TakeDamage(int damage);
    public virtual void Die()
    {
        Debug.Log("Ïóê ïóê");
        this.gameObject.SetActive(false);
    }
    public virtual void Atack(int damage, Unit target)
    {
        Debug.Log("ÍÛÀ");
        target.TakeDamage(damage);
    }
}
