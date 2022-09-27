# Clients
1. Clientのクラスを実装する場合は`IClients`ディレクトリにインターフェースを実装し、実装したインターフェースを継承したクラスを`Clients`ディレクトリ配下に作成する。
```CS
 public interface IHttpClient
    {
        public Task<SampleSearchResponseModel> SampleSearch(string userId, string kaishaCode, string password);
    }
```
1. 作成後、StartupクラスでDIを実施する。
※基本的にAddScopedでDIする。
1. Clientクラスは利用するクラスのコンストラクタでから取得する。

※ClientのDIはオプションを設定したり、Configクラスに依存する可能性から動的にDIを実施しない。
