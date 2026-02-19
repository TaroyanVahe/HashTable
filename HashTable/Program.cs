namespace HashTable
{
    internal class Program
    {
        class Node
        {
            public int value;
            public Node Next;
            public Node(int data)
            {
                value = data;

            }

        }
        class HashTable
        {
            Node[] buckets;
            private int _tablesize;
            private double _size;
            private double _coef;

            public HashTable(int data)
            {
                _tablesize = data;
                buckets = new Node[_tablesize];


            }
            public int GetHash(int data)
            {
                return data % _tablesize;


            }


            public void Insert(int data)
            {

                int index = GetHash(data);
                if (buckets[index] == null)
                {
                    buckets[index] = new Node(data);
                    ++_size;
                }
                else
                {
                    Node cur = buckets[index];
                    while (cur.Next != null)
                    {
                        cur = cur.Next;
                    }
                    cur.Next = new Node(data);
                    ++_size;
                }


                if (GetCoef() > 0.7)
                {


                    resize();
                }

            }
            public void print()
            {
                for (int i = 0; i < _tablesize; i++)
                {
                    Node cur = buckets[i];
                    while (cur != null)
                    {
                        Console.Write($"{cur.value} ");
                        cur = cur.Next;
                    }
                }
                Console.WriteLine();
            }
            public bool find(int data)
            {

                int temp = GetHash(data);
                Node cur = buckets[temp];
                while (cur != null)
                {
                    if (cur.value == data)
                        return true;
                    cur = cur.Next;
                }
                return false;
            }
            public bool remove(int data)
            {

                int hash = GetHash(data);
                Node cur = buckets[hash];
                Node prev = null;

                while (cur != null)
                {

                    if (cur.value == data)
                    {
                        if (prev == null)
                        {
                            buckets[hash] = cur.Next;
                            _size--;
                            return true;
                        }
                        else
                        {
                            prev.Next = cur.Next;
                            _size--;
                            return true;
                        }

                    }
                    prev = cur;
                    cur = cur.Next;
                }

                return false;

            }
            public void resize()
            {
                _tablesize = 2 * _tablesize;
                Node[] tempbuckets = buckets;

                buckets = new Node[_tablesize];
                _size = 0;


                for (int i = 0; i < tempbuckets.Length; i++)
                {
                    Node cur = tempbuckets[i];
                    while (cur != null)
                    {
                        Insert(cur.value);
                        cur = cur.Next;
                    }

                }

            }
            public double GetCoef()
            {
                _coef = _size / _tablesize;
                return _coef;
            }

        }




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
            Console.WriteLine( hashTable.remove(425));

            hashTable.print();







        }

    }
}

