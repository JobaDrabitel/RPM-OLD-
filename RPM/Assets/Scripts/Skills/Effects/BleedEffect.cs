using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedEffect : MonoBehaviour, IEffect
{
    [SerializeField] private Unit unit;
    private Ninja ninja;
   public void Effect(GameObject target, int lvl)
    {
       if(unit._state == Unit.State.TURN)
        { }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(unit._name);
        }
    }
}
