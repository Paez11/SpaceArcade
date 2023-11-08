using UnityEngine;

namespace Patterns.Adapter
{
    public class Consumer : MonoBehaviour
    {
        [SerializeField] private DataStore _fileDataStoreAdapter;
        private void Awake() 
        {
            _fileDataStoreAdapter = new PlayerPrefsDataStoreAdapter();
            var data = new Data("Dato1", 123);
            _fileDataStoreAdapter.SetData(data, "data1");    
        }

        private void Start() 
        {
            _fileDataStoreAdapter.GetData<Data>("Data1");
        }
    }

    internal class Data
    {
        private string v1;
        private int v2;

        public Data(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}

