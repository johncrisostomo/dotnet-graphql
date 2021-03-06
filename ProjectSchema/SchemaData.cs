using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using ProjectSchema.Types;

// This is a fake data source, will be replaced by service / repo / EF / whatever
namespace ProjectSchema
{
    public class SchemaData
    {
        private readonly List<ProjectUser> _users = new List<ProjectUser>();

        public SchemaData()
        {
            _users.Add(new ProjectUser
            {
                Id = 1,
                Name = "John",
                Email = "john@crisostomo.com"
            });
        }

        public Task<ProjectUser> GetUserByIdAsync(int id)
        {
            return Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
        }
    }
}