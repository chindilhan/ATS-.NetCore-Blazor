namespace Stx.CompLibrary
{
    public class Init
	{
		public static void Initialize(string baseApi)
		{
			if (string.IsNullOrWhiteSpace(_api)) _api = baseApi;
		}

		private static string _api;
		internal static string Api { get { return _api; } }

	}
}
