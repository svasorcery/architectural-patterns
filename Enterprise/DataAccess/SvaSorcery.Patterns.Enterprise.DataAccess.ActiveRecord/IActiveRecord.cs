namespace SvaSorcery.Patterns.Enterprise.DataAccess.ActiveRecord
{
    public interface IActiveRecord
    {
        string TableName { get; }
        void Create();
        void Update();
        void Delete();
        string ToString();
    }
}
