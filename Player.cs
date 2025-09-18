
namespace Adventure
{
    internal class Player
    {
        public string Name;
        public string playerClass;
        public int MaxHp;
        public int Hp;
        public int Damage;
        public int Gold;

        public Player(string name, string className, int maxHp, int damage, int gold)
        {
            Name = name;
            playerClass = className;
            MaxHp = maxHp;
            Hp = maxHp;   // starta på fullt liv
            Damage = damage;
            Gold = gold;
        }
    }
}
