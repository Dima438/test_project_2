using System.Collections.Generic;

namespace DBStuff.Support
{
    public class StringToList
    {
        public static List<int> GetIntList(string indexString)
        {
            List<int> indicies;
            string[] indexStrings;

            indexStrings = indexString.Split(' ');
            indicies = new List<int>();
            foreach (string str in indexStrings)
            {
                indicies.Add(int.Parse(str));
            }

            return indicies;
        }

    }
}