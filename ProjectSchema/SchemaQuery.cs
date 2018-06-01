using System;
using GraphQL.Types;
using Schema.Types;

namespace ProjectSchema
{
    public class SchemaQuery : ObjectGraphType<object>
    {
        public SchemaQuery(SchemaData data)
        {
            Name = "Query";

            Field<UserType>(
                "user",
                resolve: context => data.GetUserByIdAsync(context.GetArgument<int>("id"))
            );
        }
    }
}