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
## 使用例
### 例外作成
```CS
try
{
　//例外が発生しそうな処理
}
catch(Exception e)
{
   throw new SampleException(e);
}
```

### 例外取得(FunctionExceptionFilterの場合)
```CS
if (exceptionContext.Exception.InnerException is SampleException ex)
{
  　//例外取得時の処理
}
```

### 例外取得(try catchの場合)
```CS
try
{
　//例外が発生しそうな処理
}
catch(SampleException e)//必ずExceptionよりも前で例外を記載すること
{
   //SampleExceptionの例外処理 
}
catch(Exception e)
{
  //Exceptionの例外処理
}
```
