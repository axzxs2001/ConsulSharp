using System;
using System.Collections;
using System.Text;
using ConsulSharp;
using ConsulSharp.ACL;
using ConsulSharp.Agent;
using ConsulSharp.Agent.Check;
using ConsulSharp.Agent.Service;
using ConsulSharp.Catalog;
using ConsulSharp.Coordinates;
using ConsulSharp.Event;
using ConsulSharp.KV;

namespace ConsulSharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateLANCoordinatesForANode();
            while (true)
            {
                Console.WriteLine("1、ACL  2、Agent 3、Catalog  4、Coordinates  5、Event  6、Health  7、KV Store 8、Operator    按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        ACLManage();

                        break;
                    case "2":
                        AgentManage();

                        break;
                    case "3":
                        CatalogManage();

                        break;
                    case "4":
                        CoordinatesManage();
                        break;
                    case "5":
                        EventManage();
                        break;
                    case "6":
                        HealthManage();
                        break;
                    case "7":
                        KVStoreManage();
                        break;
                    case "8":

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
        private static void HealthManage()
        {
            throw new NotImplementedException();
        }

        #region Coordinates
        private static void CoordinatesManage()
        {
            while (true)
            {
                Console.WriteLine("1、Read WAN Coordinates  2、Read LAN Coordinates For All Nodes   3、Read LAN Coordinates for a node  4、Update LAN Coordinates For A Node  按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        ReadWANCoordinates();
                        break;
                    case "2":
                        ReadLANCoordinatesForAllNodes();
                        break;
                    case "3":
                        ReadLANCoordinatesForANode();
                        break;
                    case "4":
                        UpdateLANCoordinatesForANode();
                        break;

                    case "e":
                        return;
                }
            }
        }
        /// <summary>
        /// Read WAN Coordinates
        /// </summary>
        private static void ReadWANCoordinates()
        {
            var coordnatesGovern = new CoordnatesGovern();
            var result = coordnatesGovern.ReadWANCoordinates().GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }

        /// <summary>
        /// Read LAN Coordinates For All Nodes
        /// </summary>
        private static void ReadLANCoordinatesForAllNodes()
        {
            var coordnatesGovern = new CoordnatesGovern();
            var result = coordnatesGovern.ReadLANCoordinatesForAllNodes(new LANCoordinatesParmeter { DC = "dc1" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        /// <summary>
        /// Read LAN Coordinates For A Node
        /// </summary>
        private static void ReadLANCoordinatesForANode()
        {
            var coordnatesGovern = new CoordnatesGovern();
            var result = coordnatesGovern.ReadLANCoordinatesForANodes(new LANCoordinatesParmeter { DC = "dc1", Node = "n1" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }

        /// <summary>
        /// Update LAN Coordinates For A Node
        /// </summary>
        private static void UpdateLANCoordinatesForANode()
        {
            var coordnatesGovern = new CoordnatesGovern();
            var result = coordnatesGovern.UpdateLANCoordinatesForANode(new Coordinate { Node="n1" },"dc1").GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.lanCoordinates)}");
        }
        #endregion
        #region ACL
        private static void ACLManage()
        {
            while (true)
            {
                Console.WriteLine("1、Bootstrap ACLs  2、Create ACL Token   3、Update ACL Token  4、Delete ACL Token   5、Read ACL Token  6、Clone ACL Token   7、List ACLs  8、Check ACL Replication  按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        BootstrapACLs();
                        break;
                    case "2":
                        CreateACLToken();
                        break;
                    case "3":
                        UpdateACLToken();
                        break;
                    case "4":
                        DeleteACLToken();
                        break;
                    case "5":
                        ReadACLToken();
                        break;
                    case "6":
                        CloneACLToken();
                        break;
                    case "7":
                        ListACLs();
                        break;
                    case "8":
                        CheckACLReplication();
                        break;
                    case "e":
                        return;
                }
            }
        }
        /// <summary>
        /// Bootstrap ACLs
        /// </summary>
        private static void BootstrapACLs()
        {
            var aclGovern = new ACLGovern();
            var result = aclGovern.BootstrapACLs().GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.backBootstrapACLs)}");
        }
        /// <summary>
        /// Create ACL Token
        /// </summary>
        private static void CreateACLToken()
        {
            var aclGovern = new ACLGovern();
            var result = aclGovern.CreateACLToken(new ACLTokenParmeter { ID = "a0e4a748-2192-161a-0510-9bf59fe950bd", Name = "acl01", Type = "client" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.backBootstrapACLs)}");
        }
        /// <summary>
        /// Update ACL Token
        /// </summary>
        private static void UpdateACLToken()
        {
            var aclGovern = new ACLGovern();
            var result = aclGovern.UpdateACLToken(new ACLTokenParmeter { ID = "a0e4a748-2192-161a-0510-9bf59fe950bd", Name = "acl01", Type = "client" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.backJson)}");
        }
        /// <summary>
        /// Delete ACL Token
        /// </summary>
        private static void DeleteACLToken()
        {
            var aclGovern = new ACLGovern();
            var result = aclGovern.DeleteACLToken("a0e4a748-2192-161a-0510-9bf59fe950bd").GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.backJson)}");
        }
        /// <summary>
        /// ReadACLToken
        /// </summary>
        private static void ReadACLToken()
        {
            var aclGovern = new ACLGovern();
            var result = aclGovern.ReadACLToken("a0e4a748-2192-161a-0510-9bf59fe950bd").GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        /// <summary>
        /// Clone ACL Token
        /// </summary>
        private static void CloneACLToken()
        {
            var aclGovern = new ACLGovern();
            var result = aclGovern.CloneACLToken("a0e4a748-2192-161a-0510-9bf59fe950bd").GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.bootstrapACLsResult)}");
        }
        /// <summary>
        /// List ACLs
        /// </summary>
        private static void ListACLs()
        {
            var aclGovern = new ACLGovern();
            var result = aclGovern.ListACLs().GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }

        private static void CheckACLReplication()
        {
            var aclGovern = new ACLGovern();
            var result = aclGovern.CheckACLReplication("dc1").GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        #endregion

        #region KV Store
        private static void KVStoreManage()
        {
            while (true)
            {
                Console.WriteLine("1、Read Key  2、Create Update Key   3、Delete Key  按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        ReadKey();
                        break;
                    case "2":
                        CreateUpdateKey();
                        break;
                    case "3":
                        DeleteKey();
                        break;
                    case "e":
                        return;
                }
            }
        }
        /// <summary>
        /// Read Key
        /// </summary>
        private static void ReadKey()
        {
            var kvGovern = new KVGovern();
            var result = kvGovern.ReadKey(new ReadKeyParmeter { Key = "testkey" }).GetAwaiter().GetResult();
            Console.WriteLine(EntityToString(result));
        }
        /// <summary>
        /// Create/UpdateKey
        /// </summary>
        private static void CreateUpdateKey()
        {
            var kvGovern = new KVGovern();
            var result = kvGovern.CreateUpdateKey(new CreateUpdateKeyParmeter { Key = "testkey", DC = "dc2", Acquire = "a", Release = "b" }, "abc").GetAwaiter().GetResult();
            Console.WriteLine(EntityToString(result));
        }
        /// <summary>
        /// Delete Key
        /// </summary>
        private static void DeleteKey()
        {
            var kvGovern = new KVGovern();
            var result = kvGovern.DeleteKey(new DeleteKeyParmeter { Key = "testkey" }).GetAwaiter().GetResult();
            Console.WriteLine(EntityToString(result));
        }
        #endregion

        #region Catalog
        private static void CatalogManage()
        {
            while (true)
            {
                Console.WriteLine("1、Register Entity  2、Deregister Entity   3、List Datacenters  4、List Nodes   5、List Services   6、List Nodes for Service  7、List Services For Node   按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        RegisterEntity();
                        break;
                    case "2":
                        DeregisterEntity();
                        break;
                    case "3":
                        ListDatacenters();
                        break;
                    case "4":
                        ListNodes();
                        break;
                    case "5":
                        CatalogListServices();
                        break;
                    case "6":
                        ListNodesForService();
                        break;
                    case "7":
                        ListServicesForNode();

                        break;
                    case "e":
                        return;
                }
            }
        }
        /// <summary>
        /// Register Entity
        /// </summary>
        private static void RegisterEntity()
        {
            var acatalogGovern = new CatalogGovern();
            var result = acatalogGovern.RegisterEntity(new RegisterEntityParmeter
            {
                Address = "123.123.123.123",
                ID = "40e4a748-2192-161a-0510-9bf59fe950bd",
                Node = "abc",
                Datacenter = "dc1",
                TaggedAddresses = new TaggedAddress { Lan = "123.123.123.123", Wan = "" }

            }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
        /// <summary>
        /// Deregister Entity
        /// </summary>
        private static void DeregisterEntity()
        {
            var catalogGovern = new CatalogGovern();
            var result = catalogGovern.DeregisterCatalog(new DeregisterEntityParmeter
            {
                Node = "abc",
                Datacenter = "dc1"

            }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}"); ;
        }
        /// <summary>
        /// List Datacenters
        /// </summary>
        private static void ListDatacenters()
        {
            var catalogGovern = new CatalogGovern();
            var result = catalogGovern.ListDatacenters().GetAwaiter().GetResult();
            Console.WriteLine(EntityToString(result));
        }
        /// <summary>
        /// List Nodes
        /// </summary>
        private static void ListNodes()
        {
            var catalogGovern = new CatalogGovern();
            var result = catalogGovern.ListNodes(new ListNodesParmeter { DC = "dc1" }).GetAwaiter().GetResult();
            Console.WriteLine(EntityToString(result));
        }
        /// <summary>
        /// ListServices
        /// </summary>
        private static void CatalogListServices()
        {
            var catalogGovern = new CatalogGovern();
            var result = catalogGovern.ListServices(new ListServicesParmeter { DC = "dc1" }).GetAwaiter().GetResult();
            Console.WriteLine(EntityToString(result));
        }
        /// <summary>
        /// List Services For Node
        /// </summary>
        private static void ListServicesForNode()
        {
            var catalogGovern = new CatalogGovern();
            var result = catalogGovern.ListServicesForNode(new ListServicesForNodeParmeter { DC = "dc1", Node = "n1" }).GetAwaiter().GetResult();
            Console.WriteLine(EntityToString(result));
        }
        /// <summary>
        /// List Nodes For Service
        /// </summary>
        private static void ListNodesForService()
        {
            var catalogGovern = new CatalogGovern();
            var result = catalogGovern.ListNodesForService(new ListNodesForServiceParmeter { DC = "dc1", Service = "lisapi" }).GetAwaiter().GetResult();
            Console.WriteLine(EntityToString(result));
        }
        #endregion

        #region Agent
        private static void AgentManage()
        {
            Console.WriteLine("1、Check Manage  2、Service Manage  3、List Members  4、Read Configuration  5、Reload Agent 6、Enable Maintenance Mode  7、View Metrics  8、Stream Logs  9、Join Agent   10、Graceful Leave and Shutdown  11、Force Leave And Shutdown   12、Update ACL Tokens  13、Update ACL Agent Token  14、Update ACL Agent Master Token  15、Update ACL Replication Token   按e退出");
            switch (Console.ReadLine())
            {
                case "1":
                    CheckManage();
                    break;
                case "2":
                    ServiceManage();
                    break;
                case "3":
                    ListMembers();
                    break;
                case "4":
                    ReadConfiguration();
                    break;
                case "5":
                    ReloadAgent();
                    break;
                case "6":
                    AgentEnableMaintenanceMode();
                    break;
                case "7":
                    ViewMetrics();
                    break;
                case "8":
                    StreamLogs();
                    break;
                case "9":
                    JoinAgent();
                    break;
                case "10":
                    GracefulLeaveandShutdown();
                    break;
                case "11":
                    ForceLeaveAndShutdown();
                    break;
                case "12":
                    UpdateACLTokens();
                    break;
                case "13":
                    UpdateACLAgentToken();
                    break;
                case "14":
                    UpdateACLAgentMasterToken();
                    break;
                case "15":
                    UpdateACLReplicationToken();
                    break;
                case "e":
                    return;
            }
        }


        /// <summary>
        /// List Members
        /// </summary>
        private static void ListMembers()
        {
            var agentGovern = new AgentGovern();
            var list = agentGovern.ListMembers(new ListMembersParmeter { Wan = true }).GetAwaiter().GetResult();
            foreach (var item in list)
            {
                Console.WriteLine(EntityToString(item));
                Console.WriteLine("-----------------------------------------------");
            }
        }
        /// <summary>
        /// Read Configuration
        /// </summary>
        private static void ReadConfiguration()
        {
            var agentGovern = new AgentGovern();
            var list = agentGovern.ReadConfiguration().GetAwaiter().GetResult();
            Console.WriteLine(EntityToString(list));
        }
        /// <summary>
        /// Reload Agent
        /// </summary>
        private static void ReloadAgent()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.ReloadAgent().GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}"); ;
        }

        /// <summary>
        /// Enable Maintenance Mode
        /// </summary>
        private static void AgentEnableMaintenanceMode()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.AgentEnableMaintenanceMode(new EnableMaintenanceModeParmeter
            {
                Enable = true,
                Reason = "abc"
            }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}"); ;
        }

        /// <summary>
        /// View Metrics
        /// </summary>
        private static void ViewMetrics()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.ViewMetrics().GetAwaiter().GetResult();
            Console.WriteLine(result);
        }
        /// <summary>
        /// Stream Logs
        /// </summary>
        private static void StreamLogs()
        {
            var agentGovern = new AgentGovern();
            agentGovern.WriteLog += delegate (string log)
            {
                Console.WriteLine(log);
            };
            agentGovern.StreamLogs().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Join Agent
        /// </summary>
        private static void JoinAgent()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.JoinAgent(new JoinAgentParmeter
            {
                Address = "192.168.1.1",
                Wan = false
            }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
        /// <summary>
        /// Graceful Leaveand Shutdown
        /// </summary>
        private static void GracefulLeaveandShutdown()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.GracefulLeaveAndShutdown().GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
        /// <summary>
        /// Force Leave And Shutdown
        /// </summary>
        private static void ForceLeaveAndShutdown()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.ForceLeaveAndShutdown().GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
        /// <summary>
        /// Update ACL Tokens
        /// </summary>
        private static void UpdateACLTokens()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.UpdateACLToken(new UpdateTokenParmeter
            {
                Token = "2d3423fdfd"
            }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
        /// <summary>
        /// Update ACL Agent Token
        /// </summary>
        private static void UpdateACLAgentToken()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.UpdateACLAgentToken(new UpdateTokenParmeter
            {
                Token = "2d3423fdfd"
            }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
        /// <summary>
        /// Update ACL Agent Master Token
        /// </summary>
        private static void UpdateACLAgentMasterToken()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.UpdateACLAgentMasterToken(new UpdateTokenParmeter
            {
                Token = "2d3423fdfd"
            }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }

        /// <summary>
        /// Update ACL Replication Token
        /// </summary>
        private static void UpdateACLReplicationToken()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.UpdateACLReplicationToken(new UpdateTokenParmeter
            {
                Token = "2d3423fdfd"
            }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
        #endregion

        #region Service
        private static void ServiceManage()
        {
            while (true)
            {
                Console.WriteLine("1、List Services   2、Register Service   3、Deregister Service  4、Enable Maintenance Mode   5、  6、  7、  按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        ListServices();
                        break;
                    case "2":
                        RegisterService();
                        break;
                    case "3":
                        DeregisterService();
                        break;
                    case "4":
                        EnableMaintenanceMode();
                        break;
                    case "5":

                        break;
                    case "6":

                        break;
                    case "7":

                        break;
                    case "e":
                        return;
                }
            }
        }

        /// <summary>
        /// Register Service
        /// </summary>
        private static void RegisterService()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.RegisterServices(new RegisterServiceParmeter
            {
                ID = "test0001",
                Name = "test0001",
                Address = "http://www.baiduc.om",
                Port = 80,
                Tags = new string[] { "baidu", "百度" }
            }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
        /// <summary>
        /// Deregister Service
        /// </summary>
        private static void DeregisterService()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.DeregisterServices("test0001").GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
        /// <summary>
        /// List Services
        /// </summary>
        static void ListServices()
        {
            var agentGovern = new AgentGovern();
            var list = agentGovern.ListServices().GetAwaiter().GetResult();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key}");
                Console.WriteLine(EntityToString(item.Value));
                Console.WriteLine("-----------------------------------------------");
            }
        }
        static void EnableMaintenanceMode()
        {

            var agentGovern = new AgentGovern();
            var result = agentGovern.EnableMaintenanceMode(new EnableMaintenanceModeParmeter { ServiceID = "lisapi001", Enable = true, Reason = "abc" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }

        #endregion

        #region Check
        static void CheckManage()
        {
            while (true)
            {
                Console.WriteLine("1、List Checks   2、Register Check   3、Deregister Check  4、TTL Check Pass   5、TTL Check Warn   6、TTL Check Fail   7、TTL Check Update  按e退出");
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
                        TTLCheckPass();
                        break;
                    case "5":
                        TTLCheckWarn();
                        break;
                    case "6":
                        TTLCheckFail();
                        break;
                    case "7":
                        TTLCheckUpdate();
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


        /// <summary>
        /// TTL Check Pass
        /// </summary>
        static void TTLCheckPass()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.TTLCheckPass(new TTLCheckPassParmeter { Check_ID = "lisapicheck001", Note = "n1" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
        /// <summary>
        /// TTL Check Warn
        /// </summary>
        static void TTLCheckWarn()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.TTLCheckWarn(new TTLCheckPassParmeter { Check_ID = "lisapicheck001", Note = "n1" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
        /// <summary>
        /// TTL Check Fail
        /// </summary>
        static void TTLCheckFail()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.TTLCheckFail(new TTLCheckPassParmeter { Check_ID = "lisapicheck001", Note = "n1" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
        /// <summary>
        /// TTL Check Update
        /// </summary>
        static void TTLCheckUpdate()
        {
            var agentGovern = new AgentGovern();
            var registerCheck = new TTLCheckUpdateParmeter()
            {
                Check_ID = "lisapicheck001",
                Status = "passing",
                Output = "abc"
            };
            var result = agentGovern.TTLCheckUpdate(registerCheck).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
        #endregion

        static string EntityToString(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }


    }
}
