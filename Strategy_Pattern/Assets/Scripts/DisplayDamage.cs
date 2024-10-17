using TMPro;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    private Card damageComponent;
    private TextMeshProUGUI DamageUIText;
    private TextMeshProUGUI EnergyText;

    void Start()
    {
        damageComponent = GetComponent<Card>();

        // Get all TextMeshProUGUI components in children
        TextMeshProUGUI[] textComponents = GetComponentsInChildren<TextMeshProUGUI>();

        // Assuming the first component is for Damage and the second is for Energy
        if (textComponents.Length > 0)
        {
            DamageUIText = textComponents[0];
        }
        if (textComponents.Length > 1)
        {
            EnergyText = textComponents[1];
        }

        // Set the text for DamageUIText if the components are not null
        if (damageComponent != null && DamageUIText != null)
        {
            DamageUIText.text = "Damage: " + damageComponent.damageAmount.ToString();
        }

        // Set the text for EnergyText if the components are not null
        if (damageComponent != null && EnergyText != null)
        {
            EnergyText.text = damageComponent.CardEnergyCost.ToString();
        }
    }
}
