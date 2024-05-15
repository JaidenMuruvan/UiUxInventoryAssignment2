using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    public MoneyManager moneyManager;

    public GameObject[] items; // Array to store items
    public GameObject[] slots; // Array to store slots
    public Dictionary<string, int> itemPrices = new Dictionary<string, int>(); // Dictionary stores prices

    private Vector3[] initialPositions; // Array to store initial positions of items

    void Start()
    {
        itemPrices.Add("Apple", 5);
        itemPrices.Add("Bread", 10);
        itemPrices.Add("Cheese", 3);
        itemPrices.Add("Meat", 2);
        itemPrices.Add("Fish", 15);
        itemPrices.Add("Clover", 6);
        itemPrices.Add("Scroll", 7);
        itemPrices.Add("Journal", 4);
        itemPrices.Add("Potion", 8);

        // Initialize the array to store initial positions
        initialPositions = new Vector3[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            initialPositions[i] = items[i].transform.position;
        }
    }

    public void BuyItem(int itemIndex)
    {
        string itemName = items[itemIndex].name;

        if (moneyManager.Money >= itemPrices[itemName])
        {
            // Find an available slot
            int availableSlotIndex = FindAvailableSlot();
            if (availableSlotIndex != -1)
            {
                // Set the item's position to the available slot's position
                items[itemIndex].transform.position = slots[availableSlotIndex].transform.position;
                moneyManager.SubtractMoney(itemPrices[itemName]);
            }
            else
            {
                Debug.Log("No available slot to store " + itemName + ".");
            }
        }
        else
        {
            Debug.Log("Insufficient funds to buy " + itemName + ".");
        }
    }

    private int FindAvailableSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            // Check if the slot contains an item with the "Item" tag
            Collider2D[] colliders = Physics2D.OverlapCircleAll(slots[i].transform.position, 0.1f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Item"))
                {
                    // Slot is not available, move to the next slot
                    break;
                }
                // Slot is available
                return i;
            }
        }
        return -1; // No available slot found
    }

    public void SellItem()
    {
        bool itemSold = false; // Flag to track if an item has been sold

        // Iterate through all slots
        for (int i = 0; i < slots.Length; i++)
        {
            // Check if the slot contains an item
            Collider2D[] colliders = Physics2D.OverlapCircleAll(slots[i].transform.position, 0.1f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Item"))
                {
                    // Get the item's index in the items array
                    int itemIndex = System.Array.IndexOf(items, collider.gameObject);

                    // If the item index is valid and an item has not been sold yet, sell the item
                    if (itemIndex != -1 && !itemSold)
                    {
                        string itemName = items[itemIndex].name;

                        // Reset the item's position to its initial position
                        items[itemIndex].transform.position = initialPositions[itemIndex];

                        // Add money to the money manager
                        moneyManager.AddMoney(itemPrices[itemName]);

                        // Set the itemSold flag to true to indicate that an item has been sold
                        itemSold = true;
                    }
                }
            }

            // If an item has been sold, exit the loop
            if (itemSold)
                break;
        }
    }

}
