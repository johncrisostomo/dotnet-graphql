using GraphQL;
using GraphQL.Types;

namespace ProjectSchema
{
    public class GQLSchema : Schema
    {
        public GQLSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<RootQuery>();
        }
    }
}