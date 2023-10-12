using LiteDB;
using ValueHunterDesktop.Models;
using System.Collections.Generic;

namespace LiteDbLearningProject.DAL
{
    public class LiteDbService
    {
        private readonly LiteDatabase _db;
        public LiteCollection<AlertModel> Alerts { get; }

        public LiteDbService(string database)
        {
            _db = new LiteDatabase(database);
            Alerts = _db.GetCollection<AlertModel>("Alerts");
        }

        public void InsertAlert(AlertModel alert)
        {
            Alerts.Insert(alert);
        }

        public AlertModel FindAlertById(int alertId)
        {
            return Alerts.FindById(alertId);
        }

        public IEnumerable<AlertModel> GetAllAlerts()
        {
            return Alerts.FindAll();
        }

        
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
