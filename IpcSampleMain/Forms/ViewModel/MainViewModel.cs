using AYam.Common.MVVM;

namespace IpcSampleMain.Forms.ViewModel
{

    /// <summary>IPC通信：メイン.ViewModel</summary>
    public class MainViewModel : ViewModelBase
    {

        #region Model

        private Model.MainModel _Model;

        #endregion

        #region Property

        /// <summary>結果</summary>
        public int Result { get; set; }

        /// <summary>結果取得コマンド</summary>
        public DelegateCommand GetResultCommand { private set; get; }

        /// <summary>ボタンクリック許可</summary>
        public bool IsEnabled { get; set; } = true;

        #endregion

        /// <summary>IPC通信：メイン.ViewModel</summary>
        public MainViewModel()
        {

            _Model = new Model.MainModel(ChangeResult);

            GetResultCommand = new DelegateCommand(() => 
            {

                IsEnabled = false;
                CallPropertyChanged(nameof(IsEnabled));

                _Model?.Execute();

            },
            () => IsEnabled);

        }

        /// <summary>結果値の更新</summary>
        /// <param name="value">新しい値</param>
        private void ChangeResult(int value)
        {

            Result = value;
            CallPropertyChanged(nameof(Result));

            IsEnabled = true;
            CallPropertyChanged(nameof(IsEnabled));

        }

    }

}
