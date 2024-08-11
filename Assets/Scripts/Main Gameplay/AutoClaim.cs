using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class AutoClaim : MonoBehaviour
{
    [Space(5)]
    [Min(1)]
    [SerializeField]
    private int _scoreClaim;

    public int ScoreClaim => _scoreClaim;

    [Min(0.001f)]
    [SerializeField]
    public float _timeClaim = 30;

    private WaitForSeconds _timeClaimW;

    private Score _score;

    public UnityEvent OnClaimed;

    [Inject]
    public void Construct(Score score)
    {
        _score = score;
    }

    private void Start()
    {
        _timeClaimW = new WaitForSeconds(_timeClaim);

        StartCoroutine(Claim());
    }

    private IEnumerator Claim()
    {
        yield return _timeClaimW;

        _score.Increase(_scoreClaim);

        OnClaimed?.Invoke();

        StartCoroutine(Claim());
    }

    public int PercentClaim(int percent)
    {
        return _scoreClaim / percent;
    }
}