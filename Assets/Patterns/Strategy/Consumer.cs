using Patterns.Adapter;

namespace Patterns.Strategy
{
    public partial class Consumer
    {
        private readonly DataStore _dataStore;

        public Consumer(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Save()
        {
            var data = new Data("Hola", 4545);
            _dataStore.SetData(data, "data2");
        }

        public void Load()
        {
            _dataStore.GetData<Data>("data2");

        }
    }
}