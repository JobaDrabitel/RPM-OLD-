
public class WinDefiner
{
   public bool IsPlayerWin(Unit[] units)
    {
        int deadUnits = 0;
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i].State == Unit.StateMachine.DEAD)
                deadUnits++;
        }
        if (deadUnits == 4)
            return true;
    return false;
    }
    public bool IsPlayerLose(Unit[] units)
    {
        int deadUnits = 0;
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i].State == Unit.StateMachine.DEAD)
                deadUnits++;
        }
        if (deadUnits == 4)
            return true;
        else
    return false;
    }
}

