using Server.Core.Data;

namespace Demo
{
    public static class Db
    {
        private const int DefaultTimeout = 6;

        private const int DefaultWriteTimeout = 8;

        /// <summary>
        /// 简单的获取指定数据库的方式。需要在管理后台进行配置，才能通过这种方式拿到对应的数据库连接串。
        /// </summary>
        public static IDbClient DemoDb
            => DbClientPool.GetDbClient(DbClientType.SqlServer, "DemoDb");

        /// <summary>
        /// 带有指定超时时间的数据库连接对象。
        /// </summary>
        public static IDbClient DemoTimeOutDb => DbClientPool.GetDbClient(DbClientType.SqlServer, "DemoDb", TimeoutEnhancedDbClientFactory);


        /// <summary>
        /// 也可以通过连接串直接获取数据库连接对象。
        /// </summary>
        public static IDbClient DemoConnectStringDb => new SqlDbClient("server=localhost; database=Demo; User ID=sa;pwd=123456; connection reset=false;connection lifetime=5;min pool size=1;max pool size=1000");


        /// <summary>
        /// 创建带有默认的读写超时设定的 IDbClient。
        /// </summary>
        private static IDbClient TimeoutEnhancedDbClientFactory(DbIdentity dbId, string connectionString)
        {
            var client = DbClientPool.DefaultDbClientFactory(dbId, connectionString);

            // 尝试给定默认的超时，用于读取数据的方法（虽然也可能被用于写入）。
            if (client is AbstractDbClient clientBase)
            {
                clientBase.DefaultTimeout = DefaultTimeout;
            }

            // 封装一层，添加独立的写入超时设置。
            var clientWrapper = new DemoWrapper(client) { DefaultWriteTimeout = DefaultWriteTimeout };

            return clientWrapper;
        }
    }
}
