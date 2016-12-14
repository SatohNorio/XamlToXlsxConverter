using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XamlToXlsxConverter;

namespace UnitTestProject
{
	/// <summary>
	/// 単体テストを定義します。
	/// </summary>
	[TestClass]
	public class UnitTest
	{
		/// <summary>
		/// テストプロジェクトの初期化処理を行います。
		/// </summary>
		/// <param name="context">テストで使用するコンテキストを指定します。</param>
		[AssemblyInitialize]
		public static void AssemblyInitialize(TestContext context)
		{
		}

		/// <summary>
		/// テストクラスの初期化処理を行います。
		/// </summary>
		[ClassInitialize]
		/// <param name="context">テストで使用するコンテキストを指定します。</param>
		public static void ClassInitialize(TestContext context)
		{

		}

		/// <summary>
		/// テストクラスの終了処理を行います。
		/// </summary>
		[ClassCleanup]
		public static void ClassCleanup()
		{

		}

		/// <summary>
		/// テストプロジェクトの終了処理を行います。
		/// </summary>
		[AssemblyCleanup]
		public static void AssemblyCleanup()
		{

		}

		[TestMethod]
		public void A001SelectFileTest()
		{
			var vm = new XamlToXlsxConverterViewModel();
			string s = vm.AsDynamic().SelectFile();
			s.Is(x => x == "");
		}
	}
}
