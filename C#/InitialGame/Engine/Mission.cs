using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Mission
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardExpPoints {  get; set; }
        public int RewardGold {  get; set; }
        public Item RewardItem {  get; set; }
        public List<MissionCompleteItem> MissionCompleteItems { get; set; }
        
        public Mission(int iD, string name, string description, int rewardExp, int rewardGold)
        {
            ID = iD;
            Name = name;
            Description = description;
            RewardExpPoints = rewardExp;
            RewardGold = rewardGold;
            MissionCompleteItems = new List<MissionCompleteItem>();
        }
    }
}
