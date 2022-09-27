# Services

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
