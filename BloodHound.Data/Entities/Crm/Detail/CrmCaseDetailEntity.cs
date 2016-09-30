using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodHound.Data.Entities.Crm.Detail
{
    public class CrmCaseDetailEntity
    {
        public string Title { get; set; }
        public string CustomerIdName { get; set; }
        public string OwneridName { get; set; }
        public string TicketNumber { get; set; }
        public string PriorityCodeName { get; set; }
        public string CaseCategoryIdName { get; set; }
        public string CaseSubCategoryIdName { get; set; }
        public string CaseSubCategoryDetailIdName { get; set; }
        public string ResponsibleContact { get; set; }
        public string CreatedOn { get; set; }
        public string FollowUpBy { get; set; }
        public string CaseType { get; set; }
        public int CaseTypeCode { get; set; }
        public string Description { get; set; }
        public int PriorityCode { get; set; }
        public string CustomerId { get; set; }
        public string OwnerId { get; set; }
        public string InternalEmailAddress { get; set; }
        public string CaseCategoryId { get; set; }
        public string CaseSubCategoryId { get; set; }
        public string CaseSubCategoryDetailId { get; set; }
        public int StateCode { get; set; }
        public string StateCodeName { get; set; }
        public int StatusCode { get; set; }
        public string StatusCodeName { get; set; }
    }
}
