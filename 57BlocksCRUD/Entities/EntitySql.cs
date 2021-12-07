namespace _57BlocksCRUD.Entities
{
    using System.Collections.Generic;

    public class EntitySql
    {
        private string _query;
        private List<param> _param;
        private List<values> _values;

        public string query { get { return _query; } set { _query = value; } }

        public List<param> param { get { return _param; } set { _param = value; } }

        public List<values> values { get { return _values; } set { _values = value; } }
    }

    public class param
    {
        private string _ParamName;
        private object _ParamValue;

        public string ParamName { get { return _ParamName; } set { _ParamName = value; } }

        public object ParamValue { get { return _ParamValue; } set { _ParamValue = value; } }
    }

    public class values
    {
        private string _Value;

        public string Value { get { return _Value; } set { _Value = value; } }
    }
}
