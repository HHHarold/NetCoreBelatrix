using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Belatrix.WebApi
{
    public static class BelatrixApiConventions
    {
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public static void Get([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)][ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object id)
        { }

        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public static void Get()
        { }

        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public static void Post([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)][ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object id)
        { }

        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public static void Put([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)][ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object id)
        { }

        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public static void Delete([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)][ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object id)
        { }

    }
}
