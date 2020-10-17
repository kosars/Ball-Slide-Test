using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/LevelSettings", fileName = "New Level Settings")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private List<LevelData> _levels;
    private int _prevLevel = 0;
    public LevelData GetFirstLevel() 
    {
        _prevLevel = 0;
        return _levels[0]; 
    }

    public LevelData GetNextLevel() 
    {
        _prevLevel++;
        //return random level if all levels is complete
        if (_prevLevel >= _levels.Count)
            return GetRandomLevel();
        else 
            return _levels[_prevLevel];
    }

    public LevelData GetCurrentLevel()
    {
        //return first level current level is not valid
        if (_prevLevel >= _levels.Count)
            return GetFirstLevel();
        return _levels[_prevLevel];
    }

    public LevelData GetRandomLevel() 
    {
        int _prevLevel = Random.Range(0, _levels.Count);
        return _levels[_prevLevel]; 
    }

    public int CurrentLevelNumber { get => _prevLevel; }

}
