# Extensions

 モデルの拡張クラスを作成する場合は`Extensions`ディレクト配下に静的なクラスを作成し、以下のように静的なメソッドの引数に拡張したいクラスを定義すること。
```CS
namespace AzukarishoFunctionsApi.Extensions
{
    public static class SampleExtension
    {
        public static IEnumerable<string> GetCollection(this string str) //拡張したいモデルをthisを付けて引数に定義
 　　　　　　=> str?.Split($", ").ToList().Select(x => x.Trim()) ?? Array.Empty<string>();
    }
}
```
