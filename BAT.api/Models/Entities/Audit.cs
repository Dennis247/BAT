using BAT.api.Helpers;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace BAT.api.Models.Entities
{
    public class Audit
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Type { get; set; }
        public string TableName { get; set; }
        public DateTime DateTime { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string AffectedColumns { get; set; }
        public string PrimaryKey { get; set; }
        public string Ip { get; set; }
        public string WorkStation { get; set; }
        public string ReasonForUpdate { get; set; }
        public string TraceId { get; set; }
        public string HttpMethod { get; set; }
        public string BrowserInfo { get; set; }
        public string AreaAccessed { get; set; }
    }


    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }
        public EntityEntry Entry { get; }
        public int UserId { get; set; }
        public string TableName { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public AuditType AuditType { get; set; }
        public List<string> ChangedColumns { get; } = new List<string>();
        public string WorkStation { get; set; }
        public string Ip { get; set; }

        public string TraceId { get; set; }
        public string BrowserInfo { get; set; }
        public string HttpMethod { get; set; }
        public string AreaAccessed { get; set; }
        public string ReasonForUpdate { get; set; }
        public string UserName { get; set; }
        public Audit ToAudit()
        {

            var audit = new Audit();
            audit.UserId = UserId;
            audit.Type = AuditType.ToString();
            audit.TableName = TableName;
            audit.DateTime = DateTime.Now;
            audit.WorkStation = WorkStationHelper.getWSSignature();
            audit.Ip = WorkStationHelper.GetUserIpAddress();
            audit.PrimaryKey = JsonConvert.SerializeObject(KeyValues);
            audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            audit.AffectedColumns = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns);
            audit.ReasonForUpdate = ReasonForUpdate;
            audit.HttpMethod = HttpMethod;
            audit.BrowserInfo = BrowserInfo;
            audit.TraceId = TraceId;
            audit.AreaAccessed = AreaAccessed;
            audit.UserName = UserName;
            return audit;
        }
    }


    public enum AuditType
    {
        View = 0,
        Create = 1,
        Update = 2,
        Delete = 3
    }

}


