using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CurrentLevel : MonoBehaviour
{
    public static Action<int> OnNewLevel;
    private static Action OnLevelComplete;
    [SerializeField] private LevelSettings _levelSettings;
    [SerializeField] private LevelGenerator _levelGenerator;
    private LevelData _currentLevelData;
    private List<EnemyBlock> _enemyBlocks;

    private void Awake()
    {
        //initialization
        _currentLevelData = _levelSettings.GetCurrentLevel();
        InstantiateLevel(_currentLevelData);
    }

    private void OnEnable() => OnLevelComplete += HandleLevelComplete;
    private void OnDisable() => OnLevelComplete -= HandleLevelComplete;

    private void InstantiateLevel(LevelData currentLevelData)
    {
        GameObject currentLevel = _levelGenerator.GenerateLevel(currentLevelData);
        _enemyBlocks = currentLevel.GetComponentsInChildren<EnemyBlock>().ToList();
        if (null != _enemyBlocks)
        {
            foreach (EnemyBlock enemyBlock in _enemyBlocks)
                enemyBlock.OnEnemyBlockDestroy += HandleEnemyBlockDestroy;
        }
        OnNewLevel?.Invoke(_levelSettings.CurrentLevelNumber);
    }

    private void HandleLevelComplete()
    {
        _currentLevelData = _levelSettings.GetNextLevel();
        InstantiateLevel(_currentLevelData);
    }
    private void HandleEnemyBlockDestroy(EnemyBlock enemyBlock)
    {
        //unsubscribe from event
        enemyBlock.OnEnemyBlockDestroy -= HandleEnemyBlockDestroy;
        //remove from list
        _enemyBlocks.Remove(enemyBlock);
        //check if level complete (all blocks destroyed)
        if(_enemyBlocks.Count == 0)
        {
            OnLevelComplete?.Invoke();
        }
    }

}
