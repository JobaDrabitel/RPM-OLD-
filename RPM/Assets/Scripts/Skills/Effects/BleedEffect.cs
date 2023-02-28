using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedEffect : MonoBehaviour, IEffect
{
    //[SerializeField] private Unit unit;
   public void Effect(Unit target, int lvl)
    {
        if (target.State == Unit.StateMachine.TURN)
        {
            target.TakeDamage(3 * lvl);
        }
    }
   
}
