using IpcSampleCommonLibrary.Interface;
using IpcSampleCommonLibrary.Method;
using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading.Tasks;

namespace IpcSampleMain.Forms.Model
{

    /// <summary>IPC通信：メイン.Model</summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MainModel : IResult, IDisposable
    {

        #region Delegate

        /// <summary>結果更新デリゲート</summary>
        /// <param name="value">新しい値</param>
        public delegate void ChangeResultDelegate(int value);

        #endregion

        /// <summary>結果更新</summary>
        private ChangeResultDelegate _ChangeResult;

        /// <summary>サブプロジェクト</summary>
        private IExecute _Sub;

        /// <summary>サーバ設定</summary>
        private ServiceHost _Host;

        /// <summary>IPC通信：メイン.Model</summary>
        /// <param name="changeResult">結果更新</param>
        public MainModel(ChangeResultDelegate changeResult)
        {

            _ChangeResult = changeResult;

            // サブプロジェクトへの通信設定
            _Sub = new ChannelFactory<IExecute>(
                new NetNamedPipeBinding(),
                new EndpointAddress(ServiceMethod.GetSubAddress())
                ).CreateChannel();

            // サーバ設定
            _Host = new ServiceHost(this, new Uri(ServiceMethod.GetMainBaseAddress()));
            _Host.AddServiceEndpoint(typeof(IResult), new NetNamedPipeBinding(), ServiceMethod.GetMainEndpoint());
            _Host.Open();

        }

        /// <summary>解放処理</summary>
        public void Dispose()
        {

            _Host.Close();

            _ChangeResult = null;

        }

        /// <summary>値取得実行</summary>
        public void Execute()
        {

            Task.Run(() => 
            {

                try
                {

                    // サブプロジェクトにて値取得実行
                    _Sub.Execute();

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

            });

        }

        /// <summary>結果のセット</summary>
        /// <param name="value">結果の値</param>
        public void SetResult(int value)
        {
            _ChangeResult(value);
        }

    }

}
