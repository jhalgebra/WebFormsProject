using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RWAProject.DAL
{
    abstract class BaseFileConverter<T, U> where T : new()
    {
        #region Properties

        public static T Instance { get; } = new T();

        public string Separator { get; set; } = "|_|"; 

        #endregion

        #region Constructors

        public BaseFileConverter() { }
        public BaseFileConverter(string separator) => Separator = separator;

        #endregion

        #region Methods

        protected IEnumerable<PropertyInfo> GetPropertyInfo(bool excludeVirtual = true)
        {
            var properties = typeof(U).GetProperties();

            if (!excludeVirtual)
                return properties;

            return properties.Where(prop => !prop.GetGetMethod().IsVirtual);
        }

        public virtual string Convert(U obj)
            => string.Join(Separator, GetPropertyInfo().Select(info => info.GetValue(obj)));

        public virtual U ConvertBack(string line)
        {
            var obj = Activator.CreateInstance<U>();
            var objProperties = GetPropertyInfo();

            var data = line?.Split(new string[] { Separator }, StringSplitOptions.None);

            if (data == null || data.Length != objProperties.Count())
                return default(U);

            for (int i = 0; i < data.Length; i++)
            {
                var prop = objProperties.ElementAt(i);

                prop.SetValue(obj, System.Convert.ChangeType(data[i], prop.PropertyType));
            }

            return obj;
        } 

        #endregion
    }
}
