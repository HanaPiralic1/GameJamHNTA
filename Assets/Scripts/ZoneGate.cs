using UnityEngine;

public class ZoneGate : MonoBehaviour
{
    public string[] requiredItems;
    public GameObject blockerObject; // Optional: assign invisible wall or gate

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bool hasAll = true;

            foreach (string item in requiredItems)
            {
                if (!InventoryManager.HasItem(item)) // Assumes static inventory manager
                {
                    hasAll = false;
                    break;
                }
            }

            if (hasAll)
            {
                if (blockerObject != null) blockerObject.SetActive(false);
                // Optionally load new scene here
            }
            else
            {
                Debug.Log("You must collect all required items to enter.");
            }
        }
    }
}
