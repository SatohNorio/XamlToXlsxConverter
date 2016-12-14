using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XamlToXlsxConverterView
{
	/// <summary>
	/// ViewModel と View の間のメッセージを仲介します。
	/// </summary>
	public class Messenger
	{
		// ------------------------------------------------------------------------------------------------------------
		#region コンストラクタ

		/// <summary>
		/// Messenger クラスの新しいインスタンスを作成します。
		/// </summary>
		public Messenger()
		{
		}

		/// <summary>
		/// 扱うメッセージの型のコレクションを使用して、 Messenger クラスの新しいインスタンスを作成します。
		/// </summary>
		/// <param name="types">メッセージの型のコレクションを指定します。</param>
		public Messenger(IEnumerable<Type> types)
		{
			this.FTypeList.AddRange(types);
		}

		#endregion コンストラクタ
		// ------------------------------------------------------------------------------------------------------------

		/// <summary>
		/// メッセージに対応する処理のリスト を管理します。
		/// </summary>
		private Dictionary<Type, Action<object>> FActionDictionary = new Dictionary<Type, Action<object>>();

		/// <summary>
		/// 扱うメッセージの種類を管理します。
		/// </summary>
		private List<Type> FTypeList = new List<Type>();

		/// <summary>
		/// 扱うメッセージの種類を登録します。
		/// </summary>
		/// <param name="type">登録するメッセージの型を指定します。</param>
		public void AddMessageType(Type type)
		{
			this.FTypeList.Add(type);
		}

		/// <summary>
		/// メッセージに対応する処理を登録します。
		/// </summary>
		/// <param name="action">メッセージを受け取った時に実行する処理を指定します。</param>
		public void Register(Action<object> action)
		{
			foreach (var type in this.FTypeList)
			{
				if (!this.FActionDictionary.ContainsKey(type))
				{
					this.FActionDictionary.Add(type, action);
				}
			}
		}

		/// <summary>
		/// メッセージを送信します。
		/// </summary>
		/// <param name="message">送信するメッセージを指定します。</param>
		public void Send(object message)
		{
			if (Application.Current != null)
			{
				var dispatcher = Application.Current.Dispatcher;
				if (dispatcher.CheckAccess())
				{
					var action = this.FActionDictionary[message.GetType()] as Action<object>;
					if (action != null)
					{
						action(message);
					}
				}
				else
				{
					dispatcher.Invoke(() => this.Send(message));
				}
			}
		}

		/// <summary>
		/// メッセージを非同期で送信します。
		/// </summary>
		/// <param name="message">送信するメッセージを指定します。</param>
		public void SendAsync(object message)
		{
			if (Application.Current != null)
			{
				var dispatcher = Application.Current.Dispatcher;
				if (dispatcher.CheckAccess())
				{
					Task.Run(() =>
					{
						this.Send(message);
					});
				}
				else
				{
					dispatcher.InvokeAsync(() => this.Send(message));
				}
			}
		}
	}
}
