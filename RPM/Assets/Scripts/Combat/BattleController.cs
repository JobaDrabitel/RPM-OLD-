using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private BattleHUD _battleHUD;
    [SerializeField] private BattleContainer _battleContainer;
    private Unit _playerUnit;
    private GameObject _playerClone;
    private Unit _enemyUnit;
    private GameObject _enemyClone;
    private void Start()
    {
        _battleContainer.state = BattleContainer.BattleState.START;
        SetupBattle();
    }
    public void SetupBattle()
    {
        SpawnUnit();
        _playerUnit = _playerClone.GetComponent<Unit>();
        _enemyClone = Instantiate(_battleContainer.enemyPrefab, _battleContainer.enemySpawnPoint);
        _enemyUnit = _enemyClone.GetComponent<Unit>();
        _battleContainer.state = BattleContainer.BattleState.PLAYERTURN;
        _battleHUD.SetupBattleHUD(_playerUnit, _enemyUnit);
        Debug.Log(_enemyUnit.Name);
        Debug.Log(_playerUnit.Name);
    }
    private void UseSkill(int index, Unit unit, Unit target)
    {
        Skill skill = unit.GetSkill(index);
        skill.Target = target;
        skill.AddEffect();
        _battleHUD.HPBarValueChange(_playerUnit, _enemyUnit);
        Debug.Log(target.CurrentHP);
        ChangeTurn();
        if (_battleContainer.state == BattleContainer.BattleState.ENEMYTURN)
            StartCoroutine(EnemyAction());
    }

    public void OnSkill3ButtonClick()
    {
        if (_battleContainer.state == BattleContainer.BattleState.PLAYERTURN)
        {
            StartCoroutine(PlayerAction(2, _enemyUnit));
        }
    }
    public void OnSkill2ButtonClick()
    {
        if (_battleContainer.state == BattleContainer.BattleState.PLAYERTURN)
        {
            StartCoroutine(PlayerAction(1, _enemyUnit));
        }
    }
    public void OnSkill1ButtonClick()
    {
        if (_battleContainer.state == BattleContainer.BattleState.PLAYERTURN)
        {
            StartCoroutine(PlayerAction(0, _enemyUnit));
        }
    }
    public void ChangeTurn()
    {
        if (_battleContainer.state == BattleContainer.BattleState.PLAYERTURN)
        {
            _battleContainer.state = BattleContainer.BattleState.ENEMYTURN;
            _enemyUnit.State = Unit.StateMachine.TURN;
            _enemyUnit.GetCurrentEffects();
            _playerUnit.State = Unit.StateMachine.WAIT;
            _battleContainer.turn++;
        }
        else
        {
            _battleContainer.state = BattleContainer.BattleState.PLAYERTURN;
            _playerUnit.GetCurrentEffects();
            _enemyUnit.State = Unit.StateMachine.WAIT;
            _playerUnit.State = Unit.StateMachine.TURN;
            _battleContainer.turn++;
        }
    }
    public IEnumerator EnemyAction()
    {
        yield return new WaitForSeconds(1f);
        if (_enemyUnit.State == Unit.StateMachine.TURN)
            UseSkill(0, _enemyUnit, _playerUnit);
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator PlayerAction(int index, Unit target)
    {
        yield return new WaitForSeconds(1f);
        UseSkill(index, _playerUnit, target);
        yield return new WaitForSeconds(1f);
    }
    public void SpawnUnit()
    {
        for (int i = 0; i < 8; i++)
        {
            if (i <= 3)
                Instantiate(_battleContainer.prefabs[i], _battleContainer.playerSpawnPoint);
            else
                Instantiate(_battleContainer.prefabs[i], _battleContainer.enemySpawnPoint);
            _battleContainer.units[i] = _battleContainer.prefabs[i].GetComponent<Unit>();
        }
    }
    public void SetTurnsOrder()
    {
        Unit temp;
        for (int write = 0; write < _battleContainer.units.Length; write++)
        {
            for (int sort = 0; sort < _battleContainer.units.Length-1; sort++)
            {
                if (_battleContainer.units[sort].Initiative > _battleContainer.units[sort + 1].Initiative)
                {
                    temp = _battleContainer.units[sort + 1];
                    _battleContainer.units[sort + 1].Initiative = _battleContainer.units[sort].Initiative;
                    _battleContainer.units[sort] = temp;
                }
            }
        }
    }
}

