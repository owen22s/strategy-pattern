using UnityEngine;

public class Card : MonoBehaviour, ICard
{
    public int CardEnergyCost;

    void Update()
    {

    }
    public void PlayCard()
    {
        Destroy(gameObject);
    }

}
