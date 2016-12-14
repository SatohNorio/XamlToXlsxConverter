using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamlToXlsxConverterView
{
	/// <summary>
	/// コマンドを作成するファクトリクラスを定義します。
	/// </summary>
	public class CommandFactory
	{
		/// <summary>
		/// 常に実行可能なパラメータ無しの処理を指定するコマンドを作成します。
		/// </summary>
		/// <param name="execute">実行する処理を指定します。</param>
		/// <returns>作成したコマンドを返します。</returns>
		public static ICommand Create(Action execute)
		{
			return new DelegateCommand(execute);
		}

		/// <summary>
		/// パラメータ無しの処理を実行するコマンドを作成します。
		/// </summary>
		/// <param name="execute">実行する処理を指定します。</param>
		/// <param name="canExecute">コマンドの実行可能状態を判定する処理を指定します。</param>
		/// <returns>作成したコマンドを返します。</returns>
		public static ICommand Create(Action execute, Func<bool> canExecute)
		{
			return new DelegateCommand(execute, canExecute);
		}

		/// <summary>
		/// 常に実行可能な処理を指定するコマンドを作成します。
		/// </summary>
		/// <param name="execute">実行する処理を指定します。</param>
		/// <returns>作成したコマンドを返します。</returns>
		public static ICommand Create<T>(Action<T> execute)
		{
			return new DelegateCommand<T>(execute);
		}

		/// <summary>
		/// 任意の処理を実行するコマンドを作成します。
		/// </summary>
		/// <param name="execute">実行する処理を指定します。</param>
		/// <param name="canExecute">コマンドの実行可能状態を判定する処理を指定します。</param>
		/// <returns>作成したコマンドを返します。</returns>
		public static ICommand Create<T>(Action<T> execute, Func<T, bool> canExecute)
		{
			return new DelegateCommand<T>(execute, canExecute);
		}
	}
}
