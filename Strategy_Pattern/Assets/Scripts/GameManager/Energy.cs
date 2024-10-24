using TMPro;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] public int currentEnergy = 0;
    [SerializeField] private int startEnergy = 3;

    void Start()
    {
        ResetEnergy();
        TurnSystem.TurnEnded.AddListener(ResetEnergy);
    }
    public void ResetEnergy()
    {
        currentEnergy = startEnergy;
        UpdateEnergyUI();
    }

    public void UpdateEnergyUI()
    {
        energyText.text = "Energy: " + currentEnergy;
        Debug.Log("Current Energy: " + currentEnergy);
    }
    public bool SpendEnergy(int energyCost)
    {
        if (energyCost > currentEnergy)
        {
            Debug.Log("Not enough energy");
            return false;
        }

        currentEnergy -= energyCost;
        UpdateEnergyUI();
        Debug.Log("Spent " + energyCost + " energy.");
        return true;
    }

    public int CurrentEnergy
    {
        get { return currentEnergy; }
    }
}
