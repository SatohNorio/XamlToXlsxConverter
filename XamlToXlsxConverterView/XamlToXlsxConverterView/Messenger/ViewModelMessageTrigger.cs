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
	/// ViewModelMessage に対応した処理を起動するトリガーを定義します。
	/// </summary>
	public class ViewModelMessageTrigger : TriggerBase<FrameworkElement>
	{
		/// <summary>
		/// 要素にアタッチされた時に実行する処理を定義します。
		/// </summary>
		protected override void OnAttached()
		{
			base.OnAttached();
			this.RegisterAll();
		}

		/// <summary>
		/// 要素からデタッチされる時に実行する処理を定義します。
		/// </summary>
		protected override void OnDetaching()
		{
			base.OnDetaching();
		}

		// ------------------------------------------------------------------------------------------------------------
		#region SourceObject プロパティ（依存関係プロパティ）

		/// <summary>
		/// メッセージを管理するオブジェクト を取得または設定します。
		/// </summary>
		public Messenger SourceObject
		{
			get { return (Messenger)GetValue(SourceObjectProperty); }
			set { SetValue(SourceObjectProperty, value); }
		}

		/// <summary>
		/// メッセージを管理するオブジェクト を管理する依存関係プロパティ
		/// </summary>
		public static readonly DependencyProperty SourceObjectProperty =
			DependencyProperty.Register("SourceObject", typeof(Messenger), typeof(ViewModelMessageTrigger), new PropertyMetadata(null, ViewModelMessageTrigger.SourceObjectPropertyChanged));

		/// <summary>
		/// SourceObject プロパティの変更イベントを処理します。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void SourceObjectPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var trg = sender as ViewModelMessageTrigger;
			if (trg != null && trg.AssociatedObject != null)
			{
				trg.RegisterAll();
			}
		}

		/// <summary>
		/// メッセージに対応する処理をメッセンジャーに登録します。
		/// </summary>
		public void RegisterAll()
		{
			var m = this.SourceObject;
			if (m != null)
			{
				m.Register((msg) => this.InvokeActions(msg));
			}
		}

		#endregion SourceObject プロパティ
		// ------------------------------------------------------------------------------------------------------------
	}
}
