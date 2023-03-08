using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private BattleHUD _battleHUD;
    [SerializeField] private BattleContainer _battleContainer;
    private Unit _skillTarget;
    private Unit _currentUnit;
    private bool _isSkillUsed = false;
    private int _currentUnitNumber = 0;
    private Unit[] _sortedUnits = new Unit[8];
    private Unit[] _playerUnits = new Unit[4];
    private Unit[] _enemyUnits = new Unit[4];
    private void Start()
    {
        PrepareUnitsForBattle();
        SpawnUnit();
        ChangeTurn();
        _battleHUD.SetupBattleHUD(_battleContainer.units);
        if (!_currentUnit.IsPlayable)
           StartCoroutine(EnemyAction());
    }
    private void PrepareUnitsForBattle()
    {
        UnitArraysPrepare arraysPrepare = new UnitArraysPrepare();
        _sortedUnits = arraysPrepare.ArrayByInitiativeSort(_battleContainer.units);
        _playerUnits = arraysPrepare.SetUnitsBySide(_battleContainer.units, true);
        _enemyUnits = arraysPrepare.SetUnitsBySide(_battleContainer.units, false);
    }
    private void CurrentUnitAction(int index, Unit unit, Unit target)
    {
        _battleHUD.HPBarValueChange(_battleContainer.units);
        _battleHUD.DisplayUnitDescription(target);
        _currentUnit.UseSkill(index, unit, target);
        _skillTarget = null;
        _isSkillUsed = false;
        ChangeTurn();
        if (!_currentUnit.IsPlayable)
            StartCoroutine(EnemyAction());
    }

    public void OnSkill3ButtonClick()
    {
        if (_currentUnit.IsPlayable)
        {
            Skill skill = _currentUnit.GetSkill(2);
            _battleHUD.DisplaySkillDescriprion(skill);
            _isSkillUsed = true;
            StartCoroutine(PlayerAction(2));
        }
    }
    public void OnSkill2ButtonClick()
    {
        if (_currentUnit.IsPlayable)
        {
            Skill skill = _currentUnit.GetSkill(1);
            _battleHUD.DisplaySkillDescriprion(skill);
            _isSkillUsed = true;
            StartCoroutine(PlayerAction(1));
        }
    }
    public void OnSkill1ButtonClick()
    {
        if (_currentUnit.IsPlayable)
        {
            Skill skill = _currentUnit.GetSkill(0);
            _battleHUD.DisplaySkillDescriprion(skill);
            _isSkillUsed = true;
            StartCoroutine(PlayerAction(0));
        }
    }
    public void ChangeTurn()
    {
        _currentUnit = _sortedUnits[_currentUnitNumber];
        if (_sortedUnits[_currentUnitNumber].State != Unit.StateMachine.DEAD)
        {
            if (_sortedUnits[_currentUnitNumber].IsPlayable)
                Debug.Log("Ваш ход!");
            else
                Debug.Log("Ход врага!");
            _sortedUnits[_currentUnitNumber].State = Unit.StateMachine.TURN;
            string log = $"Ходит {_currentUnit.Name} под номером {_currentUnitNumber+1}";
            Debug.Log(log);
            _currentUnitNumber++;
        }
        else
        {
            string log = $"Юнит {_currentUnit.Name} под номером {_currentUnitNumber+1} не может ходить так как умерчик!";
            Debug.Log(log);
            _currentUnitNumber++;
            ChangeTurn();
        }
        if (_currentUnitNumber >= _sortedUnits.Length)
            _currentUnitNumber = 0;
    }
    public IEnumerator EnemyAction()
    {
        int target = 3;
        yield return new WaitForSeconds(2f);
        if (_battleContainer.units[target].State == Unit.StateMachine.DEAD)
            target--;
        CurrentUnitAction(0, _currentUnit, _battleContainer.units[target]);
        yield return new WaitForSeconds(2f);
    }
    public IEnumerator PlayerAction(int index)
    {
        yield return new WaitUntil(() => _skillTarget != null);
        CurrentUnitAction(index, _currentUnit, _skillTarget);
        yield return new WaitForSeconds(1f);

    }
    public void SpawnUnit()
    {
        for (int i = 0; i < 8; i++)
        {
            if (i <= 3)
            {
                GameObject playerClone = Instantiate(_battleContainer.prefabs[i], _battleContainer.spawnpoints[i]);
                playerClone.GetComponent<Unit>().IsPlayable = true;
                _battleContainer.units[i] = playerClone.GetComponent<Unit>();
            }
            else
            {
                GameObject enemyClone = Instantiate(_battleContainer.prefabs[i], _battleContainer.spawnpoints[i]);
                enemyClone.GetComponent<Unit>().IsPlayable = false;
                _battleContainer.units[i] = enemyClone.GetComponent<Unit>();
            }
        }
    }
    public void GetTarget(int index)
    {
        if (_isSkillUsed && _battleContainer.units[index].State!=Unit.StateMachine.DEAD)
            _skillTarget = _battleContainer.units[index];
            _battleHUD.DisplayUnitDescription(_battleContainer.units[index]);
    }
}

