using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBuffEffect : MonoBehaviour, IEffect
{
    //[SerializeField] private Unit unit;
    public void Effect(Unit target, int lvl)
    {
        Debug.Log(target.Armor);
        target.Armor += 2 * lvl;
        Debug.Log(target.Armor);
    }

}
