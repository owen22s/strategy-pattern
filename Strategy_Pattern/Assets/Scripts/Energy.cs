using TMPro;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI energyText;  // UI Text element to display energy
    [SerializeField] public int currentEnergy = 0;       // Current energy the player has
    [SerializeField] private int startEnergy = 3;         // Starting energy at the beginning of the game/turn

    void Start()
    {
        ResetEnergy(); // Initialize the energy when the game starts
    }

    void Update()
    {
        // Example input check for spending energy (e.g., cost of 1)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpendEnergy(1); // Spend energy when spacebar is pressed
            Debug.Log("Pressed spacebar");
        }
    }

    // Method to reset energy to the starting value
    public void ResetEnergy()
    {
        currentEnergy = startEnergy;
        UpdateEnergyUI();
        Debug.Log("Energy reset to: " + currentEnergy);
    }

    // Method to update the energy UI
    public void UpdateEnergyUI()
    {
        energyText.text = "Energy: " + currentEnergy;
        Debug.Log("Current Energy: " + currentEnergy);
    }

    // Method to spend energy
    public bool SpendEnergy(int energyCost)
    {
        if (energyCost > currentEnergy)
        {
            Debug.Log("Not enough energy");
            return false; // Return false if energy cost is not met
        }

        currentEnergy -= energyCost; // Deduct the energy cost
        UpdateEnergyUI();
        Debug.Log("Spent " + energyCost + " energy.");
        return true; // Return true if energy was successfully spent
    }

    // Method to add energy
    public void AddEnergy(int amount)
    {
        currentEnergy += amount;
        UpdateEnergyUI();
        Debug.Log("Added " + amount + " energy.");
    }

    // Property to access current energy externally (read-only)
    public int CurrentEnergy
    {
        get { return currentEnergy; }
    }
}
