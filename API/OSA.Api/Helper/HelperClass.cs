using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSA.Api.Helper
{
    public class HelperClass
    {
        internal void GetFilterValues(object something,ref int start, ref int length, ref string searchValue)
        {
            JToken token = JObject.Parse(something.ToString());
            length = (int)token.SelectToken("length");
            int draw = (int)token.SelectToken("draw");
            start = (int)token.SelectToken("start");
            string value = token.SelectToken("search").ToString();
            string[] splitted = value.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] splitted1 = splitted[1].Split(":");
            searchValue = splitted1[1].Replace("\"", "").Replace(",", "");
        }
    }
}
