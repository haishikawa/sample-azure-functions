# Exceptions
Exceptionの拡張クラスを作成する場合は`Exceptions`ディレクトリの配下に以下のように`System.Exception`を継承したクラスを作成する。
```CS
namespace AzukarishoFunctionsApi.Exceptions
{
    internal class SampleException:Exception
    {
        /// <summary>
        /// 【SampleException(new Exception())】のような使い方は禁止。
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public SampleException(Exception innerException) : base(innerException.Message, innerException)
        {
        }
    }
}
```
