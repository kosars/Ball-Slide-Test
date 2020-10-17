using UnityEngine;

[CreateAssetMenu(menuName = "GameData/EnemySettings", fileName = "New Enemy Settings")]

public class EnemySettings : ScriptableObject
{
    [SerializeField] private float _speed = .5f;
    [SerializeField] private float _speedUpPerLevel = .5f;

    public float Speed
    {
        get => _speed;
        private set => _speed = value;
    }

    public float SpeedUpPerLevel
    {
        get => _speedUpPerLevel;
        private set => _speedUpPerLevel = value;
    }

}
