

namespace Service.Components
{
    public class ModelMergeComponents
    {
        /// <summary>
        /// Merage two 
        /// This is primarily used 
        /// for multipart form 
        /// </summary>
        /// <param name="Primary">
        /// DTO
        /// </param>
        /// <param name="Secondary">
        /// EF Model
        /// </param>
        /// <returns></returns>
        public static object MergeRecipients(object Primary, object Secondary)
        {
            try
            {
                // Get the type of the object
                System.Type type = Secondary.GetType();

                // For each property of this object, html decode it if it is of type string
                foreach (System.Reflection.PropertyInfo propertyInfo in type.GetProperties())
                {
                    var prop = propertyInfo.GetValue(Secondary);
                    if (prop != null && prop.GetType() == typeof(string))
                    {
                        propertyInfo.SetValue(Primary, (string)prop);
                    }
                    if (prop != null && prop.GetType() == typeof(System.Guid) && propertyInfo.Name != "ID")
                    {
                        propertyInfo.SetValue(Primary, (System.Guid)prop);
                    }
                    if (prop != null && prop.GetType() == typeof(int))
                    {
                        propertyInfo.SetValue(Primary, (int)prop);
                    }
                    if (prop != null && prop.GetType() == typeof(bool))
                    {
                        propertyInfo.SetValue(Primary, (bool)prop);
                    }
                    if (prop != null && prop.GetType() == typeof(System.Guid?))
                    {
                        propertyInfo.SetValue(Primary, (System.Guid?)prop);
                    }
                    if (prop != null && prop.GetType() == typeof(int?))
                    {
                        propertyInfo.SetValue(Primary, (int?)prop);
                    }
                    if (prop != null && prop.GetType() == typeof(bool?))
                    {
                        propertyInfo.SetValue(Primary, (bool?)prop);
                    }
                }
            }
            catch (System.Exception exc)
            {
               
            }

            return Primary;
        }

    }
}
