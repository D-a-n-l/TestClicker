using UnityEngine;
using UnityEngine.Events;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class Clickable : MonoBehaviour
{
    [SerializeField]
    private SettingsClicks _clicks;

    [SerializeField]
    private AutoClaim _autoClaim;

    private Energy _energy;

    public UnityEvent OnDown;

    public UnityEvent<int> OnDownInt;

    [Inject]
    public void Construct(Energy energy)
    {
        _energy = energy;
    }

    public void OnMouseDown()
    {
        if (_energy.Current == 0)
            return;

        _clicks.Click(_autoClaim.PercentClaim(10));

        OnDown?.Invoke();

        OnDownInt?.Invoke(_autoClaim.PercentClaim(10));
    }
}