using UnityEngine;
using UnityEngine.Events;

public class TurnSystem : MonoBehaviour
{
    public static UnityEvent TurnEnded = new();

    public void EndTurn()
    {
        TurnEnded?.Invoke();
    }
}
