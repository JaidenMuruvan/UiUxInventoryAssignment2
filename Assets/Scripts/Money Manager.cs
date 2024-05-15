using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int Money { get; private set; } = 100; // Current money amount
    public TextMeshProUGUI moneyText; 

    void Start()
    {
        
        UpdateMoneyUI(); 
    }

    // Method to add money
    public void AddMoney(int amount)
    {
        Money += amount;
        UpdateMoneyUI(); 
    }

    // Method to subtract money
    public void SubtractMoney(int amount)
    {
        Money -= amount;
        UpdateMoneyUI(); 
    }

    // Update UI to display current money amount
    public void UpdateMoneyUI()
    {
        if (moneyText != null)
        {
            moneyText.text = "$" + Money; 
        }
    }
}
