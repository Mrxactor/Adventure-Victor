
namespace Adventure
{
    internal class Enemy
    {
        public string Name;
        public int Hp;
        public int Damage;
        public int GoldReward;


        public Enemy(string name, int hp, int damage, int goldReward)
        {
            Name = name;
            Hp = hp;
            Damage = damage;
            GoldReward = goldReward;
        }
    }
}
