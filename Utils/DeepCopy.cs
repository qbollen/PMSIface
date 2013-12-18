using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Utils
{
    public class DeepCopy
    {
        public static T Clone<T>(T item)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();
            formatter.Serialize(mem, item);
            mem.Seek(0, SeekOrigin.Begin);
            T result = (T)formatter.Deserialize(mem);
            mem.Close();
            return result;
        }
    }
}
