using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamlToXlsxConverterView
{
	/// <summary>
	/// 任意の処理を実行するコマンドを定義します。
	/// </summary>
	public class DelegateCommand : CommandBase
	{
		// ------------------------------------------------------------------------------------------------------------
		#region コンストラクタ

		/// <summary>
		/// DelegateCommand クラスの新しいインスタンスを作成します。
		/// </summary>
		/// <param name="execute">実行する処理を指定します。</param>
		public DelegateCommand(Action execute) : this(execute, () => true)
		{
		}

		/// <summary>
		/// DelegateCommand クラスの新しいインスタンスを作成します。
		/// </summary>
		/// <param name="execute">実行する処理を指定します。</param>
		/// <param name="canExecute">コマンドが実行可能か判定する処理を指定します。</param>
		public DelegateCommand(Action execute, Func<bool> canExecute)
		{
			this.ExecutingAction = execute;
			this.CanExecuteAction = canExecute;
		}

		#endregion コンストラクタ
		// ------------------------------------------------------------------------------------------------------------
		#region プロパティ

		/// <summary>
		/// 実行するアクション を取得または設定します。
		/// </summary>
		public Action ExecutingAction { get; set; }

		/// <summary>
		/// コマンドを実行してい良いか判断するアクション を取得または設定します。
		/// </summary>
		public Func<bool> CanExecuteAction { get; set; }

		#endregion プロパティ
		// ------------------------------------------------------------------------------------------------------------
		#region CommandBase 抽象クラスの実装

		/// <summary>
		/// コマンドが実行可能かどうか判定します。
		/// </summary>
		/// <param name="parameter">コマンドで使用するパラメータを指定します。</param>
		/// <returns>コマンドが実行可能ならば true を返します。</returns>
		protected override bool OnCanExecute(object parameter)
		{
			return this.CanExecuteAction();
		}

		/// <summary>
		/// コマンドを実行します。
		/// </summary>
		/// <param name="parameter">コマンドで使用するパラメータを指定します。</param>
		protected override void OnExecute(object parameter)
		{
			this.ExecutingAction();
		}

		#endregion CommandBase 抽象クラスの実装
		// ------------------------------------------------------------------------------------------------------------
	}

	/// <summary>
	/// パラメータ付きの任意の処理を実行するコマンドを定義します。
	/// </summary>
	/// <typeparam name="T">コマンドに渡すパラメータの型を指定します。</typeparam>
	public class DelegateCommand<T> : CommandBase
	{
		// ------------------------------------------------------------------------------------------------------------
		#region コンストラクタ

		/// <summary>
		/// DelegateCommand クラスの新しいインスタンスを作成します。
		/// </summary>
		/// <param name="execute">実行する処理を指定します。</param>
		public DelegateCommand(Action<T> execute) : this(execute, (p) => true)
		{
		}

		/// <summary>
		/// DelegateCommand クラスの新しいインスタンスを作成します。
		/// </summary>
		/// <param name="execute">実行する処理を指定します。</param>
		/// <param name="canExecute">コマンドが実行可能か判定する処理を指定します。</param>
		public DelegateCommand(Action<T> execute, Func<T, bool> canExecute)
		{
			this.ExecutingAction = execute;
			this.CanExecuteAction = canExecute;
		}

		#endregion コンストラクタ
		// ------------------------------------------------------------------------------------------------------------
		#region プロパティ

		/// <summary>
		/// 実行するアクション を取得または設定します。
		/// </summary>
		public Action<T> ExecutingAction { get; set; }

		/// <summary>
		/// コマンドを実行してい良いか判断するアクション を取得または設定します。
		/// </summary>
		public Func<T, bool> CanExecuteAction { get; set; }

		#endregion プロパティ
		// ------------------------------------------------------------------------------------------------------------
		#region CommandBase 抽象クラスの実装

		/// <summary>
		/// コマンドが実行可能かどうか判定します。
		/// </summary>
		/// <param name="parameter">コマンドで使用するパラメータを指定します。</param>
		/// <returns>コマンドが実行可能ならば true を返します。</returns>
		protected override bool OnCanExecute(object parameter)
		{
			T p = default(T);
			if (parameter != null)
			{
				p = (T)parameter;
			}
			return this.CanExecuteAction(p);
		}

		/// <summary>
		/// コマンドを実行します。
		/// </summary>
		/// <param name="parameter">コマンドで使用するパラメータを指定します。</param>
		protected override void OnExecute(object parameter)
		{
			T p = default(T);
			if (parameter != null)
			{
				p = (T)parameter;
			}
			this.ExecutingAction(p);
		}

		#endregion CommandBase 抽象クラスの実装
		// ------------------------------------------------------------------------------------------------------------
	}
}
