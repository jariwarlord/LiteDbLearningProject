using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueHunterDesktop.Models;

namespace LiteDbLearningProject.DAL
{
    public class LiteDbService
    {
        private readonly LiteDatabase _db;
        public LiteCollection<AlertModel> Alerts { get; }
        
        public LiteDbLearningProject(string database)
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
    
    }
}
