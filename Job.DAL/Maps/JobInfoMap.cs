using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Job.Model.Entities;

namespace Job.DAL.Maps
{
    public class JobInfoMap : EntityTypeConfiguration<JobInfo>
    {
        public JobInfoMap()
        {
            this.HasKey(x => x.Id);
        }
    }
}
