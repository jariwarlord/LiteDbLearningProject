using Dapper;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Data;
using ValueHunterDesktop.Models;

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

                public IEnumerable<AlertModel> GetAllAlertsWithDapper()
        {
            using (IDbConnection dbConnection = new LiteDbConnection(_db))
            {
                dbConnection.Open();
                return dbConnection.Query<AlertModel>("SELECT * FROM Alerts");
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }

        public class LiteDbConnection : IDbConnection
    {
        private readonly LiteDatabase _db;

        public LiteDbConnection(LiteDatabase db)
        {
            _db = db;
        }

        public string ConnectionString { get; set; }

        public int ConnectionTimeout => 30;

        public string Database => "LiteDB";

        public ConnectionState State => ConnectionState.Open;

        public IDbTransaction BeginTransaction() => null;

        public IDbTransaction BeginTransaction(IsolationLevel il) => null;

        public void ChangeDatabase(string databaseName) { }

        public void Close() { }

        public IDbCommand CreateCommand() => new LiteDbCommand();

        public void Open() { }

        public void Dispose() { }
    }

    public class LiteDbCommand : IDbCommand
    {
        
    }
}
