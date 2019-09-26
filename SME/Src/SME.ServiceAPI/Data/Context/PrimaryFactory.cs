using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Data.Context
{
    public static class PrimaryFactory
    {
        private static Dictionary<string, string> _dictModelsId = null;
        static PrimaryFactory()
        {
            _dictModelsId = new Dictionary<string, string> {
                {"APPROLE","Id"},
                {"APPUSER","Id"},
                {"CUSTOMER","Id"},
                {"PRODUCT","Id"},
                {"BRANCH","Id"}
            };
        }

        public static string GetKey(string modelName)
        {
            return _dictModelsId[modelName];
        }

    }
}
