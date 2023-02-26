using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Unit
{
    public  int level = 1;
    public string _name = "Ниндзя";
    public  int maxHP = 20;
    public int _currentHP = 20;
    public int _sanity = 100;
    public int _damage = 10;

    public override void Atack(int damage, Unit target)
    {
        base.Atack(damage, target);
        Debug.Log("Я твоя тень, кагами");
    }

    public enum State {WAIT, TURN, DEAD}
}
