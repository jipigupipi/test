using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Server.Core.Data;

namespace Demo
{
    public class DemoWrapper :DbClientWrapper
    {
        /// <summary>
        /// 写入相关命令的默认超时时间（单位：毫秒）。
        /// </summary>
        public int DefaultWriteTimeout { get; set; }

        /// <inheritdoc />
        public DemoWrapper(IDbClient client) : base(client)
        {
        }

        public override int Execute(string sql, IEnumerable<DbParameter> parameters = null,
            CommandType commandType = CommandType.Text, int timeOut = 0)
        {
            return base.Execute(sql, parameters, commandType, DefaultWriteTimeout);
        }

        public override void SizedExecute(int expectedSize, string sql, IEnumerable<DbParameter> parameters = null,
            CommandType commandType = CommandType.Text, int timeOut = 0)
        {
            base.SizedExecute(expectedSize, sql, parameters, commandType, DefaultWriteTimeout);
        }

        public override Task<int> ExecuteAsync(string sql, IEnumerable<DbParameter> parameters = null,
            CommandType commandType = CommandType.Text, int timeout = 0)
        {
            return base.ExecuteAsync(sql, parameters, commandType, DefaultWriteTimeout);
        }

        public override Task SizedExecuteAsync(int expectedSize, string sql, IEnumerable<DbParameter> parameters = null,
            CommandType commandType = CommandType.Text, int timeout = 0)
        {
            return base.SizedExecuteAsync(expectedSize, sql, parameters, commandType, DefaultWriteTimeout);
        }
    }
}
