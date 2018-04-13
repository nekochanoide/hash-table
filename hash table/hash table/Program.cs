using System;
using System.Collections.Generic;

namespace hash_table
{
    public class HashTable
    {
        //Пара ключ-значение
        public class Pair
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }

        public static List<Pair>[] hashTable;

        public static void Table(int size)
        {
            //Массив листов для хэш таблицы
            hashTable = new List<Pair>[size];
            for (int i = 0; i < size; i++)
                hashTable[i] = new List<Pair>();
        }

        static public void PutPair(object key, object value)
        {
            //Складываю ключ и значение в пару
            var pair = new Pair { Key = key, Value = value };

            //Получение хэша ключа (индекс массива, куда положить значение)
            int index = Math.Abs(key.GetHashCode() % hashTable.Length);

            //Проверка на добавление уже существующего ключа
            for (int i = 0; i < hashTable[index].Count; i++)
            {
                if (hashTable[index][i].Key == key)
                {
                    //Замена старого значения на новое, если уже существует ключ
                    hashTable[index][i] = pair;
                }
            }
            //Добавляю пару
            hashTable[index].Add(pair);
        }

        public static object GetValueByKey(object key)
        {
            int index = Math.Abs(key.GetHashCode() % hashTable.Length);
            //Поиск совпадения ключа
            foreach (var e in hashTable[index])
            {
                if (e.Key.Equals(key))
                    return e.Value;
            }
            //Возвращает null, если запрошенного ключа нет в таблице.
            return null;
        }
        static void Main()
        {

        }
    }
}
