namespace myBlogieMVC.Models.Domain
{
	public class BlogPost
	{
        public Guid Id { get; set; }
        public string Heading { get; set; }
		public string PageTitle { get; set; }
		public string Content { get; set; }

	}
}
