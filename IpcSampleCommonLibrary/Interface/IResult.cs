using System.ServiceModel;

namespace IpcSampleCommonLibrary.Interface
{

    /// <summary>
    /// プロセス間通信インターフェース
    /// 結果取得
    /// </summary>
    [ServiceContract]
    public interface IResult
    {

        /// <summary>読み込み結果を渡す</summary>
        /// <param name="value">結果の値</param>
        [OperationContract]
        void SetResult(int value);

    }

}
