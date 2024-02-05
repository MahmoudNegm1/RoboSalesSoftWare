namespace RoboSalesSoftWare.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
	public class DatabaseConfig
	{
		public string Server { get; set; }
		public string Database { get; set; }
		public string UserId { get; set; }
		public string Password { get; set; }
		public bool TrustServerCertificate { get; set; }

		public string GetConnectionString()
		{
			return $"Server={Server};Database={Database};User Id={UserId};Password={Password}; TrustServerCertificate={TrustServerCertificate}";
		}
	}
}
