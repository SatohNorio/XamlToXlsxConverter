using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamlToXlsxConverterView;

namespace XamlToXlsxConverter
{
	class XamlToXlsxConverterViewModel : XamlToXlsxConverterViewModelBase
	{
		// ------------------------------------------------------------------------------------------------------------
		#region 仮想メソッドの上書き

		/// <summary>
		/// Xaml から Xlsx ファイルに変換します。
		/// </summary>
		protected override void StartConvert()
		{
		}

		/// <summary>
		/// ファイル選択ダイアログを表示して処理するファイルを選択します。
		/// </summary>
		/// <returns>取得したファイルのパスを返します。</returns>
		private string SelectFile()
		{
			return "";
		}

		#endregion 仮想メソッドの上書き
		// ------------------------------------------------------------------------------------------------------------
	}
}
