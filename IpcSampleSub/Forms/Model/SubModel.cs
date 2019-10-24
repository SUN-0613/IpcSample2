using IpcSampleCommonLibrary.Interface;
using IpcSampleCommonLibrary.Method;
using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace IpcSampleSub.Forms.Model
{

    /// <summary>IPC通信：サブ.Model</summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SubModel : IExecute, IDisposable
    {

        #region Delegate

        /// <summary>Loadingラベル表示変更デリゲート</summary>
        /// <param name="visible">表示方法</param>
        public delegate void ChangeVisibleDelegate(Visibility visible);

        /// <summary>現在値の更新デリゲート</summary>
        /// <param name="value">新しい値</param>
        public delegate void ChangeValueDelegate(int value);

        #endregion

        /// <summary>Loadingラベル表示変更</summary>
        private ChangeVisibleDelegate _ChangeVisible;

        /// <summary>現在値の更新</summary>
        private ChangeValueDelegate _ChangeValue;

        /// <summary>IPC通信サービス</summary>
        private ServiceHost _Host;

        /// <summary>IPC通信：サブ.Model</summary>
        /// <param name="changeVisible">Loadingラベル表示変更</param>
        /// <param name="changeValue">現在値更新</param>
        public SubModel(ChangeVisibleDelegate changeVisible, ChangeValueDelegate changeValue)
        {

            _ChangeVisible = changeVisible;
            _ChangeValue = changeValue;

            // サーバ設定
            _Host = new ServiceHost(this, new Uri(ServiceMethod.GetSubBaseAddress()));
            _Host.AddServiceEndpoint(typeof(IExecute), new NetNamedPipeBinding(), ServiceMethod.GetSubEndpoint());
            _Host.Open();

        }

        /// <summary>解放処理</summary>
        public void Dispose()
        {

            _Host.Close();

            _ChangeVisible = null;
            _ChangeValue = null;

        }

        /// <summary>値取得実行</summary>
        async Task<int> IExecute.Execute()
        {

            var value = -1;

            await Task.Run(() =>
            {

                _ChangeVisible(Visibility.Visible);

                var random = new Random(DateTime.Now.Second * 1000 + DateTime.Now.Millisecond);

                for (var iLoop = 0; iLoop < 5; iLoop++)
                {

                    Thread.Sleep(1000);

                    value = random.Next();
                    _ChangeValue(value);

                }

                _ChangeVisible(Visibility.Hidden);

            });

            return value;

        }

    }

}
