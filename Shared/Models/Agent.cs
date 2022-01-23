using ProjectX.Shared.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.Shared.Models
{
    public class Agent
    {
        public int AgentId { get; set; }

        [Required, MinLength(2), MaxLength(50), Display(Name = "Agent Name")]
        public string AgentName { get; set; }

        [Required,EmailAddress, EmailDomainValidation(AllowedDomain = "gmail.com"), Display(Name = "Agent Email")]
        public string AgentEmail { get; set; }

        [Required,Phone, Display(Name = "Agent Phone")]
        public string AgentPhone { get; set; }

        [Required, MinLength(2), MaxLength(50), Display(Name = "Agent Address")]
        public string AgentAddress { get; set; }
    }
}
