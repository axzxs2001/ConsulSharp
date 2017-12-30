using System;
using System.Text;
using ConsulSharp;
using ConsulSharp.ACL;
using ConsulSharp.Event;
namespace ConsulSharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1、Agent  2、Catalog  3、Health 4、ACL  5、Event  按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        AgentManage();
                        break;
                    case "2":
                        CatalogManage();
                        break;
                    case "3":
                        HealthManage();
                        break;
                    case "4":
                        ACLManage();
                        break;
                    case "5":
                        EventManage();
                        break;
                    case "e":
                        return;
                }
            }
        }
        #region Event
        static void EventManage()
        {
            while (true)
            {
                Console.WriteLine("1、Fire Event  2、List Events   按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        FireEvent();
                        break;
                    case "2":
                        ListEvents();
                        break;
                    case "e":
                        return;
                }
            }
        }
        static void FireEvent()
        {
            try
            {
                var eve = new EventGovern();
                var result = eve.FireEvent(new FireEventParmeter { Name = "deploy", DC = "dc1", Node = "", Service = "" }).GetAwaiter().GetResult();
                Console.WriteLine(result.result);
                Console.WriteLine(EntityToString(result.fireEvent));
            }
            catch (Exception exc)
            {
                Console.WriteLine($"错误:{exc.Message}");
            }
        }
        static void ListEvents()
        {
            try
            {
                var eve = new EventGovern();
                var result = eve.EventList(new ListEventParmeter { Name = "deploy" }).GetAwaiter().GetResult();
                foreach (var env in result)
                {
                    Console.WriteLine(EntityToString(env));
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"错误:{exc.Message}");
            }
        }
        #endregion
        #region ACL
        static void ACLManage()
        {
            while (true)
            {
                Console.WriteLine("1、BootstrapACLs  2、CreateACLToken 3、ReadACLToken   按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        BootstrapACL();
                        break;
                    case "2":
                        CreateACLToken();
                        break;
                    case "3":
                        ReadACLToken();
                        break;
                    case "e":
                        return;
                }
            }
        }

        static void BootstrapACL()
        {
            try
            {
                var acl = new ACLGovern();
                var result = acl.BootstrapACLs().GetAwaiter().GetResult();
                Console.WriteLine(result.result);
                Console.WriteLine(result.backBootstrapACLs.ID);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"错误:{exc.Message}");
            }
        }

        static void CreateACLToken()
        {
            try
            {
                var acl = new ACLGovern();
                var result = acl.CreateACLToken(new ACLTokenParmeter { ID = "acl001", Name = "dc1", Rules = "", Type = "management" }).GetAwaiter().GetResult();
                Console.WriteLine(result.result);
                Console.WriteLine(result.backBootstrapACLs.ID);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"错误:{exc.Message}");
            }
        }

        static void ReadACLToken()
        {
            try
            {
                var acl = new ACLGovern();
                var result = acl.ReadACLToken("0f738123-28ee-4a6d-bd22-8648f99ffdc5").GetAwaiter().GetResult();
                foreach (var aclresult in result)
                {
                    Console.WriteLine(EntityToString(aclresult));
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"错误:{exc.Message}");
            }
        }
        #endregion


        #region Health管理
        /// <summary>
        /// Health查询
        /// </summary>
        static void HealthManage()
        {
            while (true)
            {
                Console.WriteLine("1、查询全部Catalog服务  2、按名称查Catalog服务  按e退出");
                switch (Console.ReadLine())
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "e":
                        return;
                }
            }
        }


        #endregion
        #region Catalog管理
        /// <summary>
        /// Catalog查询
        /// </summary>
        static void CatalogManage()
        {
            while (true)
            {
                Console.WriteLine("1、查询Catalog数据中心  2、查询Catalog的Nodes  3、按节点名称查询服务  4、查询全部Catalog服务  5、按名称查Catalog服务  6、注册catalog  7、注销catalog 按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        QueryCatalogDatacenters();
                        break;
                    case "2":
                        QueryCatalogNodes();
                        break;
                    case "3":
                        QueryCatalogNodeByName();
                        break;
                    case "4":
                        QueryCatalogServices();
                        break;
                    case "5":
                        QueryCatalogServiceByName();
                        break;
                    case "6":
                        RegisterCatalog();
                        break;
                    case "7":
                        DeregisterCatalog();
                        break;
                    case "e":
                        return;
                }
            }
        }
        /// <summary>
        /// 注册catalog
        /// </summary>
        private static void RegisterCatalog()
        {
            var catalog = new CatalogEntity();

            var serviceGovern = new CatalogGovern();
            var result = serviceGovern.RegisterCatalog(catalog).GetAwaiter().GetResult();
            Console.WriteLine(result.backJson);
            Console.WriteLine(result.result);
        }
        /// <summary>
        /// 反注册catalog
        /// </summary>
        private static void DeregisterCatalog()
        {
            var catalog = new DeCatalogEntity();
            var serviceGovern = new CatalogGovern();
            var result = serviceGovern.DeregisterCatalog(catalog).GetAwaiter().GetResult();
            Console.WriteLine(result.backJson);
            Console.WriteLine(result.result);
        }
        /// <summary>
        /// 查旬Catalog的数据中心
        /// </summary>
        private static void QueryCatalogDatacenters()
        {
            var serviceGovern = new CatalogGovern();
            var i = 1;
            foreach (var service in serviceGovern.CatalogDatacenters().GetAwaiter().GetResult())
            {
                Console.WriteLine($"{i++ }、{service}");
            }
        }
        /// <summary>
        /// 查旬Catalog的nodes
        /// </summary>
        private static void QueryCatalogNodes()
        {
            var serviceGovern = new CatalogGovern();
            var i = 1;
            foreach (var node in serviceGovern.CatalogNodes().GetAwaiter().GetResult())
            {
                Console.WriteLine($"{i++ }、{node.ID} {node.Node}  地址：{node.Address} 位于数据中心：{node.Datacenter}");
            }
        }
        /// <summary>
        /// 查旬Catalog的nodes
        /// </summary>
        private static void QueryCatalogNodeByName()
        {
            Console.WriteLine("请输入Node名称：");
            var nodeName = Console.ReadLine();
            var serviceGovern = new CatalogGovern();
            var i = 1;
            var node = serviceGovern.CatalogNodeByName(nodeName).GetAwaiter().GetResult();

            Console.WriteLine($"{i++ }、{node.Node.ID} {node.Node.Node}  地址：{node.Node.Address} 位于数据中心：{node.Node.Datacenter}");

            foreach (var service in node.Services)
            {
                Console.WriteLine($"{service.Key}  {service.Value.Service}:{service.Value.Port}");
            }

        }
        /// <summary>
        /// 查旬Catalog的服务 
        /// </summary>
        private static void QueryCatalogServices()
        {
            var serviceGovern = new CatalogGovern();
            var i = 1;
            foreach (var service in serviceGovern.CatalogServices().GetAwaiter().GetResult())
            {
                var content = new StringBuilder($"{i++ }、{service.Key}:");

                foreach (var value in service.Value)
                {
                    content.Append($"{value}，");
                }
                Console.WriteLine(content.ToString().TrimEnd('，'));
            }
        }

        /// <summary>
        /// 按服务名称查询Catalog服务
        /// </summary>
        private static void QueryCatalogServiceByName()
        {
            Console.WriteLine("请输入服务名称：");
            var serviceName = Console.ReadLine();
            var serviceGovern = new CatalogGovern();
            foreach (var service in serviceGovern.CatalogServiceByName(serviceName).GetAwaiter().GetResult())
            {
                Console.WriteLine($"Node:{service.Node }  服务名称：{service.ServiceName} 地址：{service.ServiceAddress}:{service.ServicePort}");
            }
        }

        #endregion

        #region agent管理
        /// <summary>
        /// 服务注册，注销
        /// </summary>
        static void AgentManage()
        {
            while (true)
            {
                Console.WriteLine("1、注册服务  2、注销服务  3、查看成员  4、日志    按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        RegisterService();
                        break;
                    case "2":
                        UnRegisterService();
                        break;
                    case "3":
                        QueryMembers();
                        break;
                    case "4":
                        StreamLog();
                        break;
                    case "e":
                        return;
                }
            }
        }
        /// <summary>
        /// 查询日志
        /// </summary>
        private static void StreamLog()
        {
            var agentGovern = new AgentGovern();
            agentGovern.WritLog += delegate (string log)
            {
                Console.WriteLine(log);
            };
            agentGovern.StreamLogs().GetAwaiter().GetResult();
        }



        /// <summary>
        /// 查询成员
        /// </summary>
        private static void QueryMembers()
        {
            var agentGovern = new AgentGovern();
            foreach (var member in agentGovern.Members().GetAwaiter().GetResult())
            {
                Console.WriteLine($"Name:{member.Name} 地址:{member.Addr}:{member.Port}");
            }
        }

        /// <summary>
        /// Deregister Service注销服务 
        /// </summary>
        private static void UnRegisterService()
        {
            var serviceGovern = new AgentGovern();
            var result = serviceGovern.DeregisterServices("newservice001").GetAwaiter().GetResult();
            Console.WriteLine(result.backJson);
            Console.WriteLine(result.result);

        }

        /// <summary>
        /// Register Service注册服务
        /// </summary>
        private static void RegisterService()
        {
            var service = new Service();
            service.ID = "newservice001";
            service.Name = "newservice001";
            service.Address = "192.168.1.110";
            service.Port = 5005;
            service.Checks = new HttpCheck[1];
            service.Checks[0] = new HttpCheck { ID = "check1", Name = "check1", Http = "http://192.168.1.110:5005/health", Interval = "10s" };
            service.Tags = new string[] { "newservice001" };

            var serviceGovern = new AgentGovern();
            var result = serviceGovern.RegisterServices(service).GetAwaiter().GetResult();
            Console.WriteLine(result.backJson);
            Console.WriteLine(result.result);

        }

        #endregion


        static string EntityToString(object obj)
        {
            var content = new StringBuilder("类型=" + obj.GetType().Name + "\r\n");
            foreach (var pro in obj.GetType().GetProperties())
            {
                content.AppendLine($"{pro.Name}:{pro.GetValue(obj, null)}");
            }
            return content.ToString();
        }
    }
}
