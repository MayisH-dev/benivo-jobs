﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Benivo.Jobs.Core.ProjectAggregate;
using Benivo.Jobs.UnitTests;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Benivo.Jobs.IntegrationTests.Data
{
    public class EfRepositoryUpdate : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task UpdatesItemAfterAddingIt()
        {
            // add a project
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var project = new Project(initialName);

            await repository.AddAsync(project);

            // detach the item so we get a different instance
            _dbContext.Entry(project).State = EntityState.Detached;

            // fetch the item and update its title
            var newProject = (await repository.ListAsync())
                .FirstOrDefault(project => project.Name == initialName);
            Assert.NotNull(newProject);
            Assert.NotSame(project, newProject);
            var newName = Guid.NewGuid().ToString();
            newProject.UpdateName(newName);

            // Update the item
            await repository.UpdateAsync(newProject);

            // Fetch the updated item
            var updatedItem = (await repository.ListAsync())
                .FirstOrDefault(project => project.Name == newName);

            Assert.NotNull(updatedItem);
            Assert.NotEqual(project.Name, updatedItem.Name);
            Assert.Equal(newProject.Id, updatedItem.Id);
        }
    }
}
