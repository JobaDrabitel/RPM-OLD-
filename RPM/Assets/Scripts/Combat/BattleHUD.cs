
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] BattleContainer _battleContainer;
    [SerializeField] Slider _playerHPBar;
    [SerializeField] Slider _enemyHPBar;
    [SerializeField] Text _description;
    public void SetupBattleHUD(Unit player, Unit enemy)
    {
        _playerHPBar.maxValue = player.MaxHP;
        _enemyHPBar.maxValue = enemy.MaxHP;
        _playerHPBar.value = player.CurrentHP;
        _enemyHPBar.value = enemy.CurrentHP;
        _description.text = "Твоя мама микроабобус";
    }
    public void HPBarValueChange(Unit player, Unit enemy)
    {
            _playerHPBar.value = player.CurrentHP;
            _enemyHPBar.value = enemy.CurrentHP;
    }

}
