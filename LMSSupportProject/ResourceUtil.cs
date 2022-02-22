using System.Reflection;
using System.Resources;

namespace LMSSupportProject
{
    public static class ResourceUtil
    {
        public static string GetResourceValue(string key)
        {
            return new ResourceManager("LMSSupportProject.DBResource", assembly: Assembly.GetExecutingAssembly()).GetString(key) ?? null;
        }
    }
}
