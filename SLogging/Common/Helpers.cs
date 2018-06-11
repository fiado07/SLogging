using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLogging.Common
{
    internal class Helpers
    {


        public static string BuildStringLog(object sourceObject)
        {

            List<string> stringLogValues = new List<string>();


            if (!sourceObject.GetType().IsClass)
                throw new Exception("This object must be class!");



            Array.ForEach(sourceObject.GetType().GetProperties(),
                   propertyInfo =>
                   {


                       try
                       {

                           var propertyValue = propertyInfo.GetValue(sourceObject, null);
                           var isValidObject = !propertyInfo.Name.Equals("Entity", StringComparison.OrdinalIgnoreCase) && propertyValue != null;


                           if (isValidObject)
                           {

                               var isNotbyte = propertyValue is byte[] ? "isByte" : propertyValue.ToString();


                               stringLogValues.Add(String.Concat("[" + propertyInfo.Name + "]", " = ", isNotbyte));

                           }


                       }
                       catch (Exception)
                       {
                           stringLogValues.Add(String.Concat("[" + propertyInfo.Name + "]", " = ", ""));
                       }


                   });


            return string.Join(" || ", stringLogValues);

        }


    }
}
