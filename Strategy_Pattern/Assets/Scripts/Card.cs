using UnityEngine;

public class Card : MonoBehaviour, ICard
{
    public int CardEnergyCost;
    public float damageAmount = 10f;


    public void PlayCard()
    {
        Destroy(gameObject);
    }

}
