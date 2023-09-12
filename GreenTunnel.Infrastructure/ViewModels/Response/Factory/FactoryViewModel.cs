﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels.Response.Factory
{
    public class FactoryViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Support { get; set; }
        public List<WorkplaceViewModel> Workplaces { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }

        // Add other properties as needed
    }

    public class WorkplaceViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int FactoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Description { get; set; }

        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        // Add other properties as needed
    }
    public class WorkSpaceViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public int WorkplaceId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        // Add other properties as needed
    }
}
