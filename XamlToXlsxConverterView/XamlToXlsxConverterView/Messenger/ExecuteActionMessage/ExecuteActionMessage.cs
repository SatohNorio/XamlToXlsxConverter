using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlToXlsxConverterView
{
	/// <summary>
	/// 設定されたアクションを実行するメッセージを定義します。
	/// </summary>
	public class ExecuteActionMessage
	{
		// ------------------------------------------------------------------------------------------------------------
		#region コンストラクタ

		/// <summary>
		/// XamlToXlsxConverterViewModelBase クラスの新しいインスタンスを作成します。
		/// </summary>
		public ExecuteActionMessage()
		{
		}

		/// <summary>
		/// XamlToXlsxConverterViewModelBase クラスの新しいインスタンスを作成します。
		/// </summary>
		/// <param name="action">実行する処理を指定します。</param>
		public ExecuteActionMessage(Action action)
		{
			this.ExecutingAction = action;
		}

		#endregion コンストラクタ
		// ------------------------------------------------------------------------------------------------------------
		#region ExecutingAction プロパティ

		/// <summary>
		/// 実行するアクション を取得または設定します。
		/// </summary>
		public Action ExecutingAction { get; set; }

		#endregion ExecutingAction プロパティ
		// ------------------------------------------------------------------------------------------------------------
	}
}
