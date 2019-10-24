using IpcSampleCommonLibrary.Interface;
using IpcSampleCommonLibrary.Method;
using System;
using System.Diagnostics;
using System.ServiceModel;

namespace IpcSampleMain.Forms.Model
{

    /// <summary>IPC通信：メイン.Model</summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MainModel : IDisposable
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

        }

        /// <summary>解放処理</summary>
        public void Dispose()
        {
            _ChangeResult = null;
        }

        /// <summary>値取得実行</summary>
        public async void Execute()
        {

            try
            {

                // サブプロジェクトにて値取得実行
                _ChangeResult?.Invoke(await _Sub.Execute());

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

    }

}
