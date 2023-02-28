using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueEffect : MonoBehaviour
{
    public void Effect(Unit target, int lvl)
    {
            if (target.MaxHP > 5)
            target.MaxHP -= 5 + lvl;
            target.TakeDamage(5+lvl);
    }
}
