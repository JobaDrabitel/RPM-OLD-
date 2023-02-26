using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Unit : MonoBehaviour
{
    //private string _name = "Юнит"; 
    //private int _level;
    //private int _maxHP;
    private int _currentHP { get; set; }
    //private int _sanity;


    //public enum State { WAIT, TURN, DEAD };
    //public State _state;
    public virtual void TakeDamage(int damage)
    {
        _currentHP -= damage;   
        if (_currentHP <= 0)
            Die();
    }
    public virtual void Die()
    {
        Debug.Log("Пук пук");
        this.gameObject.SetActive(false);
    }
    public virtual void Atack(int damage, Unit target)
    {
        target.TakeDamage(damage);
        Debug.Log("НЫА");
    }
}
