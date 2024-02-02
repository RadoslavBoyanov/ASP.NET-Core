namespace NewsApp.Common.Validations
{
	public static class EntityValidations
	{
		public static class Journalist
		{
			public const int NameMaxLength = 50;
			public const int EmailMaxLength = 70;
		}

		public static class NewsArticle
		{
			public const int TitleMaxLength = 250;
			public const int ContentMaxLength = 2000;
		}

		public static class NewsCategory
		{
			public const int NameMaxLength = 40;
			public const int ContentMaxLength = 60;
		}
	}
}
