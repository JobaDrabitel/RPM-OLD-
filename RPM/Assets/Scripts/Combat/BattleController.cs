using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private BattleContainer _battleContainer;
    private Ninja _playerUnit;
    private GameObject _playerClone;
    private Rat _enemyUnit;
    private GameObject _enemyClone;
    private void Start()
    {
       _battleContainer.state = BattleContainer.BattleState.START;
        SetupBattle();
    }
    public void SetupBattle()
    {
        _playerClone = Instantiate(_battleContainer.playerPrefab, _battleContainer.playerSpawnPoint);
        _playerUnit = _playerClone.GetComponent<Ninja>();
        _enemyClone = Instantiate(_battleContainer.enemyPrefab, _battleContainer.enemySpawnPoint);
        _enemyUnit = _enemyClone.GetComponent<Rat>();
        _battleContainer.state = BattleContainer.BattleState.PLAYERTURN;
        Debug.Log(_enemyUnit._name);
        Debug.Log(_playerUnit._name);
    }
    private void PlayerAction()
    {
        _playerUnit.Atack(_playerUnit._damage, _enemyUnit);
        Debug.Log(_enemyUnit._currentHP);
    }
    
    public void OnAtackButtonClick()
    {
        PlayerAction();
    }
}

