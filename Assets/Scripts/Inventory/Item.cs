using UnityEngine;

namespace ProjectFish.InventorySystem
{
    public class Item : MonoBehaviour
    {
        /// <summary>
        /// Id of item
        /// </summary>
        [field: SerializeField] public int Id { get; protected set; }

        /// <summary>
        /// Item name
        /// </summary>
        [field: SerializeField] public string Name { get; protected set; }

        /// <summary>
        /// Inventory belongs to
        /// </summary>
        private Inventory inventory;



        /// <summary>
        /// Method for world interaction
        /// </summary>
        /// <param name="inventory"></param>
        public virtual void Pickup(Inventory inventory)
        {
            Debug.Log($"Pickup {gameObject.name}");
            this.inventory = inventory;
            inventory.AddItem(this);
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Method for inventory interaction
        /// </summary>
        public virtual void Use()
        {
            Debug.Log($"Use {gameObject.name}");
        }

        /// <summary>
        /// Method for removing from inventory
        /// </summary>
        public virtual void Drop()
        {
            Debug.Log($"Drop {gameObject.name}");
            gameObject.SetActive(true);

            Transform eyes = inventory.Eyes;
            if (eyes != null)
            {
                RaycastHit hit;

                if (Physics.Raycast(eyes.position, eyes.forward, out hit, inventory.MaxDistance))
                {
                    transform.position = hit.point;
                    transform.rotation = Quaternion.identity;
                }
                else
                {
                    transform.position = eyes.position + eyes.forward * inventory.MaxDistance;
                    transform.rotation = Quaternion.identity;
                }
            }
        }
    }
}