using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimal 
{
  public virtual Unit ChooseTarget(Unit[] units)
    {
        Unit target = units[0];
        double maxInjuries = units[0].CurrentHP / units[0].MaxHP;

        foreach (Unit unit in units)
        {
            if (maxInjuries < unit.CurrentHP / unit.MaxHP && unit.State!= Unit.StateMachine.DEAD)
            {
                maxInjuries = unit.CurrentHP / unit.MaxHP;
                target = unit;
            }
        }
        return target;
    }
}
