using AYam.Common.MVVM;
using System.Windows;

namespace IpcSampleSub.Forms.ViewModel
{

    /// <summary>IPC通信：サブ.ViewModel</summary>
    public class SubViewModel : ViewModelBase
    {

        #region Model

        /// <summary>IPC通信：サブ.Model</summary>
        private Model.SubModel _Model;

        #endregion

        #region Property

        /// <summary>Loadingラベル表示</summary>
        public Visibility Visible { get; set; } = Visibility.Hidden;

        /// <summary>現在値</summary>
        public int NowValue { get; set; } = -1;

        #endregion

        /// <summary>IPC通信：サブ.ViewModel</summary>
        public SubViewModel()
        {

            _Model = new Model.SubModel(ChangeVisible, ChangeValue);

        }

        /// <summary>Loadingラベル表示変更</summary>
        /// <param name="visible">表示方法</param>
        private void ChangeVisible(Visibility visible)
        {
            Visible = visible;
            CallPropertyChanged(nameof(Visible));
        }

        /// <summary>現在値の更新</summary>
        /// <param name="value">新しい値</param>
        private void ChangeValue(int value)
        {
            NowValue = value;
            CallPropertyChanged(nameof(NowValue));
        }

    }

}
