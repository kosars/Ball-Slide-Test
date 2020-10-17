using UnityEngine;

[CreateAssetMenu(menuName = "GameData/PlayerSettings", fileName = "New Player Settings")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] private float _speedModifier = 5f;

    public float SpeedModifier
    {
        get => _speedModifier;
        private set => _speedModifier = value;
    }

}
