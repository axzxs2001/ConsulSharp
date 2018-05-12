# ConsulSharp
A set of c# API to call the consul HTTP API!

consul http api:https://www.consul.io/api/index.html

![](https://github.com/axzxs2001/ConsulSharp/blob/master/ConsulSharp/ConsulSharp/ConsulSharp.png)

### Usage:

Install-Package ConsulSharp -Version 0.1.1 

```c#
        /// <summary>
        /// Read Key
        /// </summary>
        private static void ReadKey()
        {
            var kvGovern = new KVGovern();
            var result = kvGovern.ReadKey(new ReadKeyParmeter { Key = "lisconnectionstring" }).GetAwaiter().GetResult();
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
        /// Register Service
        /// </summary>
        private static void RegisterService()
        {
            var agentGovern = new AgentGovern();
            var result = agentGovern.RegisterServices(new RegisterServiceParmeter
            {
                ID = "test0001",
                Name = "test0001",
                Address = "http://165.125.1.12",
                Port = 80,
                Tags = new string[] { "His"}
            }).GetAwaiter().GetResult();
            Console.WriteLine($"result={result.result}");
            Console.WriteLine($"back content={result.backJson}");
        }
```
