using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private GameObject _level;
    public GameObject GenerateLevel(LevelData levelData)
    {
        if(null != _level)
            Destroy(_level); //cleanup prev level if exist
        if (null == levelData)
            return null;
        _level = Instantiate(levelData.LevelPrefab);
        return _level;
    }
}
