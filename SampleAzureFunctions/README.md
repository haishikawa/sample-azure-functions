# 開発環境

<table>
    <tr>
      <td>開発言語</td>
      <td>C＃</td>
    </tr>
    <tr>
      <td>IDE </td>
      <td> Visual Studio 2022</td>
    </tr>
<tr>
      <td>ソリューション </td>
      <td> Azure Functions</td>
    </tr>
<tr>
      <td>フレームワーク </td>
      <td> .NET6.0</td>
    </tr>
<tr>
      <td>パッケージ </td>
      <td> Azure.Identity<br>Azure.Security.KeyVault.Secrets<br>JWT<br>Microsoft.ApplicationInsights<br>Microsoft.Azure.Functions.Extensions<br>Microsoft.Azure.WebJobs.Extensions.OpenApi<br>Microsoft.EntityFrameworkCore<br>Microsoft.EntityFrameworkCore.Design<br>Microsoft.EntityFrameworkCore.SqlServer<br>Microsoft.EntityFrameworkCore.Tools<br>Microsoft.Extensions.Caching.Abstractions<br>Microsoft.Extensions.Http<br>Microsoft.Extensions.Http.Polly<br>Microsoft.NET.Sdk.Functions<br>Polly<br>Polly.Extensions.Http</td>
    </tr>
 </table>

# ディレクトリの概要
|ディレクトリ名|概要|
|--|--|
|Properties|プロジェクトのローカル実行環境の設定ファイル系を配置。<br>ローカル実行時のポート番号等設定変更はここをいじる|
|Attributes|attribute系のクラスを配置。|
|Clients|HttpやKeyVault、BlobStorageなどのクライアントを配置。|
|IClients|クライアントのインターフェースを配置。|
|Consts|定義クラスを配置。|
|Exceptions|例外の拡張クラスを配置。|
|Extensions|各モデルの拡張クラスを配置。|
|Functions|HttpTrigerのFunctionsを配置。<br>※一般的なコントローラーは作成せず、1ファイル：1APIで作成する。|
|Handler|エラーのハンドラーを配置。|
|Managers|各マネージャークラスを配置(静的クラスでメソッドを管理するイメージ)。<br>※クライアントと違ってDIは実施しないクラスを配置する。|
|Models|モデルクラスのルートディレクトリ。|
|Entities|DBのエンティティモデルクラスを配置。|
|Requests|Httpのリクエストクラスを配置。|
|Response|Httpのレスポンスクラスを配置。|
|Settings|コンフィグファイル等の設定モデルクラスを配置。|
|Sections|セクションを用いて値を取得する設定モデルクラスを配置。|
|Repositories|DB操作クラスを配置。|
|IRepositories|DB操作クラスのインターフェースを配置。|
|Services|APIのサービスクラスを配置。|
|IServices|サービスクラスのインターフェースを配置。|
|SqlDbContexts|SqlDbのコンテキストクラスを配置。|
|ISqlDbContexts|コンテキストクラスのインターフェースを配置。|

