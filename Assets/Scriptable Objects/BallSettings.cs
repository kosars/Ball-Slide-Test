using UnityEngine;

[CreateAssetMenu(menuName = "GameData/BallSettings", fileName = "New Ball Settings")]
public class BallSettings : ScriptableObject
{
    [SerializeField] private float _launchSpeed = 100f;

    public float LaunchSpeed 
    { 
        get => _launchSpeed; 
        private set => _launchSpeed = value; 
    }
}
