﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace efinley_budgeter.Models
{
    public class Invite
    {
        //public Invite()
        //{
        //    Guid Secret = Guid.NewGuid();
        //}

        public int Id { get; set; }
        public int HouseholdId { get; set; }
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy h:mm tt}")]
        public DateTimeOffset Created { get; set; }
        public string SentById { get; set; }
        [Required]
        public string ToEmail { get; set; }
        //public Guid Secret { get; set; }
        public string Secret { get; set; }
        public virtual Household Household { get; set; }
        public virtual ApplicationUser SentBy { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}