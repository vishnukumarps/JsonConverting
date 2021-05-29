using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFormsJsonParser.Models
{
    public class ParentJson
    {
        //[JsonProperty("id")]
        public long Id { get; set; }

        // [JsonProperty("tenantID")]
        public string TenantId { get; set; }

        //[JsonProperty("moduleID")]
        public string ModuleId { get; set; }

        // [JsonProperty("version")]
        public long Version { get; set; }

        //[JsonProperty("minorVersion")]
        public long MinorVersion { get; set; }

        //[JsonProperty("internalName")]
        public string InternalName { get; set; }

        //[JsonProperty("description")]
        public string Description { get; set; }

        //[JsonProperty("title")]
        public string Title { get; set; }

        //[JsonProperty("isDisabled")]
        public bool IsDisabled { get; set; }

        //[JsonProperty("type")]
        public string Type { get; set; }

        //[JsonProperty("parentID")]
        public string ParentId { get; set; }

        //[JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        //[JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        //[JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        //[JsonProperty("modified")]
        public DateTimeOffset Modified { get; set; }

        //[JsonProperty("formJSON")]
        public string FormJson { get; set; }

        //[JsonProperty("formDetailsJSON")]
        public string FormDetailsJson { get; set; }

        //[JsonProperty("ruleJson")]
        public string RuleJson { get; set; }

        // [JsonProperty("status")]
        public string Status { get; set; }

        // [JsonProperty("checkedOutUser")]
        public string CheckedOutUser { get; set; }

        // [JsonProperty("isUsed")]
        public bool IsUsed { get; set; }

        //[JsonProperty("read")]
        public bool Read { get; set; }

        //[JsonProperty("create")]
        public bool Create { get; set; }

        //[JsonProperty("update")]
        public bool Update { get; set; }

        //[JsonProperty("fullAccess")]
        public bool FullAccess { get; set; }

        //[JsonProperty("groupKey")]
        public string GroupKey { get; set; }

        //[JsonProperty("publishStatus")]
        public long PublishStatus { get; set; }

        //[JsonProperty("controlsGroupJSON")]
        public string ControlsGroupJson { get; set; }

        //[JsonProperty("formBuildVersion")]
        public string FormBuildVersion { get; set; }

        //[JsonProperty("appType")]
        public string AppType { get; set; }

        //[JsonProperty("formPath")]
        public string FormPath { get; set; }

        //[JsonProperty("adbjson")]
        public string Adbjson { get; set; }

        //[JsonProperty("formType")]
        public long FormType { get; set; }

        //[JsonProperty("selectedTemplate")]
        public object SelectedTemplate { get; set; }
    }


     public class ControllType
        {

            public string type { get; set; }
            public string style { get; set; }
            public string @class { get; set; }
            public string name { get; set; }

        }

        public class Row
        {
            public string type { get; set; }
            public string @class { get; set; }
            public List<Column> Children { get; set; }
        }
        public class Column
        {
   
            public string type { get; set; }
            public string @class { get; set; }
           // public List<Column> columns { get; set; }
            public List<ControllType> Children { get; set; }

        }
}
