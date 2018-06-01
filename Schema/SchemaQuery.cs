using System;
using GraphQL.Types;
using Schema.Types;

namespace Schema
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