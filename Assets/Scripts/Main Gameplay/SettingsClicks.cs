using UnityEngine;

[CreateAssetMenu(fileName = "Clicks", menuName = "Settings clicks/Clicks")]
public class SettingsClicks : ScriptableObject
{
    [Min(1)]
    public int BaseClick = 1;

    [Min(1)]
    public int MultiplyClick = 1;

    public int Click(int additionalAmount = 0)
    {
        int tap = 0;

        return tap = (BaseClick * MultiplyClick) + additionalAmount;
    }
}