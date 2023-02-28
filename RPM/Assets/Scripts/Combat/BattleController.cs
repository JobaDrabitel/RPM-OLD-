using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
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
        _playerClone = Instantiate(_battleContainer.playerPrefab, _battleContainer.playerSpawnPoint);
        _playerUnit = _playerClone.GetComponent<Unit>();
        _enemyClone = Instantiate(_battleContainer.enemyPrefab, _battleContainer.enemySpawnPoint);
        _enemyUnit = _enemyClone.GetComponent<Unit>();
        _battleContainer.state = BattleContainer.BattleState.PLAYERTURN;
        Debug.Log(_enemyUnit.Name);
        Debug.Log(_playerUnit.Name);
    }
    private void CastSkill(int index, Unit unit, Unit target)
    {
        Skill skill = unit.GetSkill(index);
        skill.Target = target;
        skill.CastEffect();
        Debug.Log(target.ÑurrentHP);
        ChangeTurn();
        if (_battleContainer.state == BattleContainer.BattleState.ENEMYTURN)
            EnemyAction();
    }
    
    public void OnSkill3ButtonClick()
    {
        if (_battleContainer.state == BattleContainer.BattleState.PLAYERTURN)
        {
            CastSkill(2, _playerUnit, _enemyUnit);
        }
    }
    public void OnSkill2ButtonClick()
    {
        if (_battleContainer.state == BattleContainer.BattleState.PLAYERTURN)
        {
            CastSkill(1, _playerUnit, _enemyUnit);
        }
    }
    public void OnSkill1ButtonClick()
    {
        if (_battleContainer.state == BattleContainer.BattleState.PLAYERTURN)
        {
            CastSkill(0, _playerUnit, _enemyUnit);
        }
    }
    public void ChangeTurn()
    {
        if (_battleContainer.state == BattleContainer.BattleState.PLAYERTURN)
        {
            _battleContainer.state = BattleContainer.BattleState.ENEMYTURN;
            _enemyUnit.State = Unit.StateMachine.TURN;
            _playerUnit.State = Unit.StateMachine.WAIT;
        }
        else
        {
            _battleContainer.state = BattleContainer.BattleState.PLAYERTURN;
            _enemyUnit.State = Unit.StateMachine.WAIT;
            _playerUnit.State = Unit.StateMachine.TURN;
        }
    }
    public void EnemyAction()
    {
        if (_enemyUnit.State == Unit.StateMachine.TURN)
            CastSkill(0, _enemyUnit, _playerUnit);
        ChangeTurn();

    }
}

