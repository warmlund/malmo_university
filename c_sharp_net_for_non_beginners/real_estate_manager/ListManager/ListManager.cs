using System.Windows;

namespace real_estate_manager
{
    public abstract class ListManager<T> : IListManager<T>
    {
        protected List<T> _list;
        public int Count => _list.Count;

        protected ListManager()
        {
            _list = new List<T>();
        }

        public void Add(T item)
        {
            try
            {
                _list.Add(item);
            }

            catch
            {
                MessageBox.Show("Could not add estate");
            }
           
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < _list.Count)
                _list.RemoveAt(index);
        }

        public void ReplaceAt(T item, int index)
        {
            if (index >= 0 && index < _list.Count)
                _list[index] = item;
        }

        public T Get(int index)
        {
            if (index >= 0 && index < _list.Count)
                return _list[index];

            else
                return default;
        }

        public abstract string[] ToStringArray();
    }
}
