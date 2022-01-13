namespace BstLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree
    {
        #region ctors
        public Tree(IEnumerable<int> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values) + " ist null.");
            }

            var valuesArray = values.ToArray();

            int arrayLen = valuesArray.Length;
            if (arrayLen == 0)
            {
                throw new ArgumentException(nameof(values) + " enthält keine Werte.");
            }

            Key = valuesArray[0];
            for (int i = 1; i < arrayLen; i++)
            {
                this.Add(valuesArray[i]);
            }
        }

        public Tree(int value)
        {
            Key = value;
        }

        private Tree()
        {

        }

        #endregion

        #region properties

        private int Key
        {
            get; set;
        }

        private Tree Left
        {
            get; set;

        }

        private Tree Right
        {
            get; set;
        }

        #endregion

        #region public methods
        public void Add(int key)
        {
            if (key <= Key)
            {
                if (Left == null)
                {
                    Left = new Tree(key);
                }
                else
                {
                    Left.Add(key);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new Tree(key);
                }
                else
                {
                    Right.Add(key);
                }
            }
        }

        public IEnumerable<int> Sort()
        {
            List<int> list = new List<int>();
            if (Left != null)
            {
                list.AddRange(Left.Sort());
            }

            list.Add(Key);

            if (Right != null)
            {
                list.AddRange(Right.Sort());
            }

            return list;
        }

        public bool Find(int key)
        {
            if (key == Key)
            {
                return true;
            }

            if (key < Key)
            {
                if (Left != null)
                {
                    return Left.Find(key);
                }
            }

            if (key > Key)
            {
                if (Right != null)
                {
                    return Right.Find(key);
                }
            }

            return false;
        }
        #endregion
    }
}