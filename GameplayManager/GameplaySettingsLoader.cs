using UnityEngine;

public class GameplaySettingsLoader : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _spinSpeed;
    [SerializeField] private float _force;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _attackRadius;
    [SerializeField] private int _playerHP;

    [Header("Enemy Settings")]
    [SerializeField] private float _enemyMoveSpeed;
    [SerializeField] private float _enemyAttackRadius;

    void Awake()
    {
        GameplaySettings.moveSpeed = _moveSpeed;
        GameplaySettings.enemyMoveSpeed = _enemyMoveSpeed;
        GameplaySettings.spinSpeed = _spinSpeed;
        GameplaySettings.enemyAttackRadius = _enemyAttackRadius;
        GameplaySettings.force = _force;
        GameplaySettings.rotationSpeed = _rotationSpeed;
        GameplaySettings.attackRadius = _attackRadius;
        GameplaySettings.playerHP = _playerHP;
    }
}
