using System;
using UnityEngine;

public class EnemyBlock : MonoBehaviour
{
    public event Action<EnemyBlock> OnEnemyBlockDestroy;
    public void DestroyBlock()
    {
        OnEnemyBlockDestroy?.Invoke(this);
        Destroy(gameObject);
    }
}
