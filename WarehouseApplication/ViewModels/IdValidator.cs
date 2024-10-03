using System.Text.RegularExpressions;

namespace WarehouseApplication.ViewModels
{
    internal static class IdValidator
    {
        private static Regex _regex = new Regex(@"^([0-9]|[A-F])*$", RegexOptions.Compiled);



        public static bool IsValid(string id)
        {
            return _regex.IsMatch(id);
        }
    }
}
