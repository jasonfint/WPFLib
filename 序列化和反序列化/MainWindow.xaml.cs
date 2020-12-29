using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Xml.Serialization;
using 序列化和反序列化.Protobuf序列化;

namespace 序列化和反序列化
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        TestResultInfo testResultInfo;
        public MainWindow()
        {
            InitializeComponent();
            CreateData();
        }
        private void CreateData()
        {
             testResultInfo = new TestResultInfo();
            List<TestResultInfo> subs = new List<TestResultInfo>();
            subs.Add(new TestResultInfo());
            for (int i = 0; i < 60000; i++)
            {
                testResultInfo.Subs.Add(new TestResultInfo() { Name = "Name"+i, Subs = subs });
            }
            Console.WriteLine("数据生成成功！");
        }
        private void Serialize_Click(object sender, RoutedEventArgs e)
        {
           
            Stopwatch stopwatch = Stopwatch.StartNew();
            //二进制序列化

            //①创建文件流

            FileStream fileStream = new FileStream(@"F:\序列化\测试结果.bin", FileMode.Create);//需要引入命名空间System.IO;

            //②创建二进制格式化器

            BinaryFormatter formatter = new BinaryFormatter();//需要引入命名空间System.Runtime.Serialization.Formatters.Binary;

            //③序列化对象

            formatter.Serialize(fileStream, testResultInfo);

            //④关闭文件流

            fileStream.Close();
            stopwatch.Stop();
            Console.WriteLine("序列化  " + stopwatch.ElapsedMilliseconds);
        }

        private void Unserialize_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            //创建文件流

            FileStream fileStream = new FileStream(@"F:\序列化\测试结果.bin", FileMode.Open);

            //创建二进制格式化器

            BinaryFormatter formatter = new BinaryFormatter();

            //反序列化还原对象

            TestResultInfo testResultInfo = (TestResultInfo)formatter.Deserialize(fileStream);

            //关闭文件流

            fileStream.Close();

            //foreach (var item in person)
            //{
            //    Console.WriteLine(item.SayHello());
            //}
            //MessageBox.Show(person.SayHello());//消息框弹出，弹出内容Person类的SayHello方法
            stopwatch.Stop();
            Console.WriteLine("反序列化：  " + stopwatch.ElapsedMilliseconds);
        }

        private void Xmlserialize_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();           
            //XML格式序列化

            //①创建文件流

            FileStream fileStream = new FileStream(@"F:\序列化\testXML.xml", FileMode.Create);

            //②创建XML格式化器

            XmlSerializer serializer = new XmlSerializer(typeof(TestResultInfo));//需要引入命名空间System.Xml.Serialization;

            //③序列化对象

            serializer.Serialize(fileStream, testResultInfo);

            //④关闭文件流

            fileStream.Close();
            stopwatch.Stop();
            Console.WriteLine("xml  " + stopwatch.ElapsedMilliseconds);
        }

        private void Xmlunserialize_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            FileStream fileStream = new FileStream(@"F:\序列化\testXML.xml", FileMode.Open);

            XmlSerializer serializer = new XmlSerializer(typeof(TestResultInfo));

            //反序列化PersonList对象

            TestResultInfo testResultInfo = (TestResultInfo)serializer.Deserialize(fileStream);

            fileStream.Close();

            stopwatch.Stop();
            Console.WriteLine("unxml  " + stopwatch.ElapsedMilliseconds);
            GC.Collect();
        }

        private void Jasonserialize_Click(object sender, RoutedEventArgs e)
        {
            var fileInfo = new FileInfo($@"F:\序列化\JsonS.json");
            
            if (fileInfo.Exists)
                fileInfo.Delete();
            Stopwatch stopwatch = Stopwatch.StartNew();
            using (var stream = new StreamWriter(fileInfo.OpenWrite()))
            {
                var str = JsonConvert.SerializeObject(testResultInfo, Formatting.Indented);
                stream.Write(str);
                //stream.Flush();
                //stream.Close();
            }

            stopwatch.Stop();

            Console.WriteLine("json  " + stopwatch.ElapsedMilliseconds);

        }

        private void Jsonunserialize_Click(object sender, RoutedEventArgs e)
        {
            var fileInfo = new FileInfo($@"F:\序列化\JsonS.json");
            Stopwatch stopwatch = Stopwatch.StartNew();
            if (fileInfo.Exists)
            {
                using (var stream = new StreamReader(fileInfo.OpenRead()))
                {
                    stopwatch.Stop();
                    Console.WriteLine("json read " + stopwatch.ElapsedMilliseconds);
                    stopwatch.Restart();
                    var str = JsonConvert.DeserializeObject<TestResultInfo>(stream.ReadToEnd());
                }
                stopwatch.Stop();
                Console.WriteLine("json  " + stopwatch.ElapsedMilliseconds);
            }
        }

        private void Streamwriter_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
           
            StreamWriter writer = new StreamWriter($@"F:\序列化\Stream.txt");//初始化写入           


            writer.WriteLine(testResultInfo);
            foreach (var item in testResultInfo.Subs)
            {
                writer.WriteLine(item);
                foreach (var myitem in item.Subs)
                {
                    writer.WriteLine(myitem);
                }

                writer.WriteLine();//写入一行
            }

            writer.Flush();
            writer.Close();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        private void CreateData_Click(object sender, RoutedEventArgs e)
        {
            CreateData();
        }

        private void Protobuf_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var aa = ProtobufExchang.ProtobufSerialize(testResultInfo);
            stopwatch.Stop();
            Console.WriteLine("ProtobufSerialize:" + stopwatch.ElapsedMilliseconds);            
        }

        private void Deprotobuf_Click(object sender, RoutedEventArgs e)
        {
            testResultInfo = new TestResultInfo();
            Stopwatch stopwatch = Stopwatch.StartNew();
            testResultInfo = ProtobufExchang.ProtobufDeserialize<TestResultInfo>();
            stopwatch.Stop();
            Console.WriteLine("ProtobufUNSerialize:" + stopwatch.ElapsedMilliseconds);
        }
    }
}
