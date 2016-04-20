using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UCS.PacketProcessing;

namespace UCS.Logic
{
    internal class Level
    {
        private readonly ClientAvatar m_vClientAvatar;
        public GameObjectManager GameObjectManager; //a1 + 44
        private byte m_vAccountPrivileges;
        private byte m_vAccountStatus;
        private Client m_vClient;
        private string m_vIPAddress;
        private DateTime m_vTime; //a1 + 40
        public WorkerManager WorkerManager;
        //MissionManager
        //AchievementManager
        //CooldownManager

        public Level()
        {
            WorkerManager = new WorkerManager();
            GameObjectManager = new GameObjectManager(this);
            m_vClientAvatar = new ClientAvatar();
            m_vAccountPrivileges = 0;
            m_vAccountStatus = 0;
            m_vIPAddress = "0.0.0.0";
        }

        public Level(long id, string token)
        {
            WorkerManager = new WorkerManager();
            GameObjectManager = new GameObjectManager(this);
            m_vClientAvatar = new ClientAvatar(id, token);
            m_vTime = DateTime.UtcNow;
            m_vAccountPrivileges = 0;
            m_vAccountStatus = 0;
            m_vIPAddress = "0.0.0.0";
        }

        public byte GetAccountPrivileges()
        {
            return m_vAccountPrivileges;
        }

        public string GetIPAddress()
        {
            return m_vIPAddress;
        }

        /*
        public void BanIP()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"banned-ip.txt", true))
                file.WriteLine(m_vIPAddress);
        }

        public void DeBanIP()
        {
            var oldLines = System.IO.File.ReadAllLines("banned-ip.txt");
            var newLines = oldLines.Where(line => !line.Contains(m_vIPAddress));
            System.IO.File.WriteAllLines("banned-ip.txt", newLines);
        }*/

        public void SetIPAddress(string IP)
        {
            m_vIPAddress = IP;
        }

        public byte GetAccountStatus()
        {
            return m_vAccountStatus;
        }

        public Client GetClient()
        {
            return m_vClient;
        }

        public ComponentManager GetComponentManager()
        {
            return GameObjectManager.GetComponentManager();
        }

        public ClientAvatar GetHomeOwnerAvatar()
        {
            return m_vClientAvatar;
        }

        public ClientAvatar GetPlayerAvatar()
        {
            return m_vClientAvatar;
        }

        public DateTime GetTime()
        {
            return m_vTime;
        }

        public bool HasFreeWorkers()
        {
            return WorkerManager.GetFreeWorkers() > 0;
        }

        public void LoadFromJSON(string jsonString)
        {
            var jsonObject = JObject.Parse(jsonString);
            GameObjectManager.Load(jsonObject);
        }

        public string SaveToJSON()
        {
            return JsonConvert.SerializeObject(GameObjectManager.Save());
        }

        public void SetAccountPrivileges(byte privileges)
        {
            m_vAccountPrivileges = privileges;
        }

        public void SetAccountStatus(byte status)
        {
            m_vAccountStatus = status;
        }

        public void SetClient(Client client)
        {
            m_vClient = client;
        }

        public void SetHome(string jsonHome)
        {
            GameObjectManager.Load(JObject.Parse(jsonHome));
        }

        public void SetTime(DateTime t)
        {
            m_vTime = t;
        }

        public void Tick()
        {
            SetTime(DateTime.UtcNow);
            GameObjectManager.Tick();
        }
    }
}
