using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    private Ball _ball;
    private void Awake()
    {
        SpawnBall();
    }
    private void SpawnBall()
    {
        if(_ball != null)
            _ball.OnBallDestroy -= SpawnBall;
        GameObject ball = Instantiate(_ballPrefab);
        _ball = ball.GetComponent<Ball>();
        _ball.OnBallDestroy += SpawnBall;
    }
}
