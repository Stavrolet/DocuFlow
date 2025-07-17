namespace DocuFlow.Models
{
    public class DocumentTemplate
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
		public string FilePath { get; set; } = string.Empty;

		public string Content
        {
            get
            {
                if (string.IsNullOrEmpty(FilePath))
                    return string.Empty;
                else if (!File.Exists(Path.Combine(ApplicationConstants.DATABASE_STORAGE_FILES, FilePath)))
                    return string.Empty;

				return File.ReadAllText(Path.Combine(ApplicationConstants.DATABASE_STORAGE_FILES, FilePath));
            }
            set
            {
                if (!Directory.Exists(ApplicationConstants.DATABASE_STORAGE_FILES))
                    Directory.CreateDirectory(ApplicationConstants.DATABASE_STORAGE_FILES);

                if (string.IsNullOrEmpty(FilePath))
                    throw new InvalidOperationException("FilePath must be set before setting content.");

				var directoryPath = Path.GetDirectoryName(Path.Combine(ApplicationConstants.DATABASE_STORAGE_FILES, FilePath));
				if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath ?? string.Empty);

				File.WriteAllText(Path.Combine(ApplicationConstants.DATABASE_STORAGE_FILES, FilePath), value);
            }
        }
    }
}
