using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySettings _enemySettings;
    [SerializeField] private Rigidbody _rigidbody;

    private Transform _trackableBall;
    private float _enemySpeed;
    private float _enemySpeedUpPerLevel;

    private void OnEnable() => CurrentLevel.OnNewLevel += LevelUp;
    private void OnDisable() => CurrentLevel.OnNewLevel -= LevelUp;

    private void Awake()
    {
        _enemySpeed = _enemySettings.Speed;
        _enemySpeedUpPerLevel = _enemySettings.SpeedUpPerLevel;
    }

    private void Start()=>FindBall();

    private void Update()
    {
        if (_trackableBall == null)
            FindBall();
        Vector3 movementDirection = GetDirection();
        Move(movementDirection);
    }


    private void FindBall() => _trackableBall = FindObjectOfType<Ball>().transform;

    //increase the level speed each level
    private void LevelUp(int number) => _enemySpeed = _enemySettings.Speed + number * _enemySpeedUpPerLevel;

    private void Move(Vector3 direction) => _rigidbody.velocity = direction*_enemySpeed;

    private Vector3 GetDirection()
    {
        Vector3 direction = _trackableBall.position.x > transform.position.x ? Vector3.right : Vector3.left;
        return direction;
    }
}
