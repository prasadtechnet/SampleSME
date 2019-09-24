using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SME.ServiceAPI.Common.Entities;
using SME.ServiceAPI.Common.Idenitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Data.Context
{
    public partial class ApplicationDbContext
    {
        private void BranchMap(EntityTypeBuilder<Branch> builder)
        {

        }
        private void CustomerMap(EntityTypeBuilder<Customer> builder)
        {

        }
        private void CustomerProductMap(EntityTypeBuilder<CustomerProduct> builder)
        {

        }
        private void ProductMap(EntityTypeBuilder<Product> builder)
        {

        }
        private void ServiceCallMap(EntityTypeBuilder<ServiceCall> builder)
        {

        }
        private void ServiceCallProductMap(EntityTypeBuilder<ServiceCallProduct> builder)
        {

        }
        private void ServiceCallFeedbackMap(EntityTypeBuilder<ServiceCallFeedback> builder)
        {

        }
        private void ServiceCallHistoryMap(EntityTypeBuilder<ServiceCallHistory> builder)
        {

        }
        private void ClaimMasterMap(EntityTypeBuilder<ClaimMaster> builder)
        {

        }

    }
}
