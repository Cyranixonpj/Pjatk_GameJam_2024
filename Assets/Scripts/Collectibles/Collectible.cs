using UnityEngine;

namespace Collectibles
{
    public class Collectible : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var playerInventory = other.GetComponent<PlayerInventory>();

                if (playerInventory != null)
                {
                    playerInventory.AddCoin();
                    Destroy(gameObject);
                }
                else
                {
                    Debug.LogError("PlayerInventory not found! Collection failed.");
                }
            }
        }
    }
}
