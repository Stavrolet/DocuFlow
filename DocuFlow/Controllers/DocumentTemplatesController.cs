using DocuFlow.Dtos.DocumentTemplate;
using DocuFlow.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

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

		[HttpGet]
		public async Task<ActionResult<IEnumerable<DocumentTemplateDto>>> GetDocumentTemplates()
		{
			var documentTemplates = await context.DocumentTemplates.ToListAsync();

			if (documentTemplates == null || documentTemplates.Count == 0)
				return NotFound("No document templates found.");

			return Ok(documentTemplates.Select(dt => dt.ToDocumentTemplateDto()));
		}
			 
		[HttpGet("{id}")]
		public async Task<ActionResult<DocumentTemplateDto>> GetDocumentTemplateById([FromRoute] int id)
		{
			var documentTemplate = await context.DocumentTemplates.FindAsync(id);

			if (documentTemplate == null)
				return NotFound($"Document template with ID {id} not found.");

			return Ok(documentTemplate.ToDocumentTemplateDto());
		}
		
		[HttpPost]
		public async Task<ActionResult<DocumentTemplateDto>> CreateDocumentTemplate([FromBody] DocumentTemplateCreationDto documentTemplateDto)
		{
			if (documentTemplateDto == null)
				return BadRequest("Document template data is required.");

			var documentTemplate = documentTemplateDto.ToDocumentTemplate();
			await context.DocumentTemplates.AddAsync(documentTemplate);
			context.SaveChanges();

			return CreatedAtAction(nameof(GetDocumentTemplateById), new { id = documentTemplate.Id }, documentTemplate.ToDocumentTemplateDto());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteDocumentTemplate([FromRoute] int id)
		{
			var documentTemplate = await context.DocumentTemplates.FindAsync(id);
			if (documentTemplate == null)
				return NotFound($"Document template with ID {id} not found.");

			context.DocumentTemplates.Remove(documentTemplate);
			context.SaveChanges();

			return NoContent();
		}
	}
}
