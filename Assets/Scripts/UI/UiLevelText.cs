using UnityEngine;
using TMPro;

public class UiLevelText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private void OnEnable() => CurrentLevel.OnNewLevel += HandleNewLevel;
    private void OnDisable() => CurrentLevel.OnNewLevel -= HandleNewLevel;

    private void Awake()
    {
        if (null == _text)
            _text = GetComponent<TextMeshProUGUI>();
    }

    private void HandleNewLevel(int number) => _text.text = "Level " + number;
}
