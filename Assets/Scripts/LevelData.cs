using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    [SerializeField] private GameObject _levelPrefab;

    public GameObject LevelPrefab
    {
        get => _levelPrefab;
        private set => _levelPrefab = value;
    }
}
