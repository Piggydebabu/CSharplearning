using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster:LivingCreature
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        
        public int MaximumDamage {  get; set; }
        public int RewardExpPoints {  get; set; }
        public int RewardGold {  get; set; }
        public List<LootItem> LootTable { get; set; }

        public Monster(int iD, string name, int maximumDamage, int rewardExpPoints, int rewardGold,int currenthit,int maxhit):base(currenthit,maxhit)
        {
            ID = iD;
            Name = name;
            MaximumDamage = maximumDamage;
            RewardExpPoints = rewardExpPoints;
            RewardGold = rewardGold;
            LootTable = new List<LootItem>();
        }
    }
}
