using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace 序列化和反序列化
{
    namespace Protobuf序列化
    {
        public static class ProtobufExchang
        {
            /// <summary>
            /// 使用protobuf把对象序列化为Byte数组
            /// </summary>
            /// <typeparam name="T">需要反序列化的对象类型，必须声明[ProtoContract]特征，且相应属性必须声明[ProtoMember(序号)]特征</typeparam>
            /// <param name="obj"></param>
            /// <returns></returns>
            public static string ProtobufSerialize<T>(this T obj)
            {
                using (var file = System.IO.File.Create($@"F:\序列化\TESTResult.bin"))
                {
                    Serializer.Serialize(file, obj);
                    file.Close();
                    file.Dispose();
                }
                return string.Empty;
                //using (var memory = new MemoryStream())
                //{
                    
                //    //return memory.ToArray();
                //    return Encoding.Unicode.GetString(memory.ToArray());
                //}
            }
            /// <summary>
            /// 使用protobuf反序列化二进制数组为对象
            /// </summary>
            /// <typeparam name="T">需要反序列化的对象类型，必须声明[ProtoContract]特征，且相应属性必须声明[ProtoMember(序号)]特征</typeparam>
            /// <param name="data"></param>
            public static T ProtobufDeserialize<T>()
            {
                using (var file = System.IO.File.OpenRead($@"F:\序列化\TESTResult.bin"))
                {
                    var binMan = Serializer.Deserialize<T>(file);

                    file.Close();

                    file.Dispose();
                    return binMan;
                }



                    //这样就能 从文件反序列化出来 Man 对象了。 （用于快速存档的！如游戏开发）

                  

               
                //byte[] decBytes = System.Text.Encoding.Unicode.GetBytes(data);
                ////byte[] decBytes = Convert.FromBase64String(data);
                //using (var memory = new MemoryStream(decBytes))
                //{
                //    return Serializer.Deserialize<T>(memory);
                //}
            }
        }
    }
}
