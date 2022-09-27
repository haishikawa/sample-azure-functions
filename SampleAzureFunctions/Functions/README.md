# Functions
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
