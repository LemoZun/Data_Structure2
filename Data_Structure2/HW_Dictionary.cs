namespace Data_Structure2
{
    internal class HW_Dictionary
    {
        static void Main(string[] args)
        {
            // Dictionary<string , Monster> monsterDic = new Dictionary<string , Monster>();
            MonsterData MD = new MonsterData();

            MD.monsterData.Add("멧돼지", new Monster("멧돼지",50, MonsterType.Ground));
            MD.monsterData.Add("멀록", new Monster("멀록", 20, MonsterType.Water));
            MD.monsterData.Add("비전구체", new Monster("비전구체", 50, MonsterType.Light));
            MD.monsterData.Add("폭풍매", new Monster("폭풍매", 50, MonsterType.Wind));
            MD.monsterData.Add("임프", new Monster("폭풍매", 10, MonsterType.Dark));

            Monster monster1 = new Monster(MD.monsterData["멧돼지"].name, MD.monsterData["멧돼지"].hp, MD.monsterData["멧돼지"].type);
            Monster monster2 = new Monster(MD.monsterData["멀록"]);
            Console.WriteLine($"이름 : {monster1.name} HP : {monster1.hp} 속성 : {monster1.type} ");
        }

        public enum MonsterType { Fire, Water, Ground, Wind , Light, Dark}
        
        public class MonsterData
        {
            public Dictionary<string, Monster> monsterData = new Dictionary<string, Monster>();
            
        }

        public class Monster
        {
            public string name;
            public int hp;            
            public MonsterType type;
            

            public Monster(string _name, int _hp, MonsterType _type)
            { 
                this.name = _name;
                this.hp = _hp;
                this.type = _type;
            }
            public Monster(Monster _monster)
            {
                this.name = _monster.name;
                this.hp = _monster.hp;
                this.type = _monster.type;
            }
        }
    }
}
