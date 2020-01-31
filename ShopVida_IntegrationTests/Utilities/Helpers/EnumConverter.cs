namespace ShopVidaTests.Utilities.Helpers
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    public static class EnumConverter
    {
        public static T ConvertToEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static T GetEnumValueByDescription<T>(string description)
        {
            MemberInfo[] enumFields = typeof(T).GetFields();

            foreach (var enumField in enumFields)
            {
                var attributes = (DescriptionAttribute[])enumField.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Any() && attributes.First().Description.Equals(description, StringComparison.InvariantCultureIgnoreCase))
                {
                    return (T)Enum.Parse(typeof(T), enumField.Name);
                }
            }

            try
            {
                return (T)Enum.Parse(typeof(T), description);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Enum not found for: {0}", description), e);
            }
        }

        public static string GetEnumDescription(this Enum enumInput)
        {
            var type = enumInput.GetType();

            var memInfo = type.GetMember(enumInput.ToString());

            if (memInfo != null && memInfo.Any())
            {
                object[] attributes = memInfo.First().GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Any())
                {
                    return ((DescriptionAttribute)attributes.First()).Description;
                }
            }

            return enumInput.ToString();
        }
    }
}

