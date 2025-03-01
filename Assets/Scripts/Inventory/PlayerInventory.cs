using ProjectFish.InventorySystem;
using UnityEngine;

namespace ProjectFish.InventorySystem
{
    public class PlayerInventory : Inventory
    {
        public PlayerInventory(GameObject owner, Transform eyes) : base(owner, eyes)
        {

        }

        public void TryPickupItem()
        {
            RaycastHit hit;
            if (Physics.Raycast(Eyes.position, Eyes.forward, out hit, MaxDistance))
            {
                Item item = hit.collider.GetComponent<Item>();
                if (item != null)
                {
                    item.Pickup(this);
                }
            }
        }

        public override void AddItem(Item item)
        {
            base.AddItem(item);
            DisplayInventory();
        }

        public override void UseItem(int index)
        {
            base.UseItem(index);
            DisplayInventory();
        }

        public override void DropItem(int index)
        {
            base.DropItem(index);
            DisplayInventory();
        }

        public void DisplayInventory()
        {
            foreach (var item in GetItems())
            {
                Debug.Log(item.Name);
            }
        }
    }
}