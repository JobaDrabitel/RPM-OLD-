using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private BattleContainer _battleContainer;
    private Unit _playerUnit;
    private GameObject _player;
    private Unit _enemyUnit;
    private void Start()
    {
       _battleContainer.state = BattleContainer.BattleState.START;
        SetupBattle();
    }
    public void SetupBattle()
    {
         _player = Instantiate(_battleContainer.playerPrefab, _battleContainer.playerSpawnPoint);
        _playerUnit = _player.GetComponent<Unit>();
        GameObject enemy = Instantiate(_battleContainer.enemyPrefab, _battleContainer.enemySpawnPoint);
        _enemyUnit = enemy.GetComponent<Unit>();
    }
  
}

