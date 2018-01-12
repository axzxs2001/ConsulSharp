using System;
using System.Text;
using ConsulSharp;
using ConsulSharp.ACL;
using ConsulSharp.Agent;
using ConsulSharp.Agent.Check;
using ConsulSharp.Agent.Service;
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

        private static void EventManage()
        {
            throw new NotImplementedException();
        }

        private static void ACLManage()
        {
            throw new NotImplementedException();
        }

        private static void HealthManage()
        {
            throw new NotImplementedException();
        }

        private static void CatalogManage()
        {
            throw new NotImplementedException();
        }

        private static void AgentManage()
        {
            Console.WriteLine("1、Check  2、Service    按e退出");
            switch (Console.ReadLine())
            {
                case "1":
                    CheckManage();
                    break;
                case "2":                   
                    break;               
                case "e":
                    return;
            }
        }
        #region Check
        static void CheckManage()
        {
            while (true)
            {
                Console.WriteLine("1、List Checks   2、Register Check   3、Deregister Check    按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        ListChecks();
                        break;
                    case "2":
                        RegisterCheck();
                        break;
                    case "3":
                        DeregisterCheck();
                        break;
                    case "4":

                        break;
                    case "e":
                        return;
                }
            }
        }

        /// <summary>
        /// List Checks
        /// </summary>
        static void ListChecks()
        {
            var agentGovern = new AgentGovern();
            var list = agentGovern.ListChecks().GetAwaiter().GetResult();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key}");
                Console.WriteLine(EntityToString(item.Value));
                Console.WriteLine("-----------------------------------------------");
            }
        }
        /// <summary>
        /// Register Check
        /// </summary>
        static void RegisterCheck()
        {
            var agentGovern = new AgentGovern();
            var registerCheck = new RegisterCheckParmeter()
            {
                ID = "test001",
                Name = "test" + DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Interval = "10s",
                HTTP = "https://example.com",
                Method = "POST",
            };

            var result = agentGovern.RegisterCheck(registerCheck).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
        /// <summary>
        /// Deregister Check
        /// </summary>
        static void DeregisterCheck()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.DeregisterCheck("test001").GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
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
