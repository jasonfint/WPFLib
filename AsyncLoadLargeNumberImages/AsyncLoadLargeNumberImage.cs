using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AsyncLoadLargeNumberImages
{
    public class AsyncLoadLargeNumberImage : ReactiveObject
    {
        private ObservableCollection<Uri> images = new ObservableCollection<Uri>();
        public ObservableCollection<Uri> Images
        {
            get { return images; }
            set
            {
                this.RaiseAndSetIfChanged(ref images, value);
            }
        }

        // 用于线程间同步的对象
        object lockobj = new object();
        public AsyncLoadLargeNumberImage()
        {
            LoadData();
        }

        public void LoadData()
        {
            // 这一句很关键，开启集合的异步访问支持
            BindingOperations.EnableCollectionSynchronization(Images, lockobj);

            // 异步加载数据
            Task.Run(async () =>
            {
                // 代码写在 lock 块中
                //lock (lockobj)
                //{
                for (int i = 0; i < 500000; i++)
                {
                    Uri u = new Uri("0.png", UriKind.Relative);
                    lock (lockobj)
                    {
                        Images.Add(u);
                    }
                    await Task.Yield();
                }
                //}
            });
        }

    }
}
