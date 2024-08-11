using UnityEngine;
using NTC.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform _positionSpawn;

    [SerializeField]
    private Vector3 _maxOffset;

    private int _lastValue = 0;

    public void SetLastValue(int value)
    {
        _lastValue = value;
    }

    public void Spawn(AnimatedText animatedText)
    {
        Vector3 newRandomPosition = new Vector3(
            Random.Range(_maxOffset.x, -_maxOffset.x),
            Random.Range(_maxOffset.y, -_maxOffset.y),
            Random.Range(_maxOffset.z, -_maxOffset.z));

        AnimatedText newAnimatedText = NightPool.Spawn(animatedText, _positionSpawn);

        newAnimatedText.gameObject.transform.localPosition = newRandomPosition;

        newAnimatedText.Init(_lastValue);
    }
}