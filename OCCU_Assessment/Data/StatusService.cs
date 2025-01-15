using System.Data;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OCCU_Assessment.Hubs;
using OCCU_Assessment.Models;

namespace OCCU_Assessment.Data
{
    public class StatusService
    {
        private List<Status> statuses;
        private readonly IHubContext<StatusHub> hubContext;
        private readonly Random rand = new Random();
        private readonly string[] possibleStatuses = { "fail", "warn", "pass" };
        private readonly Timer updateTimer;

        private readonly string filePath;
        private readonly object fileLock = new object();

        public StatusService(IHubContext<StatusHub> _hubContext)
        {
            this.hubContext = _hubContext;

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "statuses.json");
            LoadData();

            updateTimer = new Timer(UpdateStatuses, null, 1000, 1000);
        }

        private void LoadData()
        {
            if (!File.Exists(filePath))
            {
                statuses = new List<Status>();
                // Initialize with 37 statuses if file doesn't exist
                for (int i = 1; i <= 37; i++)
                {
                    statuses.Add(new Status
                    {
                        Id = i,
                        Tag = $"Status-{i}",
                        Value = possibleStatuses[rand.Next(possibleStatuses.Length)]
                    });
                }
                SaveData(); // Create the file
            }
            else
            {
                var json = File.ReadAllText(filePath);
                statuses = JsonSerializer.Deserialize<List<Status>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<Status>();
            }
        }

        private void SaveData()
        {
            var json = JsonSerializer.Serialize(statuses, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, json);
        }

        public List<Status> GetStatuses() => statuses;

        private void UpdateStatuses(object state)
        {
            lock (fileLock)
            {
                // Randomly change the status of a random item
                var index = rand.Next(statuses.Count);
                var newStatus = possibleStatuses[rand.Next(possibleStatuses.Length)];
                statuses[index].Value = newStatus;
                SaveData();

                // Broadcast the updated status to all clients
                var updatedStatus = statuses[index];
                hubContext.Clients.All.SendAsync("ReceiveStatusUpdate", updatedStatus);
            }
        }
    }
}
