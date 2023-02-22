using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public int _level = 1;
    public string _name = "Крыса";
    public int _maxHP = 10;
    public int _currentHP = 10;
    public int _sanity = 100;

    public enum State { WAIT, TURN, DEAD }
}
