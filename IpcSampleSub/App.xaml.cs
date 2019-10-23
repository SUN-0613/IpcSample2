﻿using IpcSampleSub.Forms.View;
using System.Windows;

namespace IpcSampleSub
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {

        /// <summary>処理開始</summary>
        /// <param name="e">開始イベントデータ</param>
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            new SubView().ShowDialog();

        }

    }

}