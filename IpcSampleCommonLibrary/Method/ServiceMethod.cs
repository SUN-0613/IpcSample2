using IpcSampleCommonLibrary.Properties;

namespace IpcSampleCommonLibrary.Method
{

    /// <summary>IPC通信にて使用するメソッド</summary>
    public static class ServiceMethod
    {

        /// <summary>アドレス取得</summary>
        public static string GetMainAddress()
        {
            return Resource.MainAddress + "/" + Resource.EndPointMain;
        }

        /// <summary>アドレス取得</summary>
        public static string GetSubAddress()
        {
            return Resource.SubAddress + "/" + Resource.EndPointSub;
        }

        /// <summary>ベースアドレス取得</summary>
        public static string GetMainBaseAddress()
        {
            return Resource.MainAddress;
        }

        /// <summary>ベースアドレス取得</summary>
        public static string GetSubBaseAddress()
        {
            return Resource.SubAddress;
        }

        /// <summary>エンドポイント取得</summary>
        public static string GetMainEndpoint()
        {
            return Resource.EndPointMain;
        }

        /// <summary>エンドポイント取得</summary>
        public static string GetSubEndpoint()
        {
            return Resource.EndPointSub;
        }

    }

}
