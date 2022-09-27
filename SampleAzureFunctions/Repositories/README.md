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
