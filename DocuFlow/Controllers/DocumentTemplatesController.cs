using DocuFlow.Dtos.DocumentTemplate;
using DocuFlow.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace DocuFlow.Controllers
{
	[ApiController]
	[Route("api/v1/document-templates")]
	public class DocumentTemplatesController : ControllerBase
	{
		private readonly ApplicationDbContext context;

		public DocumentTemplatesController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet("{id}")]
		public ActionResult<DocumentTemplateDto> GetDocumentTemplateById([FromRoute] int id)
		{
			var documentTemplate = context.DocumentTemplates.Find(id);

			if (documentTemplate == null)
				return NotFound($"Document template with ID {id} not found.");

			return Ok(documentTemplate.ToDocumentTemplateCreationResponeDto());
		}
		
		[HttpPost]
		public ActionResult<DocumentTemplateDto> CreateDocumentTemplate([FromBody] DocumentTemplateCreationDto documentTemplateDto)
		{
			if (documentTemplateDto == null)
				return BadRequest("Document template data is required.");

			var documentTemplate = documentTemplateDto.ToDocumentTemplate();
			context.DocumentTemplates.Add(documentTemplate);
			context.SaveChanges();
			return CreatedAtAction(nameof(GetDocumentTemplateById), new { id = documentTemplate.Id }, documentTemplate.ToDocumentTemplateCreationResponeDto());
		}
	}
}
