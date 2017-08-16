using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SING.Infrastructure.Helper
{
    public class CloneHelpers
    {
        public static object DeepClone(object source)
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(m, source);
            m.Position = 0;
            return b.Deserialize(m);

        }

        public static object ClonebyByte(byte[] source)
        {
            MemoryStream m = new MemoryStream(source);
            m.Position = 0;
            BinaryFormatter b = new BinaryFormatter();

            return b.Deserialize(m);

        }
        public static bool DeepEquals(object objA, object objB)
        {
            MemoryStream serA = serializedStream(objA);
            MemoryStream serB = serializedStream(objB);
            if (serA.Length != serA.Length)
                return false;
            while (serA.Position < serA.Length)
            {
                if (serA.ReadByte() != serB.ReadByte())
                    return false;
            }
            return true;

        }
        public static MemoryStream serializedStream(object source)
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(m, source);
            m.Position = 0;

            return m;
        }
    }
}
