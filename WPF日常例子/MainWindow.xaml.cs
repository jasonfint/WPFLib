using System;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Windows;


namespace WPF日常例子
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string FilePath = @"C:\Users\User\Desktop\新建文件夹\DataContext.db";

        SQLiteConnection Conn;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteDBHelper db = new SQLiteDBHelper(FilePath);
            string sql = "INSERT INTO TestResultInfoes(ID, Batch, Number, Track, TestResultPath, TestDate, TestTime, Result, IsBackSide, Confirm, ProgramInfoID, TestProgramInfoID) values(@ID, @Batch, @Number, @Track, @TestResultPath, @TestDate, @TestTime, @Result, @IsBackSide, @Confirm, @ProgramInfoID, @TestProgramInfoID)";
            //string sql = "insert into " + "TestResultInfoes" + " (ID, Batch, Number, Track, TestResultPath, TestDate, TestTime, Result, IsBackSide, Confirm, ProgramInfoID, TestProgramInfoID) values ('" + 10043+ "'," + 'A' + "', " + 8 + "'," + 0 + "', "+ @"D:\AOI-XBin2.0\Results\062301$F\A\0000000008" + "'," + "'2020-06-23 00:00:00" + "'," + "'2020-06-23 16:35:10.7473638" + "'," + 0 + "'," + 0 + "'," + null + "'," + 31 +")";
            //VALUES (10043, 'A', 8, 0,D:\AOI-XBin2.0\Results\062301$F\A\0000000008, 2020-06-23 00:00:00, 2020-06-23 16:35:10.7473638, 0, 0, NULL, 31, 31)";
            for (int i = 0; i < 1000; i++)
            {
                string name = i.ToString().PadLeft(10, '0');
                DateTime dateTime = DateTime.Parse("2020-7-3 00:00:00").AddSeconds(i * 10);
                SQLiteParameter[] parameters = new SQLiteParameter[]{
             new SQLiteParameter("@ID",1+i),
           new SQLiteParameter("@Batch","A"),
           new SQLiteParameter("@Number",1+i),
           new SQLiteParameter("@Track",(object)0),
           new SQLiteParameter("@TestResultPath",@" H:\AOI X - Mutilanguage\bin\x64\Debug\Results\X-0417$F\"+name),
           new SQLiteParameter("@TestDate",dateTime.Date),
           new SQLiteParameter("@TestTime",dateTime),
           new SQLiteParameter("@Result",(object)0),
           new SQLiteParameter("@IsBackSide",(object)0),
           new SQLiteParameter("@Confirm",null),
           new SQLiteParameter("@ProgramInfoID",31),
           new SQLiteParameter("@TestProgramInfoID",31) };
                db.ExecuteNonQuery(sql, parameters);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for(int i=0;i<10;i++)
            {
                Console.WriteLine(System.Guid.NewGuid().ToString("N"));
            }
        
        }
        ConnectToSharedFolder accessNetworkDrive;
        public string networkPath = @"\\192.168.1.106\Version\AOIX";
        NetworkCredential credentials = new NetworkCredential("zzm", "1234567");
        public string myNetworkPath = string.Empty;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FileUpload(networkPath);
        accessNetworkDrive =new  ConnectToSharedFolder(networkPath, credentials);
        }
        public void FileUpload(string UploadURL)
        {
            try
            {
                using (new ConnectToSharedFolder(networkPath, credentials))
                {
                    var fileList = Directory.GetFiles(networkPath);

                    foreach (var item in fileList) { if (item.Contains("{ClientDocument}")) { myNetworkPath = item; } }

                    myNetworkPath = myNetworkPath + UploadURL;

                    //using (FileStream fileStream = File.Create(UploadURL, file.Length))
                    //{
                    //    await fileStream.WriteAsync(file, 0, file.Length);
                    //    fileStream.Close();
                    //}
                }
            }
            catch (Exception ex)
            {

            }

            //return obj;
        }
        public byte[] DownloadFileByte(string DownloadURL)
        {
            byte[] fileBytes = null;

            using (new ConnectToSharedFolder(networkPath, credentials))
            {
                var fileList = Directory.GetDirectories(networkPath);

                foreach (var item in fileList) { if (item.Contains("ClientDocuments")) { myNetworkPath = item; } }

                myNetworkPath = myNetworkPath + DownloadURL;

                try
                {
                    fileBytes = File.ReadAllBytes(myNetworkPath);
                }
                catch (Exception ex)
                {
                    string Message = ex.Message.ToString();
                }
            }

            return fileBytes;
        }

        /*
        using (DbConnection conn = factory.CreateConnection())
        {
            // 连接数据库
            conn.ConnectionString = "Data Source=test1.db3";
            conn.Open();

            // 创建数据表
            string sql = "create table [test1] ([id] INTEGER PRIMARY KEY, [s] TEXT COLLATE NOCASE)";
            DbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            // 添加参数
            cmd.Parameters.Add(cmd.CreateParameter());

            // 开始计时
            Stopwatch watch = new Stopwatch();
            watch.Start();

            DbTransaction trans = conn.BeginTransaction(); // <-------------------
            try
            {
                // 连续插入1000条记录
                for (int i = 0; i < 1000; i++)
                {
                    cmd.CommandText = "insert into [test1] ([s]) values (?)";
                    cmd.Parameters[0].Value = i.ToString();

                    cmd.ExecuteNonQuery();
                }

                trans.Commit(); // <-------------------
            }
            catch
            {
                trans.Rollback(); // <-------------------
                throw; // <-------------------
            }

            // 停止计时
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
        }
        */


    }
}
