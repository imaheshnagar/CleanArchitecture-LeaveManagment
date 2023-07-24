using LeaveManagement.Domain;
using LeaveManagement.Persistance.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Persistence.Integration
{
    public class LmDatabaseContextTests
    {
        private LmDatabaseContext _LmDatabaseContext;

        public LmDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<LmDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
          
            _LmDatabaseContext = new LmDatabaseContext(dbOptions);

        }

        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            //Arrange
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation"
            };

            //Act
           await _LmDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _LmDatabaseContext.SaveChangesAsync();
            //Assert
            leaveType.DateCreated.ShouldNotBeNull();

        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            //Arrange
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation"
            };

            //Act
           await _LmDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _LmDatabaseContext.SaveChangesAsync();
            //Assert
            leaveType.DateModified.ShouldNotBeNull();
        }


    }
}
