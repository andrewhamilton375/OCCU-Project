using System.Text.Json;
using OCCU_Assessment.Models;

namespace OCCU_Assessment.Data
{
    public class DataService
    {
        private List<DataItem> dataItems = new List<DataItem>();
        private readonly string filePath;
        private readonly object fileLock = new object();
        public DataService() {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "dataitems.json");
            LoadData();
        }

        private void LoadData()
        {
            if (!File.Exists(filePath))
            {
                dataItems = new List<DataItem>();
                for (int i = 1; i <= 30; i++)
                {
                    dataItems.Add(new DataItem
                    {
                        Name = $"Item-{i}",
                        Field1 = $"Value1-{i}",
                        Field2 = $"Value2-{i}",
                        Field3 = $"Value3-{i}",
                        UpdateTimeStamp = DateTime.Now
                    });
                }
                SaveData(); // Create the file if it doesn't exist
            }
            else
            {
                var json = File.ReadAllText(filePath);
                dataItems = JsonSerializer.Deserialize<List<DataItem>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<DataItem>();
            }
        }

        public List<DataItem> GetAll()
        {
            lock (fileLock)
            {
                return dataItems.ToList();
            }
        }

        public List<DataItem> Search(string searchTerm)
        {
            lock (fileLock)
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                    return dataItems;

                return dataItems.Where(d =>
                    d.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    d.Field1.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    d.Field2.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    d.Field3.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }
                
        }

        public bool Add(DataItem item)
        {
            lock (fileLock)
            {
                if (dataItems.Any(d => d.Name.Equals(item.Name, StringComparison.OrdinalIgnoreCase)))
                    return false;

                item.UpdateTimeStamp = DateTime.Now;
                dataItems.Add(item);
                SaveData();

                return true;
            }
            
        }

        public bool Update(string originalName, DataItem item)
        {
            lock (fileLock)
            {
                var existing = dataItems.FirstOrDefault(d => d.Name.Equals(originalName, StringComparison.OrdinalIgnoreCase));

                if (existing == null)
                    return false;

                // Check if the new name (if changed) is unique
                if (!existing.Name.Equals(item.Name, StringComparison.OrdinalIgnoreCase) &&
                    dataItems.Any(d => d.Name.Equals(item.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    return false; // New name already exists
                }

                existing.Name = item.Name;
                existing.Field1 = item.Field1;
                existing.Field2 = item.Field2;
                existing.Field3 = item.Field3;
                existing.UpdateTimeStamp = DateTime.Now;
                SaveData();

                return true;
            }
        }

        public bool Delete(string name)
        {
            lock (fileLock)
            {
                var item = dataItems.FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (item == null)
                    return false;

                dataItems.Remove(item);
                SaveData();
                return true;
            }
            
        }

        public DataItem GetByName(string name) =>
            dataItems.FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public bool Copy(string existingName, DataItem newItem)
        {
            lock (fileLock)
            {
                var existing = GetByName(existingName);
                if (existing == null && !dataItems.Any(d => d.Name.Equals(existingName, StringComparison.OrdinalIgnoreCase)))
                    return false;

                newItem.Field1 = existing.Field1;
                newItem.Field2 = existing.Field2;
                newItem.Field3 = existing.Field3;
                newItem.UpdateTimeStamp = DateTime.Now;
                dataItems.Add(newItem);
                SaveData() ;

                return true;
            }
        }

        private void SaveData()
        {
            var json = JsonSerializer.Serialize(dataItems, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, json);
        }
    }
}
