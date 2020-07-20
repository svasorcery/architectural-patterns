using System;
using System.Timers;
using System.Data.SqlClient;
using SvaSorcery.Patterns.Enterprise.Resource.ResourcePool;

namespace SvaSorcery.Patterns.Enterprise.Resource.ResourceTimer
{
    public class TimedPooledSqlDatabaseConnection : DatabaseResource<SqlConnection>
    {
        private readonly IResourcePool<DatabaseResource<SqlConnection>> _connectionPool;
        private DatabaseResource<SqlConnection> _resource;
        private readonly DatabaseConnectionTimer _timer;

        public TimedPooledSqlDatabaseConnection(IResourcePool<DatabaseResource<SqlConnection>> connectionPool, int timerSeconds)
            : this(connectionPool, new TimeSpan(0, 0, timerSeconds))
        {
        }

        public TimedPooledSqlDatabaseConnection(IResourcePool<DatabaseResource<SqlConnection>> connectionPool, TimeSpan timerSpan)
        {
            _connectionPool = connectionPool;
            _timer = new DatabaseConnectionTimer(timerSpan);
            _timer.AddListener(OnTimedEvent);
        }

        public override void Open()
        {
            _resource = _connectionPool.GetResource();
            _timer.Start();
        }

        public override void Close()
        {
            _timer.Stop();
            _connectionPool.PutResource(_resource);
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e) => Close();
    }
}
