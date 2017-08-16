using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Help.Http
{
    /// <summary>
    /// Http请求参考类 
    /// </summary>
    public class HttpItem
    {
        /// <summary>
        /// 请求URL必须填写 
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// 请求方式默认为GET方式,当为POST方式时必须设置Postdata的值
        /// </summary>
        string _Method = "GET";

        public string Method
        {
            get { return _Method; }
            set { _Method = value; }
        }

        /// <summary>
        /// 默认请求超时时间  
        /// </summary>
        int _Timeout = 100000;

        public int Timeout
        {
            get { return _Timeout; }
            set { _Timeout = value; }
        }

        /// <summary>
        /// 默认写入Post数据超时间
        /// </summary>
        int _ReadWriteTimeout = 30000;

        public int ReadWriteTimeout
        {
            get { return _ReadWriteTimeout; }
            set { _ReadWriteTimeout = value; }
        }

        /// <summary>
        /// 设置Host的标头信息  
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否与 Internet 资源建立持久性连接默认为true。  
        /// </summary>
        Boolean _KeepAlive = true;

        public Boolean KeepAlive
        {
            get { return _KeepAlive; }
            set { _KeepAlive = value; }
        }

        /// <summary>
        /// 请求标头值 默认为text/html, application/xhtml+xml, */*  
        /// </summary>
        string _Accept = "text/html, application/xhtml+xml, */*";

        public string Accept
        {
            get { return _Accept; }
            set { _Accept = value; }
        }

        /// <summary>
        /// 请求返回类型默认 text/html  
        /// </summary>
        string _ContentType = "text/html";

        public string ContentType
        {
            get { return _ContentType; }
            set { _ContentType = value; }
        }

        /// <summary>
        /// 客户端访问信息默认Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)
        /// </summary>
        string _UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";

        public string UserAgent
        {
            get { return _UserAgent; }
            set { _UserAgent = value; }
        }

        /// <summary>
        /// 返回数据编码默认为NUll,可以自动识别,一般为utf-8,gbk,gb2312
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// Post的数据类型
        /// </summary>
        private PostDataType _PostDataType = PostDataType.String;

        public PostDataType PostDataType
        {
            get { return _PostDataType; }
            set { _PostDataType = value; }
        }

        /// <summary>
        /// Post请求时要发送的字符串Post数据
        /// </summary>
        public string PostData { get; set; }

        /// <summary>
        /// Post请求时要发送的Byte类型的Post数据
        /// </summary>
        public byte[] PostDataByte { get; set; }

        /// <summary>
        /// Cookie对象集合
        /// </summary>
        public CookieCollection CookieCollection { get; set; }

        /// <summary>
        /// 请求时的Cookie
        /// </summary>
        public string Cookie { get; set; }

        /// <summary>
        /// 来源地址，上次访问地址
        /// </summary>
        public string Referer { get; set; }

        /// <summary>
        /// 证书绝对路径
        /// </summary>
        public string CerPath { get; set; }

        /// <summary>
        /// 设置代理对象，不想使用IE默认配置就设置为Null，而且不要设置ProxyIp
        /// </summary>
        public WebProxy WebProxy { get; set; }

        /// <summary>
        /// 是否设置为全文小写，默认为不转化 
        /// </summary>
        private Boolean isToLower = false;

        public Boolean IsToLower
        {
            get { return isToLower; }
            set { isToLower = value; }
        }

        /// <summary>
        /// 支持跳转页面，查询结果将是跳转后的页面，默认是不跳转 
        /// </summary>
        private Boolean allowautoredirect = false;

        public Boolean Allowautoredirect
        {
            get { return allowautoredirect; }
            set { allowautoredirect = value; }
        }

        /// <summary>
        /// 最大连接数
        /// </summary>
        private int connectionlimit = 1024;

        public int Connectionlimit
        {
            get { return connectionlimit; }
            set { connectionlimit = value; }
        }

        /// <summary>
        /// 代理Proxy 服务器用户名
        /// </summary>
        public string ProxyUserName { get; set; }

        /// <summary>
        /// 代理 服务器密码
        /// </summary>
        public string ProxyPwd { get; set; }

        /// <summary>
        /// 代理 服务IP,如果要使用IE代理就设置为ieproxy  
        /// </summary>
        public string ProxyIp { get; set; }

        /// <summary>
        /// 设置返回类型String和Byte  
        /// </summary>
        private ResultType resulttype = ResultType.String;

        public ResultType ResultType
        {
            get { return resulttype; }
            set { resulttype = value; }
        }

        /// <summary>
        /// header对象
        /// </summary>
        private WebHeaderCollection header = new WebHeaderCollection();

        public WebHeaderCollection Header
        {
            get { return header; }
            set { header = value; }
        }

        /// <summary>
        /// 获取或设置用于请求的 HTTP 版本。返回结果:用于请求的 HTTP 版本。默认为 System.Net.HttpVersion.Version11。
        /// </summary>
        public Version ProtocolVersion { get; set; }

        /// <summary>
        /// 获取或设置一个 System.Boolean 值，该值确定是否使用 100-Continue 行为。如果 POST 请求需要 100-Continue 响应，则为 true；否则为 false。默认值为 false。
        /// </summary>
        private Boolean _expect100continue = false;

        public Boolean Expect100Continue
        {
            get { return _expect100continue; }
            set { _expect100continue = value; }
        }

        /// <summary>
        /// 设置509证书集合
        /// </summary>
        public X509CertificateCollection ClentCertificates { get; set; }

        /// <summary>
        /// 设置或获取Post参数编码,默认的为Default编码 
        /// </summary>
        public Encoding PostEncoding { get; set; }

        /// <summary>
        /// Cookie返回类型,默认的是只返回字符串类型
        /// </summary>
        private ResultCookieType _ResultCookieType = ResultCookieType.String;

        public ResultCookieType ResultCookieType
        {
            get { return _ResultCookieType; }
            set { _ResultCookieType = value; }
        }

        /// <summary>
        /// 获取或设置请求的身份验证信息。
        /// </summary>
        private ICredentials _ICredentials = CredentialCache.DefaultCredentials;

        public ICredentials ICredentials
        {
            get { return _ICredentials; }
            set { _ICredentials = value; }
        }

        /// <summary>
        /// 设置请求将跟随的重定向的最大数目  
        /// </summary>
        public int MaximumAutomaticRedirections { get; set; }

        /// <summary>
        /// 获取和设置IfModifiedSince，默认为当前日期和时间
        /// </summary>
        private DateTime? _IfModifiedSince = null;

        public DateTime? IfModifiedSince
        {
            get { return _IfModifiedSince; }
            set { _IfModifiedSince = value; }
        }

        /// <summary>
        /// 设置本地的出口ip和端口 
        /// </summary>
        /// <example>  
        ///item.IPEndPoint = new IPEndPoint(IPAddress.Parse("192.168.1.1"),80);  
        /// </example>  
        private IPEndPoint _IPEndPoint = null;

        public IPEndPoint IPEndPoint
        {
            get { return _IPEndPoint; }
            set { _IPEndPoint = value; }
        }
    }
}
