﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player:LivingCreature
    {
        
        public int Gold {  get; set; }
        public int ExpPoints {  get; set; }
        public int Level {  get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerMission> Missions { get; set; }
        public Location CurrentLocation { get; set; }

        public Player(int currenthit,int maxhit,int gold,int expPoints,int level):base(currenthit,maxhit) 
        {
            Gold = gold;
            ExpPoints = expPoints;
            Level = level;
            Inventory = new List<InventoryItem>();
            Missions = new List<PlayerMission>();
        }
        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            if (location.ItemRequiredToEnter == null)
            {
                // There is no required item for this location, so return "true"
                return true;
            }

            // See if the player has the required item in their inventory
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == location.ItemRequiredToEnter.ID)
                {
                    // We found the required item, so return "true"
                    return true;
                }
            }

            // We didn't find the required item in their inventory, so return "false"
            return false;
        }

        public bool HasThisMission(Mission quest)
        {
            foreach (PlayerMission playerMission in Missions)
            {
                if (playerMission.Details.ID == quest.ID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CompletedThisMission(Mission quest)
        {
            foreach (PlayerMission playerMission in Missions)
            {
                if (playerMission.Details.ID == quest.ID)
                {
                    return playerMission.IsCompleted;
                }
            }

            return false;
        }

        public bool HasAllMissionCompleteItems(Mission quest)
        {
            // See if the player has all the items needed to complete the quest here
            foreach (MissionCompleteItem qci in quest.MissionCompleteItems)
            {
                bool foundItemInPlayersInventory = false;

                // Check each item in the player's inventory, to see if they have it, and enough of it
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID) // The player has the item in their inventory
                    {
                        foundItemInPlayersInventory = true;

                        if (ii.Quantity < qci.Quantity) // The player does not have enough of this item to complete the quest
                        {
                            return false;
                        }
                    }
                }

                // The player does not have any of this quest completion item in their inventory
                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }

            // If we got here, then the player must have all the required items, and enough of them, to complete the quest.
            return true;
        }

        public void RemoveMissionCompleteItems(Mission quest)
        {
            foreach (MissionCompleteItem qci in quest.MissionCompleteItems)
            {
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID)
                    {
                        // Subtract the quantity from the player's inventory that was needed to complete the quest
                        ii.Quantity -= qci.Quantity;
                        break;
                    }
                }
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == itemToAdd.ID)
                {
                    // They have the item in their inventory, so increase the quantity by one
                    ii.Quantity++;

                    return; // We added the item, and are done, so get out of this function
                }
            }

            // They didn't have the item, so add it to their inventory, with a quantity of 1
            Inventory.Add(new InventoryItem(itemToAdd, 1));
        }

        public void MarkMissionCompleted(Mission quest)
        {
            // Find the quest in the player's quest list
            foreach (PlayerMission pq in Missions)
            {
                if (pq.Details.ID == quest.ID)
                {
                    // Mark it as completed
                    pq.IsCompleted = true;

                    return; // We found the quest, and marked it complete, so get out of this function
                }
            }
        }
    }
}
    

