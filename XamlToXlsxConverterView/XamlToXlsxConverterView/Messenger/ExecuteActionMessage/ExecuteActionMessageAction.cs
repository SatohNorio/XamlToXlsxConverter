using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace XamlToXlsxConverterView
{
	/// <summary>
	/// 設定された処理を実行します。
	/// </summary>
	public class ExecuteActionMessageAction : TriggerAction<DependencyObject>
	{
		// ------------------------------------------------------------------------------------------------------------
		#region TriggerActionクラス 抽象メソッドの実装

		/// <summary>
		/// トリガイベントを処理します。
		/// </summary>
		/// <param name="parameter">関連付けられたメッセージを指定します。</param>
		protected override void Invoke(object parameter)
		{
			var m = parameter as ExecuteActionMessage;
			if (m != null)
			{
				var act = m.ExecutingAction;
				if (act != null)
				{
					act();
				}
			}
		}

		#endregion TriggerActionクラス 抽象メソッドの実装
		// ------------------------------------------------------------------------------------------------------------
	}
}
