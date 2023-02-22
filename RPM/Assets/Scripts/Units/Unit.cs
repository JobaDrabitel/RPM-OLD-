using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Unit : MonoBehaviour
{
    public string _name; 
    private int _level;
    private int _maxHP;
    private int _currentHP;
    private int _sanity;
   
  
    public enum State { WAIT, TURN, DEAD };
    public State _state;
}
