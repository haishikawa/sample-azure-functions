
# Attributes

Attributeを作成する場合はその利用方法によって以下の二つから作成する。

## １.汎用的に使用するFilterAttributeを作成する場合。
以下のように`FunctionInvocationFilterAttribute`を継承したクラスを`Attributes`ディレクトリに作成する。
```CSharp
namespace AzukarishoFunctionsApi.Attributes
{
    publicclass SampleAttribute : FunctionInvocationFilterAttribute
    {
        public override Task OnExecutingAsync(FunctionExecutingContext executingContext, CancellationToken cancellationToken)
        {
            //本Attributeが付与された、classまたはmethodが実行される前に実施する処理を実装
　　　　　　 return base.OnExecutingAsync(executingContext, cancellationToken);
        }
        public override Task OnExecutedAsync(FunctionExecutedContext executedContext, CancellationToken cancellationToken)
        {
            ////本Attributeが付与された、classまたはmethodが実行された後に実施する処理を実装

            return base.OnExecutedAsync(executedContext, cancellationToken);
        }
    }
}
```

## ２.エラーをハンドリングするFilterAttributeを作成する場合。
以下のように`IFunctionExceptionFilter`を継承したクラスを`Attributes`ディレクトリに作成する。
```CSharp
namespace AzukarishoFunctionsApi.Functions
{
    public class ErrorHandlerAttribute : FunctionExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(FunctionExceptionContext exceptionContext, CancellationToken cancellationToken)
        {
             //本Attributeが付与されたclassまたはmethodの例外catch処理を実装
             return Task.CompletedTask;
        }
    }
}
```
