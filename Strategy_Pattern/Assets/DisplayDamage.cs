using TMPro;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    private Card damageComponent;
    private TextMeshProUGUI DamageUIText;
    void Start()
    {
        damageComponent = GetComponent<Card>();
        DamageUIText = GetComponentInChildren<TextMeshProUGUI>();
        if (damageComponent != null && DamageUIText != null)
        {
            DamageUIText.text = "Damage: " + damageComponent.damageAmount.ToString();
        }
    }
    void Update()
    {
        if (damageComponent != null && DamageUIText != null)
        {
            DamageUIText.text = "Damage: " + damageComponent.damageAmount.ToString();
        }
    }
}
