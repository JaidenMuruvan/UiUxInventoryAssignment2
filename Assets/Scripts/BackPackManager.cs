using UnityEngine;
using System.Collections.Generic;

public class BackPackManager : MonoBehaviour
{
    public List<GameObject> backpackSlots; // List to store available backpack slots
    public List<GameObject> chestSlots; // List to store available chest slots
    public List<GameObject> backpackItems; // List to store items in the backpack

    public void AddItemToBackpack(GameObject item)
    {
        if (IsFlexible(item))
        {
            // Find the first available slot in the backpack and add the item to it
            GameObject backpackSlot = FindAvailableSlot(backpackSlots);
            if (backpackSlot != null)
            {
                item.transform.position = backpackSlot.transform.position;
                backpackItems.Add(item);
            }
            else
            {
                Debug.Log("No available slots in the backpack.");
            }
        }
        else
        {
            // Place the item in its designated slot
            GameObject designatedSlot = FindDesignatedSlotForItem(item);
            if (designatedSlot != null)
            {
                item.transform.position = designatedSlot.transform.position;
                backpackItems.Add(item);
            }
            else
            {
                Debug.Log("No designated slot available for this item.");
            }
        }
    }

    public void MoveItemToChest(GameObject item)
    {
        // Find the first available slot in the chest and add the item to it
        GameObject chestSlot = FindAvailableSlot(chestSlots);
        if (chestSlot != null)
        {
            item.transform.position = chestSlot.transform.position;
        }
        else
        {
            Debug.Log("No available slots in the chest.");
        }
    }

    private bool IsFlexible(GameObject item)
    {
        // Implement logic to check if the item is flexible
        // For example, you could check if the item has a certain tag or component
        return true; // Placeholder logic
    }

    private GameObject FindAvailableSlot(List<GameObject> slots)
    {
        foreach (GameObject slot in slots)
        {
            if (!IsSlotOccupied(slot))
            {
                return slot;
            }
        }
        return null;
    }

    private GameObject FindDesignatedSlotForItem(GameObject item)
    {
        // Implement logic to find the designated slot for the item
        // This could involve checking specific criteria or properties of the item
        // For demonstration purposes, let's assume each item knows its designated slot
        return item.transform.parent.gameObject; // Placeholder logic
    }

    private bool IsSlotOccupied(GameObject slot)
    {
        // Implement logic to check if the slot is occupied by any item
        // You might need to iterate through the items in the backpack and check their positions
        // For demonstration purposes, let's assume each item has a collider component
        Collider2D[] colliders = Physics2D.OverlapPointAll(slot.transform.position);
        return colliders.Length > 0;
    }
}
