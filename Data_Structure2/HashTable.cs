using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure2
{    
    internal class HashTable
    {
        static void Main1()
        {
            // 해시테이블 기반의 dictionary 자료구조
            Dictionary<string, Monster> monsterDic = new Dictionary<string, Monster>();

            // 삽입
            // Add(키값 , 실제 value)
            monsterDic.Add("피카츄", new Monster("피카츄", MonsterType.Electric, 80));
            monsterDic.Add("파이리", new Monster("파이리", MonsterType.Fire, 90));
            monsterDic.Add("꼬부기", new Monster("꼬부기", MonsterType.Water, 70));
            monsterDic.Add("이상해씨", new Monster("이상해씨", MonsterType.Electric, 100));
            monsterDic["피죤"] = new Monster("피죤", MonsterType.Wind, 50); // 이렇게도 가능
            
            // try도 사용 가능
            // monsterDic.TryAdd
            // monsterDic.TryGetValue
            

            // 삭제
            // Remove(키값)
            monsterDic.Remove("이상해씨");

            // 탐색
            // 딕셔너리[키값]
            Monster find1 = monsterDic["피카츄"]; // O(1)
            Console.WriteLine($"{find1.name},{find1.type},{find1.hp}");

            if(monsterDic.ContainsKey("이상해씨")) // 있는지 없는지 확인하는 메서드
            {
                Monster find2 = monsterDic["이상해씨"];
            }
            monsterDic["피카츄"].hp = 110; // 키값(인덱서)를 통해 값 변경 가능 
        }
        public enum MonsterType { Fire, Water, Grass, Electric, Wind }
        public class Monster
        {
            public string name;
            public MonsterType type;
            public int hp;

            public Monster(string name, MonsterType type, int hp)
            {
                this.name = name;
                this.type = type;
                this.hp = hp;
            }
        }
    }    
}
