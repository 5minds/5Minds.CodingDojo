namespace tkallweit
{
    using System;

    public class BstNode<T> where T : IComparable<T>
    {

        public T Value
        {
            get; private set;
        }
        
        public BstNode<T> Left
        {
            get; private set;

        }
        public BstNode<T> Right
        {
            get; private set;
        }
    }
}