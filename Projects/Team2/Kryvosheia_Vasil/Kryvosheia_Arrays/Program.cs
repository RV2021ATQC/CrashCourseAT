//3. Написати програму, яка знаходить в масиві значення,       
//   що повторюються два і більше разів, і показує їх на екран.

using System; // пространство имен
using System.Collections.Generic;   
            // интерфейсы и классы, определяющие универсальные коллекции, 
            // которые позволяют пользователям создавать строго типизированные коллекции,
            // обеспечивающие повышенную производительность и безопасность типов 
            // по сравнению с неуниверсальными строго типизированными коллекциями.


class GFG  
    // тут я узнал что я тоже Гик  https://ru.wikipedia.org/wiki/%D0%93%D0%B8%D0%BA_(%D1%87%D0%B5%D0%BB%D0%BE%D0%B2%D0%B5%D0%BA)
{
    // Функция поиска одного из повторяющихся элементов
    // Function to find one of the repeating elements 
    
    static int findRepeatingNumber(int[] arr, int n)
    //"Static" означает, что данное поле, 
    // метод или свойство будет принадлежать не каждому объекту класса, а всем им вместе.
    {

        // Размер блоков за исключением последнего блока sq
        // Size of blocks except the last block is sq  
        int sq = (int)Math.Sqrt(n);


        // Количество блоков для включения от 1 до n блоков значений пронумеровано от 0 до диапазона-1 (оба включены)
        // Number of blocks to incorporate 1 to n values blocks are numbered from 0 to range-1 (both included) 
        int range = (n / sq) + 1;


        // Массив Count поддерживает счетчик для всех блоков
        // Count array maintains the count for all blocks  
        int[] count = new int[range];

        // Обход массива только для чтения и количество обновлений
        // Traversing the read only array and updating count  
        for (int i = 0; i <= n; i++)
        {
           //arr [i] принадлежит номеру блока (arr [i] -1) / sq i считается начинающимся с 0
           //arr [i] belongs to block number (arr[i]-1)/sq i is considered  to start from 0 
            count[(arr[i] - 1) / sq]++;
        }


        // По умолчанию selected_block установлен на последний блок.
        // Остальные блоки проверены
        // The selected_block is set to last block by default. 
        // Rest of the blocks are checked 
        int selected_block = range - 1;
        for (int i = 0; i < range - 1; i++)
        {
            if (count[i] > sq)
            {
                selected_block = i;
                break;
            }
        }


        // По умолчанию selected_block установлен на последний блок. Остальные блоки проверены
        // after finding block with size > sq  method of hashing is used to find the element repeating in this block  
        Dictionary<int, int> m = new Dictionary<int, int>();
        for (int i = 0; i <= n; i++)
        {
            // проверяет, принадлежит ли элемент к selected_block
            // checks if the element belongs to the selected_block  
            if (((selected_block * sq) < arr[i]) &&
                    (arr[i] <= ((selected_block + 1) * sq)))
            {
                m.Add(arr[i], 1);

                // найден повторяющийся элемент
                // repeating element found 
                if (m[arr[i]] == 1)
                    return arr[i];
                
            }
        }

        // вернуть -1, если повторяющийся элемент не существует
        // return -1 if no repeating element exists  
        return -1;
    }

        public static void Main(String[] args)
        {
            // массив только для чтения, не подлежит изменению
            // read only array, not to be modified  
            int[] arr = { 4, 2, 1, 5, 3, 2 };

            // массив размером 6 (n + 1) с элементами от 1 до 5
            // array of size 6(n + 1) having  elements between 1 and 5  
            int n = 5;

            Console.WriteLine("One of the numbers repeated in the array is: " +
                                        findRepeatingNumber(arr, n));
        }
}


