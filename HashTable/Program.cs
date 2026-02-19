namespace HashTable
{
    internal class Program
    {

        static void Main(string[] args)
        {

            HashTable hashTable = new HashTable(6);

            hashTable.Insert(10);
            hashTable.Insert(1);

            hashTable.Insert(11);
            hashTable.Insert(12);
            hashTable.Insert(20);
            hashTable.Insert(21);
            hashTable.Insert(22);
            hashTable.Insert(2);
            hashTable.Insert(0);
            hashTable.Insert(3);
            hashTable.Insert(425);


            hashTable.print();

            Console.WriteLine(hashTable.find(0));
            Console.WriteLine(hashTable.remove(425));

            hashTable.print();


        }

    }
}

