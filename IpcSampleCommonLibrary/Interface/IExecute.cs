using System.ServiceModel;
using System.Threading.Tasks;

namespace IpcSampleCommonLibrary.Interface
{

    /// <summary>
    /// プロセス間通信インターフェース
    /// 実行
    /// </summary>
    [ServiceContract]
    public interface IExecute
    {

        /// <summary>読み込み実行</summary>
        [OperationContract]
        Task<int> Execute();

    }

}
