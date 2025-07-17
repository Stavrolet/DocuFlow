using DocuFlow.Dtos.DocumentTemplate;
using DocuFlow.Models;

namespace DocuFlow.Mappers
{
	public static class DocumentTemplateMapper
	{
		public static DocumentTemplate ToDocumentTemplate(this DocumentTemplateCreationDto documentTemplateCreationDto)
		{
			return new DocumentTemplate
			{
				Title = documentTemplateCreationDto.Title,
				FilePath = Path.Combine("DocumentTemplates", $"{documentTemplateCreationDto.Title}_{Guid.NewGuid()}.txt"),
				Content = documentTemplateCreationDto.Content
			};
		}

		public static DocumentTemplateDto ToDocumentTemplateCreationResponeDto(this DocumentTemplate documentTemplate)
		{
			return new DocumentTemplateDto
			{
				Id = documentTemplate.Id,
				Title = documentTemplate.Title,
				Content = documentTemplate.Content
			};
		}
	}
}
