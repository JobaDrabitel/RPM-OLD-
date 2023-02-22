using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleContainer : MonoBehaviour
{
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSE }
    public BattleState state;
    public Transform playerSpawnPoint;
    public Transform enemySpawnPoint;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
}
