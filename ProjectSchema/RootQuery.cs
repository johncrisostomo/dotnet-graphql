using System;
using GraphQL.Types;
using ProjectSchema.Types;

namespace ProjectSchema
{
    public class RootQuery : ObjectGraphType<object>
    {
        public RootQuery(SchemaData data)
        {
            Name = "Query";

            Field<UserType>(
                "user",

                resolve: context => data.GetUserByIdAsync(context.GetArgument<int>("id"))
            );
        }
    }
}