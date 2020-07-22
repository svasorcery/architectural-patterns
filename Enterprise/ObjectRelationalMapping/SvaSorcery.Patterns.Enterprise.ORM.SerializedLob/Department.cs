namespace SvaSorcery.Patterns.Enterprise.ORM.SerializedLob
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual Department Parent { get; set; }

        public override string ToString() => ToString(this);

        private string ToString(Department dept)
        {
            var value = "";
            if (dept.Parent is null)
                return dept.Name;

            value += $"{ToString(dept.Parent)} > {dept.Name}";
            return value;
        }

        public Department(int id, string name, int? parentId = null)
        {
            Id = id;
            Name = name;
            ParentId = parentId;
        }

        public Department(int id, string name, Department parent)
        {
            Id = id;
            Name = name;
            ParentId = parent.Id;
            Parent = parent;
        }
    }
}
