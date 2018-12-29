using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Reflection;

namespace Atlas.GridData
{
    public class DeploymentAttribute : Attribute { }

    public class DeploymentOverrideAttribute : DeploymentAttribute { }

    public class DeploymentConstAttribute : DeploymentAttribute { }

    public class DeploymentOverrideShouldSerializeContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            bool bShouldSersialize = member.GetCustomAttributes().OfType<DeploymentAttribute>().Any();
            property.ShouldSerialize = instance =>
            {
                return bShouldSersialize;
            };

            return property;
        }
    }
}
