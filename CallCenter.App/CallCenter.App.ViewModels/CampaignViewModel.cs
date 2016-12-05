﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenter.App.ViewModels
{
    public class CampaignViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
