namespace Demo
{
    /// <summary>
    /// 存放一些静态的配置信息。
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// 缓存命名空间
        /// </summary>
        public const string CacheNamespace = "Demo";

        /// <summary>
        /// 用于GameApi加解密的Key。
        /// </summary>
        public static readonly byte[] NmsKey = { 0xFD, 0xF8, 0x4F, 0xFE, 0xF1, 0xE5, 0x1F, 0xDF };

        /// <summary>
        /// 用于OpenApi加密校验的AppKey。
        /// </summary>
        public static string AppKey = "dev";

        /// <summary>
        /// 用于OpenApi加密校验的AppSecret。
        /// </summary>
        public static string AppSecret = "dev";


        /// <summary>
        /// 用于NmsSdk验证身份的的ClientId。
        /// </summary>
        public static string ClientId = "dev";

        /// <summary>
        /// 用于NmsSdk验证身份的的ClientSecret。
        /// </summary>
        public static string ClientSecret = "7b2e7fc81cae4637bd3e8bdd9b3ceedc";
    }
}
