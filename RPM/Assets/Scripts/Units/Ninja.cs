using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Unit
{
    public  int level = 1;
    public new string  _name { get; set; }
    public  int maxHP = 20;
    public int _currentHP = 20;
    public int _sanity = 100;

   

    public enum State {WAIT, TURN, DEAD}
}
