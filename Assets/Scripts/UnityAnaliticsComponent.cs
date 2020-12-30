using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class UnityAnaliticsComponent : MonoBehaviour
{
    public void OnStartGame(int levelId)
    {
        Analytics.CustomEvent("Player Dead", new Dictionary<string, object>
        {
            {"Level", levelId },
        });
        //Debug.Log(analyticsResult);
    }
}
