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
using ConsulSharp.Health;
using ConsulSharp.KV;
using ConsulSharp.Operator.Area;
using ConsulSharp.Operator.Autopilot;
using ConsulSharp.Operator.Keyring;
using ConsulSharp.Operator.Raft;
using ConsulSharp.Operator.Segments;
using ConsulSharp.PreparedQueries;
using ConsulSharp.Session;
using ConsulSharp.Snapshot;

namespace ConsulSharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateSnapshot();
            while (true)
            {
                Console.WriteLine("1、ACL  2、Agent 3、Catalog  4、Coordinates  5、Event  6、Health  7、KV Store 8、Operator  9、Prepared Query  10、Session  按e退出");
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
                        OperatorManage();
                        break;
                    case "9":
                        PreparedQueryManage();
                        break;
                    case "10":
                        SessionManage();
                        break;
                    case "e":
                        return;
                }
            }
        }

        #region Snapshot 
        private static void SnapshotManage()
        {
            while (true)
            {
                Console.WriteLine("1、Generate Snapshot  2、Restore Snapshot  按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        GenerateSnapshot();
                        break;
                    case "2":
                        RestoreSnapshot();
                        break;                  
                    case "e":
                        return;
                }
            }
        }
        /// <summary>
        /// Restore Snapshot
        /// </summary>
        private static void RestoreSnapshot()
        {
            var snapshotGovern = new SnapshotGovern();
            var result = snapshotGovern.RestoreSnapshot(new RestoreSnapshotParmeter {  DC="dc1"}).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.restoreSnapshotResult)}");
        }
        /// <summary>
        /// Generate Snapshot
        /// </summary>
        private static void GenerateSnapshot()
        {
            var snapshotGovern = new SnapshotGovern();
            var result = snapshotGovern.GenerateSnapshot(new GenerateSnapshotParmeter { DC = "dc1", Stale = true }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result}");
        }
        #endregion

        #region Session
        private static void SessionManage()
        {
            while (true)
            {
                Console.WriteLine("1、Create Session  2、Delete Session  3、Read Session   4、List Sessions for Node  5、List Sessions  6、Renew Session   按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        CreateSession();
                        break;
                    case "2":
                        DeleteSession();
                        break;
                    case "3":
                        ReadSession();
                        break;
                    case "4":
                        ListSessionsForNode();
                        break;
                    case "5":
                        ListSessions();
                        break;
                    case "6":
                        RenewSession();
                        break;
                    case "e":
                        return;
                }
            }
        }
        /// <summary>
        /// Create Session
        /// </summary>
        private static void CreateSession()
        {
            var sessionGovern = new SessionGovern();
            var result = sessionGovern.CreateSession(new CreateSessionParmeter { DC = "dc1", LockDelay = "10s", Name = "abc", Node = "n1", Behavior = "release", TTL = "30s" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.createSessionResult)}");
        }
        /// <summary>
        /// Delete Session
        /// </summary>
        private static void DeleteSession()
        {
            var sessionGovern = new SessionGovern();
            var result = sessionGovern.DeleteSession(new DeleteSessionParmeter { DC = "dc1",UUID= "f2c9d2b6-ea0d-a55c-82b3-9220717a14c8" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.deleteSessionResult)}");
        }
        /// <summary>
        /// Read Session
        /// </summary>
        private static void ReadSession()
        {
            var sessionGovern = new SessionGovern();
            var result = sessionGovern.ReadSession(new DeleteSessionParmeter { DC = "dc1", UUID = "f2c9d2b6-ea0d-a55c-82b3-9220717a14c8" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        /// <summary>
        /// List Sessions For Node
        /// </summary>
        private static void ListSessionsForNode()
        {
            var sessionGovern = new SessionGovern();
            var result = sessionGovern.ListSessionsForNode(new ListSessionsForNodeParmeter { DC = "dc1", Node = "n1" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        /// <summary>
        /// List Sessions
        /// </summary>
        private static void ListSessions()
        {
            var sessionGovern = new SessionGovern();
            var result = sessionGovern.ListSessions(new ListSessionsParmeter { DC = "dc1" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        /// <summary>
        /// Renew Session
        /// </summary>
        private static void RenewSession()
        {
            var sessionGovern = new SessionGovern();
            var result = sessionGovern.RenewSession(new DeleteSessionParmeter { DC = "dc1", UUID = "f2c9d2b6-ea0d-a55c-82b3-9220717a14c8" }).GetAwaiter().GetResult();
             Console.WriteLine($"back content={EntityToString(result)}");
        }
        #endregion

        #region Prepared Query
        public static void PreparedQueryManage()
        {
            while (true)
            {
                Console.WriteLine("1、Create Prepared Query  2、Read Prepared Query  3、Update Prepared Query  4、Read Prepared Query  5、Delete Prepared Query  6、Execute Prepared Query 7、Explain Prepared Query 按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        CreatePreparedQuery();
                        break;
                    case "2":
                        ReadPreparedQuery();
                        break;
                    case "3":
                        UpdatePreparedQuery();
                        break;
                    case "4":
                        ReadPreparedQuery1();
                        break;
                    case "e":
                        return;
                }
            }
        }
        /// <summary>
        /// Create Prepared Query 
        /// </summary>
        private static void CreatePreparedQuery()
        {
            var preparedQueriesGovern = new PreparedQueriesGovern();
            var result = preparedQueriesGovern.CreatePreparedQuery(new CreatePreparedQueryParmeter { DC = "dc1" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.createPreparedQueryResult)}");
        }
        /// <summary>
        /// Read Prepared Query
        /// </summary>
        private static void ReadPreparedQuery()
        {
            var preparedQueriesGovern = new PreparedQueriesGovern();
            var result = preparedQueriesGovern.ReadPreparedQuery(new ReadPreparedQueryParmeter { DC = "dc1" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        public static void UpdatePreparedQuery()
        {
            var preparedQueriesGovern = new PreparedQueriesGovern();
            var result = preparedQueriesGovern.UpdatePreparedQuery(new UpdatePreparedQueryParmeter { DC = "dc1", UUID = "a0e4a748-2192-161a-0510-9bf59fe950bd" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backResult}");
        }

        /// <summary>
        /// Read Prepared Query
        /// </summary>
        private static void ReadPreparedQuery1()
        {
            var preparedQueriesGovern = new PreparedQueriesGovern();
            var result = preparedQueriesGovern.ReadPreparedQuery(new ReadPreparedQueryParmeter { DC = "dc1", UUID = "a0e4a748-2192-161a-0510-9bf59fe950bd" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        /// <summary>
        /// Delete Prepared Query
        /// </summary>
        private static void DeletePreparedQuery()
        {
            var preparedQueriesGovern = new PreparedQueriesGovern();
            var result = preparedQueriesGovern.DeletePreparedQuery(new UpdatePreparedQueryParmeter { DC = "dc1", UUID = "a0e4a748-2192-161a-0510-9bf59fe950bd" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backResult}");
        }
        /// <summary>
        /// Execute Prepared Query
        /// </summary>
        private static void ExecutePreparedQuery()
        {
            var preparedQueriesGovern = new PreparedQueriesGovern();
            var result = preparedQueriesGovern.ExecutePreparedQuery(new ExecutePreparedQueryParmeter { DC = "dc1", UUID = "a0e4a748-2192-161a-0510-9bf59fe950bd" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        /// <summary>
        /// Explain Prepared Query
        /// </summary>
        private static void ExplainPreparedQuery()
        {
            var preparedQueriesGovern = new PreparedQueriesGovern();
            var result = preparedQueriesGovern.ExplainPreparedQuery(new ExplainPreparedQueryParmeter { DC = "dc1", UUID = "a0e4a748-2192-161a-0510-9bf59fe950bd" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        #endregion

        #region Operator
        public static void OperatorManage()
        {
            while (true)
            {
                Console.WriteLine("1、Area 2、Autopilot 3、Keyring 4、Raft  5、Segment  按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        OperatorAreaManage();
                        break;
                    case "2":
                        OperatorAutopilotManage();
                        break;
                    case "3":
                        OperatorKeyringManage();
                        break;
                    case "4":
                        OperatorRaftManage();
                        break;
                    case "5":
                        OperatorSegmentManage();
                        break;
                    case "e":
                        return;
                }
            }
        }

        #region OperatorArea
        private static void OperatorAreaManage()
        {
            while (true)
            {
                Console.WriteLine("1、Create Network Area  2、List Network Areas  3、Update Network Area   4、List Specific Network Area  5、Delete Network Area  6、Join Network Area   7、List Network Area Members   按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        CreateNetworkArea();
                        break;
                    case "2":
                        ListNetworkAreas();
                        break;
                    case "3":
                        UpdateNetworkArea();
                        break;
                    case "4":
                        ListSpecificNetworkArea();
                        break;
                    case "5":
                        DeleteNetworkArea();
                        break;
                    case "6":
                        JoinNetworkArea();
                        break;
                    case "7":
                        ListNetworkAreaMembers();
                        break;
                    case "e":
                        return;
                }
            }
        }


        /// <summary>
        /// Create Network Area
        /// </summary>
        private static void CreateNetworkArea()
        {
            var operatorAreaGovern = new OperatorAreaGovern();
            var result = operatorAreaGovern.CreateNetworkArea(new CreateNetworkAreaParmeter { DC = "dc1", PeerDatacenter = "dc2", RetryJoin = new string[] { "127.0.0.1" }, UseTLS = false }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.createNetworkAreaResult)}");
        }
        /// <summary>
        /// List Network Areas
        /// </summary>
        private static void ListNetworkAreas()
        {
            var operatorAreaGovern = new OperatorAreaGovern();
            var result = operatorAreaGovern.ListNetworkAreas(new ListNetworkAreasParmeter { DC = "dc1" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        /// <summary>
        /// Update Network Area
        /// </summary>
        private static void UpdateNetworkArea()
        {
            var operatorAreaGovern = new OperatorAreaGovern();
            var result = operatorAreaGovern.UpdateNetworkArea(new UpdateNetworkAreaParmeter { DC = "dc1", UseTLS = false }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backString}");
        }
        /// <summary>
        /// List Specific Network Area
        /// </summary>
        private static void ListSpecificNetworkArea()
        {
            var operatorAreaGovern = new OperatorAreaGovern();
            var result = operatorAreaGovern.ListSpecificNetworkArea(new NetworkAreaParmeter { DC = "dc1", UUID = "" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        /// <summary>
        /// Delete Network Area
        /// </summary>
        private static void DeleteNetworkArea()
        {
            var operatorAreaGovern = new OperatorAreaGovern();
            var result = operatorAreaGovern.DeleteNetworkArea(new NetworkAreaParmeter { DC = "dc1", UUID = "" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backString}");
        }
        /// <summary>
        /// Join Network Area
        /// </summary>
        private static void JoinNetworkArea()
        {
            var operatorAreaGovern = new OperatorAreaGovern();
            var result = operatorAreaGovern.JoinNetworkArea(new NetworkAreaParmeter { DC = "dc1", UUID = "" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.joinNetworkAreaResults)}");
        }
        /// <summary>
        /// List Network Area Members
        /// </summary>
        private static void ListNetworkAreaMembers()
        {
            var operatorAreaGovern = new OperatorAreaGovern();
            var result = operatorAreaGovern.ListNetworkAreaMembers(new NetworkAreaParmeter { DC = "dc1", UUID = "" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }

        #endregion

        #region Autopilot

        public static void OperatorAutopilotManage()
        {
            while (true)
            {
                Console.WriteLine("1、Read Configuration 2、Update Configuration  3、Read Health 按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        AutopilotReadConfiguration();
                        break;
                    case "2":
                        UpdateConfiguration();
                        break;
                    case "3":
                        ReadHealth();
                        break;
                    case "e":
                        return;
                }
            }
        }
        /// <summary>
        /// Read Configuration
        /// </summary>
        private static void AutopilotReadConfiguration()
        {
            var operatorAutopilotGovern = new OperatorAutopilotGovern();
            var result = operatorAutopilotGovern.ReadConfiguration(new ConsulSharp.Operator.Autopilot.ReadConfigurationParmeter { DC = "dc1", Stale = true }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        /// <summary>
        /// Update Configuration
        /// </summary>
        private static void UpdateConfiguration()
        {
            var operatorAutopilotGovern = new OperatorAutopilotGovern();
            var result = operatorAutopilotGovern.UpdateConfiguration(new UpdateConfigurationParmeter { DC = "dc1", UpgradeVersionTag = "1a" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.jsonContent)}");
        }

        /// <summary>
        /// Read Health
        /// </summary>
        private static void ReadHealth()
        {
            var operatorAutopilotGovern = new OperatorAutopilotGovern();
            var result = operatorAutopilotGovern.ReadHealth(new ReadHealthParmeter { DC = "dc1" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        #endregion

        #region Keyring 
        /// <summary>
        /// Operator Keyring Manage
        /// </summary>
        public static void OperatorKeyringManage()
        {
            while (true)
            {
                Console.WriteLine("1、List Gossip Encryption Keys  2、Add New Gossip Encryption Key   3、Change Primary Gossip Encryption Key  4、Delete Gossip Encryption Key  按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        ListGossipEncryptionKeys();
                        break;
                    case "2":
                        AddNewGossipEncryptionKey();
                        break;
                    case "3":
                        ChangePrimaryGossipEncryptionKey();
                        break;
                    case "4":
                        DeleteGossipEncryptionKey();
                        break;
                    case "e":
                        return;
                }
            }
        }
        /// <summary>
        /// List Gossip Encryption Keys
        /// </summary>
        private static void ListGossipEncryptionKeys()
        {
            var operatorKeyringGovern = new OperatorKeyringGovern();
            var result = operatorKeyringGovern.ListGossipEncryptionKeys(new ListGossipEncryptionKeysParmeter { RelayFactor = 1 }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");

        }
        /// <summary>
        /// Add New Gossip Encryption Key
        /// </summary>
        private static void AddNewGossipEncryptionKey()
        {
            var operatorKeyringGovern = new OperatorKeyringGovern();
            var result = operatorKeyringGovern.AddNewGossipEncryptionKey(new AddNewGossipEncryptionKeyParmeter { RelayFactor = 2, Key = "33g9DxVfKNzI8O+IQ5Ek+Q==" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.listGossipEncryptionKeysResults)}");

        }
        /// <summary>
        /// Change Primary Gossip Encryption Key
        /// </summary>
        private static void ChangePrimaryGossipEncryptionKey()
        {
            var operatorKeyringGovern = new OperatorKeyringGovern();
            var result = operatorKeyringGovern.ChangePrimaryGossipEncryptionKey(new AddNewGossipEncryptionKeyParmeter { RelayFactor = 2, Key = "7TnJPB4lKtjEcCWWjN6jSA==" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.backResult)}");
        }

        /// <summary>
        /// Delete Gossip Encryption Key
        /// </summary>
        private static void DeleteGossipEncryptionKey()
        {
            var operatorKeyringGovern = new OperatorKeyringGovern();
            var result = operatorKeyringGovern.DeleteGossipEncryptionKey(new AddNewGossipEncryptionKeyParmeter { RelayFactor = 1, Key = "7TnJPB4lKtjEcCWWjN6jSA==" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.backResult)}");
        }
        #endregion

        #region Raft
        public static void OperatorRaftManage()
        {
            while (true)
            {
                Console.WriteLine("1、Read Configuration  2、Delete Raft Peer     按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        RaftReadConfiguration();
                        break;
                    case "2":
                        DeleteRaftPeer();
                        break;
                    case "e":
                        return;
                }
            }
        }
        /// <summary>
        /// Raft Read Configuration
        /// </summary>
        private static void RaftReadConfiguration()
        {
            var operatorRaftGovern = new OperatorRaftGovern();
            var result = operatorRaftGovern.ReadConfiguration(new ConsulSharp.Operator.Raft.ReadConfigurationParmeter { DC = "dc1", Stale = true }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        /// <summary>
        /// Delete Raft Peer
        /// </summary>
        private static void DeleteRaftPeer()
        {
            var operatorRaftGovern = new OperatorRaftGovern();
            var result = operatorRaftGovern.DeleteGossipEncryptionKey(new DeleteRaftPeerParmeter { ID = "", DC = "", Address = "" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backResult}");
        }
        #endregion

        #region Segment
        /// <summary>
        /// OperatorSegmentManage
        /// </summary>
        private static void OperatorSegmentManage()
        {
            while (true)
            {
                Console.WriteLine("1、List Network Segments   按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        ListNetworkSegments();
                        break;
                    case "e":
                        return;
                }
            }
        }
        /// <summary>
        /// List Network Segments
        /// </summary>
        private static void ListNetworkSegments()
        {
            var operatorSegmentsGovern = new OperatorSegmentsGovern();
            var result = operatorSegmentsGovern.ListNetworkSegments(new ListNetworkSegmentsParmeter { DC = "dc1" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }


        #endregion
        #endregion

        #region Event
        private static void EventManage()
        {
            while (true)
            {
                Console.WriteLine("1、Fire Event  2、List Events 按e退出");
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
        /// <summary>
        /// Fire Event
        /// </summary>
        private static void FireEvent()
        {
            var eventGovern = new EventGovern();
            var result = eventGovern.FireEvent(new FireEventParmeter { Name = "fireevent", DC = "dc1", Node = "n1", Service = "lisapi", Tag = "lisapi" }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={EntityToString(result.fireEvent)}");
        }
        /// <summary>
        /// List Events
        /// </summary>
        private static void ListEvents()
        {
            var eventGovern = new EventGovern();
            var result = eventGovern.EventList(new ListEventParmeter { Name = "fireevent", Node = "n1", Service = "lisapi", Tag = "lisapi" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        #endregion

        #region Health
        private static void HealthManage()
        {
            while (true)
            {
                Console.WriteLine("1、List Checks for Node  2、List Checks For Service   3、List Nodes For Service   4、List Checks in State   按e退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        ListChecksForNode();
                        break;
                    case "2":
                        ListChecksForService();
                        break;
                    case "3":
                        HealthListNodesForService();
                        break;
                    case "4":
                        ListChecksInState();
                        break;
                    case "e":
                        return;
                }
            }
        }
        /// <summary>
        /// List Checks For Node
        /// </summary>
        private static void ListChecksForNode()
        {
            var healthGovern = new HealthGovern();
            var result = healthGovern.ListChecksForNode(new ListCheckForNodeParmeter { DC = "dc1", Node = "n1" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        /// <summary>
        /// List Checks For Service
        /// </summary>
        private static void ListChecksForService()
        {
            var healthGovern = new HealthGovern();
            var result = healthGovern.ListChecksForService(new CheckServiceParmeter { Service = "lisapi", DC = "dc1" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        /// <summary>
        /// List Nodes For Service
        /// </summary>
        private static void HealthListNodesForService()
        {
            var healthGovern = new HealthGovern();
            var result = healthGovern.ListNodeForService(new ListNodeForServiceParmeter { Service = "lisapi", DC = "dc1" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }
        /// <summary>
        /// List Checks In State
        /// </summary>
        private static void ListChecksInState()
        {
            var healthGovern = new HealthGovern();
            var result = healthGovern.ListChecksInState(new ListChecksInStateParmeter { DC = "dc1", State = "critical" }).GetAwaiter().GetResult();
            Console.WriteLine($"back content={EntityToString(result)}");
        }


        #endregion

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
            var result = coordnatesGovern.UpdateLANCoordinatesForANode(new Coordinate { Node = "n1" }, "dc1").GetAwaiter().GetResult();
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
