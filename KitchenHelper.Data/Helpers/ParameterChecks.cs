using System;
using ResourceParameters = KitchenHelper.API.Data.Entities.ResourceParameters;


namespace KitchenHelper.API.Data.Helpers
{
    public static class ParameterChecks
    {
        public static void CheckResourceParameters<T>(T resourceParameters)
        {
            if (resourceParameters == null)
            {
                throw new ArgumentNullException(nameof(resourceParameters));
            }
        }
    }
}
