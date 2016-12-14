using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamlToXlsxConverterView
{
	public class XamlToXlsxConverterViewModelBase : INotifyPropertyChanged, IDisposable
	{
		// ------------------------------------------------------------------------------------------------------------
		#region コンストラクタ

		/// <summary>
		/// XamlToXlsxConverterViewModelBase クラスの新しいインスタンスを作成します。
		/// </summary>
		/// <remarks>
		/// このクラスはデザイン用に使用します。
		/// </remarks>
		public XamlToXlsxConverterViewModelBase()
		{
			this.Messenger.AddMessageType(typeof(ExecuteActionMessage));
		}

		/// <summary>
		/// View にメッセージを送信するオブジェクトを取得または設定します。
		/// </summary>
		protected Messenger Messenger { get; set; } = new Messenger();

		#endregion コンストラクタ
		// ------------------------------------------------------------------------------------------------------------
		#region プロパティ変更通知イベント

		/// <summary>
		/// プロパティが変更されたことを通知するイベントハンドラを定義します。
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// プロパティ変更イベントを発生させる
		/// </summary>
		/// <remarks>
		/// このメソッドをプロパティ値が変更された時にコールして下さい。<br/>
		/// プロパティ値が変更されたことをクライアント (通常はバインド元クライアント) に通知するためのイベントを発生させます。<br/>
		/// CallerMemberName の属性を使用すると、 NotifyPropertyChanged のメソッドへの呼び出しは文字列引数として<br/>
		/// プロパティ名を指定する必要はありません。そのプロパティ名になります。
		/// </remarks>
		/// <param name="propertyName">プロパティ名(デフォルト=そのプロパティ名)</param>
		public virtual void OnPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				// PropertyChangedイベントはUIスレッドで呼び出す。
				this.Messenger.SendAsync(new ExecuteActionMessage(() =>
				{
					handler(this, new PropertyChangedEventArgs(propertyName));
				}));
			}
		}

		#endregion プロパティ変更通知イベント
		// ------------------------------------------------------------------------------------------------------------
		#region IDisposable Support

		/// <summary>
		/// リソースが既に解放されていればtrueを保持します。
		/// </summary>
		/// <remarks>
		/// 重複して解放処理が行われないようにするために使用します。
		/// </remarks>
		private bool disposedValue = false; // 重複する呼び出しを検出するには

		/// <summary>
		/// オブジェクトの破棄処理
		/// </summary>
		/// <param name="disposing">マネージオブジェクトを破棄する場合はtrueを指定します。</param>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// マネージ状態を破棄します (マネージ オブジェクト)。
				}

				// アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
				// 大きなフィールドを null に設定します。

				disposedValue = true;
			}
		}

		/// <summary>
		/// ファイナライザ
		/// </summary>
		/// <remarks>
		/// アンマネージリソースを解放します。
		/// </remarks>
		~XamlToXlsxConverterViewModelBase()
		{
			// このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
			Dispose(false);
		}

		/// <summary>
		/// オブジェクトの終了処理を行います。
		/// </summary>
		/// <remarks>
		/// このコードは、破棄可能なパターンを正しく実装できるように追加されました。
		/// </remarks>
		public void Dispose()
		{
			// このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion IDisposable Support
		// ------------------------------------------------------------------------------------------------------------
		#region コマンド

		private ICommand FStartConvertCommand;

		public ICommand StartConvertCommand
		{
			get
			{
				return this.FStartConvertCommand = this.FStartConvertCommand ?? CommandFactory.Create(this.StartConvert);
			}
		}

		/// <summary>
		/// Xaml から Xlsx ファイルに変換します。
		/// </summary>
		protected virtual void StartConvert()
		{
		}

		#endregion コマンド
		// ------------------------------------------------------------------------------------------------------------
	}
}
