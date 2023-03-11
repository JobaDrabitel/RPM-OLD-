using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHuman
{
    public Unit ChooseTarget(Unit[] units)
    {
        Unit target = units[0];
        double minDanger = units[0].CurrentHP + units[0].Armor + units[0].DodgeChance;

        foreach (Unit unit in units)
        {
            if (minDanger < unit.CurrentHP + unit.Armor + unit.DodgeChance && unit.State != Unit.StateMachine.DEAD)
            {
                minDanger = unit.CurrentHP + unit.Armor + unit.DodgeChance;
                target = unit;
            }
        }
        return target;
    }
}
