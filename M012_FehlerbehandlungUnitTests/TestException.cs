namespace M012_FehlerbehandlungUnitTests
{
	public class TestException : Exception
	{
		public TestException() { }

		public TestException(string message) : base(message) { }
	}
}
