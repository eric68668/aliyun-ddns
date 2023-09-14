using aliyun_ddns.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace aliyun_ddns.IPGetter.IPv4Getter
{
    public static class IPv4GetterCreator
    {
        private static readonly IEnumerable<IIPv4Getter> _definedGetters = new CommonIPv4Getter[]
            {
                new CommonIPv4Getter("3322接口", "http://ip.3322.net/"),
                new CommonIPv4Getter("3322接口2", "http://members.3322.org/dyndns/getip"),
                new CommonIPv4Getter("Oray接口", "http://ddns.oray.com/checkip"),
                new CommonIPv4Getter("浙大接口", "http://speedtest.zju.edu.cn/getIP.php"),
                new CommonIPv4Getter("CloudflareCN接口", "https://www.cloudflare-cn.com/cdn-cgi/trace"),
            };

        public static IEnumerable<IIPv4Getter> Create()
        {
            List<IIPv4Getter> getters = new List<IIPv4Getter>();
            if (Options.Instance.CheckLocalNetworkAdaptor)
            {
                getters.Add(new LocalIPv4Getter());
            }
            else
            {
                getters.AddRange(InstanceCreator.Create<IIPv4Getter>(Ignore.CheckType));
                getters.AddRange(_definedGetters);
            }

            return getters;
        }
    }
}
