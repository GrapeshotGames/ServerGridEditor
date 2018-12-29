using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Reflection;

namespace AtlasGridDataLibrary
{
    public class DeploymentAttribute : Attribute
    {
    }
    
    public class DeploymentOverrideAttribute : DeploymentAttribute
    {
    }
    public class DeploymentConstAttribute : DeploymentAttribute
    {
    }


    public class DeploymentOverrideShouldSerializeContractResolver : DefaultContractResolver
    {
        //public new static readonly ShouldSerializeContractResolver Instance = new ShouldSerializeContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            bool bShouldSersialize = member.GetCustomAttributes().OfType<DeploymentAttribute>().Any();
            property.ShouldSerialize =
                instance =>
                {
                    return bShouldSersialize;
                };

            return property;
        }
    }
}
