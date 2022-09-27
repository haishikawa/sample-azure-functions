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


 # ディレクトリ構成
本案件のAzureFunctionsのディレクト構成は以下の通りである。

| ProjectRootDir/<br>　├Properties/<br>　├Attributes/ <br>　├Clients/<br>　│　└IClients<br>　├Consts/<br>　├Exceptions/<br>　├Extensions/<br>　├Functions/<br>　├Handler/<br>　├Managers/<br>　├Models/<br>　│　├Entities/<br>　│　├Requests/<br>　│　├Response/<br>　│　└Settings/<br>　│　└Sections/<br>　├Repositories/<br>　│　└IRepositories/<br>　├Services/<br>　│　└IServices/<br>　├SqlDbContexts/<br>　│　└ISqlDbContexts/<br>　├AzukarishoFunctionsApi.csproj<br>　├host.json<br>　├local.settings.json<br>　├OpenApiConfigurationOptions.cs<br>　├SleepDurationProviders.cs<br>　└Startup.cs|
|--|

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

# Consts


定義クラスを実装する場合は、`Consts`ディレクトリ配下に以下のような静的なクラスを実装する。
```CSharp
namespace AzukarishoFunctionsApi.Consts
{
    internal static class SampleConsts
    {
        public const string SampleConst= "定義する文字列を記載";
    }
}
```

# Exceptions
## 作成方法
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

# Functions
## Functions実装方針
HttpTrigerのFunctionsを作成したい場合は、`Functions`ディレクトリ配下にAzure関数として作成する。
FunctionsクラスではAPIのメインとなる処理は実装せず、APIのリクエストやレスポンスを操作する処理を実装する。
※Serviceクラスでメインの実装は記述する。

## ファイル作成
Functionsを右クリックして`追加>新しいAzure関数`を選択
![image.png](/.attachments/image-b8698ae0-d597-4f13-a82d-d452fa374f76.png)

ファイル名を入力しAzure関数が選択されていることを確認し、追加ボタンを押下
![image.png](/.attachments/image-9420494b-d4bc-44bf-b771-e2bfa2f56f9a.png)

`Http trigger with OpenAPI`を選択し、Authentication levelを`Anonymous`に変更し追加ボタンを押下
![image.png](/.attachments/image-e2750ba9-1ad6-4d2c-a615-8a1c4ab7ac60.png)

## 共通クラス継承
作成したFunctionsには必ず`AbstractFunction`を継承させ、`IHttpContextAccessor`をコンストラクタでbaseクラスに渡す。
```CS
namespace AzukarishoFunctionsApi.Functions
{
    public class SampleFunction : AbstractFunction//AbstractFunctionを継承
    {
　　　　private readonly ILogger<RequiredAuthFunction> _logger;
　　　  public RequiredAuthFunction(ILogger<RequiredAuthFunction> log, IHttpContextAccessor httpContextAccessor):base(httpContextAccessor)
        {
```


## JWT認証
JWT認証が必要なFunctionを作成する場合は、以下のようにメソッドに`RequiredAuth`Attributeを追加する。
```CS
[RequiredAuth]//追加
[FunctionName("SampleFunction")]
[OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
[OpenApiSecurity("Bearer", SecuritySchemeType.Http, Name = "authorization", Scheme = OpenApiSecuritySchemeType.Bearer, In = OpenApiSecurityLocationType.Header, BearerFormat = "JWT")]
[OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
public async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
{
```
※OpenAPIでJWT認証を実施する場合はメソッドに以下を付与する。
```CS
[OpenApiSecurity("Bearer", SecuritySchemeType.Http, Name = "authorization", Scheme = OpenApiSecuritySchemeType.Bearer, In = OpenApiSecurityLocationType.Header, BearerFormat = "JWT")]
```

## ユーザーId取得
ユーザーIdをJWTから取得する場合は以下のように`HttpRequest`から取得する。
```CS
[RequiredAuth]
[FunctionName("GetMaster")]
[OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
[OpenApiSecurity("Bearer", SecuritySchemeType.Http, Name = "authorization", Scheme = OpenApiSecuritySchemeType.Bearer, In = OpenApiSecurityLocationType.Header, BearerFormat = "JWT")]
[OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
public async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
{
   var shokubanId = req.GetShokubanId();//職番IdをHttpRequestから取得
```

# Service

プロジェクトのサービスロジックを実装する場合は`IService`ディレクトリに`IService`インターフェースを継承したインターフェースを実装し、実装したインターフェースを継承したクラスを`Service`ディレクトリ配下に作成する。
例：
```CS
public interface ILoginService: IService
    {
        public Task<SampleSearchResponseModel> Login(string userId, string password);
    }
```
※`IService`を継承してあるインターフェースに関して、Startupで動的にDIを実施している。
```CS
var assembly = Assembly.GetExecutingAssembly();
foreach (var type in assembly.GetTypes().Where(mytype => mytype.GetInterfaces().Contains(typeof(IService)) && mytype.IsInterface))
            {
                var svc = assembly.GetTypes().First(mytype => mytype.GetInterfaces().Contains(type) && mytype.IsClass);
                services.AddScoped(type, svc);
            }
```
Serviceは各クライアントや各リポジトリのDIされたインスタンスを使用してサービスロジックを実装する。
例：クライアントを使用する場合
```CS
public class LoginService : ILoginService
    {
        private IHttpClient _httpClient;

        public LoginService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<SampleSearchResponseModel> Login(string userId, string password)
        {　
            //ユーザーIDを用いて会社コードを作成
            var kaishaCode = userId.Substring(2, 3); 
            return await _httpClient.SampleSearch(userId, kaishaCode, password); //クライアントのメソッドを使用
        }
    }
```
例：リポジトリを使用する場合
```CS
public class MasterService:IMasterService
    {
        private readonly IMGazoRepository _mGazoRepository;
        public MasterService(IMGazoRepository mGazoRepository) {
            _mGazoRepository = mGazoRepository;
        }

        public async Task<IEnumerable<MGazo>> GetAllMaster() {
            return await _mGazoRepository.Select();//リポジトリのメソッドを使用
        }
    }
```

# Repositories

データベースを操作する処理を実装する場合は、`IRepositories`ディレクトリに`IRepository`インターフェースを継承したインターフェースを実装し、実装したインターフェースを継承したクラスを`Repositories`ディレクトリ配下に作成する。
```CS
public interface IMGazoRepository: IRepository
    {
        public Task<IEnumerable<MGazo>> Select();
    }
```
※`IRepository`を継承してあるインターフェースに関して、Startupで動的にDIを実施している。
```CS
var assembly = Assembly.GetExecutingAssembly();
foreach (var type in assembly.GetTypes().Where(mytype => mytype.GetInterfaces().Contains(typeof(IRepository)) && mytype.IsInterface))
            {
                var repo = assembly.GetTypes().First(mytype => mytype.GetInterfaces().Contains(type) && mytype.IsClass);
                services.AddScoped(type, repo);
            }
```

リポジトリは`ISqlDbConnect`のDIされたインスタンスを使用してDBの操作を実施する。
例：
```CS
public class MGazoRepository:IMGazoRepository
    {
        private readonly ISqlDbConnect _sqlDbConnect;
        public MGazoRepository(ISqlDbConnect sqlDbConnect)
        {
            _sqlDbConnect = sqlDbConnect;
        }

        /// <summary>
        /// 画像マスタ取得
        /// </summary>
        /// <param name="documentCode"></param>
        /// <returns></returns>
        public async Task<IEnumerable<MGazo>> Select()
        {
            return await _sqlDbConnect.ExcuteQuery<IEnumerable<MGazo>>(() =>//ここでDBの操作実施
            {
                var mGazoList = _sqlDbConnect.Context.MGazos.Where(w=>!Convert.ToBoolean(w.IsDelete));
                
                return mGazoList.ToList();
            });
        }
    }
```


