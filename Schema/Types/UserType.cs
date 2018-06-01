using GraphQL.Types;

namespace Schema.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(SchemaData data)
        {
            Name = "User";
            Description = "A user?";

            Field(u => u.Id).Description("Id of the user");
            Field(u => u.Name, nullable: false).Description("Name of the user");
            Field(u => u.Email, nullable: false).Description("Contact details of the user");
        }
    }
}