using System.Collections.Generic;
using UnityEngine;

namespace ProjectFish.InventorySystem
{
    public class Inventory
    {
        /// <summary>
        /// Owner of inventory
        /// </summary>
        public GameObject Owner { get; private set; }
        /// <summary>
        /// Eyes for raycast and using
        /// </summary>
        public Transform Eyes { get; private set; }

        /// <summary>
        /// MaxDistance of use
        /// </summary>
        [field: SerializeField] public float MaxDistance = 2f;

        private readonly List<Item> items = new List<Item>();

        public Inventory(GameObject owner, Transform eyes, float maxDistance = 2f)
        {
            Owner = owner;
            Eyes = eyes;
            MaxDistance = maxDistance;
        }

        public virtual void AddItem(Item item)
        {
            items.Add(item);
            Debug.Log($"{item.Name} added");
        }

        public virtual void RemoveItem(Item item)
        {
            items.Remove(item);
            Debug.Log($"{item.Name} removed");
        }

        public virtual void UseItem(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                items[index].Use();
            }
        }

        public virtual void DropItem(int index)
        {
            if (index < 0 || index >= items.Count)
            {
                Debug.Log($"Wrong index: {index}");
                return;
            }

            items[index].Drop();
            RemoveItem(items[index]);
        }

        public virtual List<Item> GetItems()
        {
            return items;
        }
    }
}