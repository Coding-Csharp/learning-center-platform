using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST;

[ApiController]
[Route("/api/v1/categories/{categoryId}/tutorials")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Categories")]
public class CategoryTutorialsController(ITutorialQueryService tutorialQueryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTutorialsByCategoryId([FromRoute] int categoryId)
    {
        var getAllTutorialsByCategoryIdQuery = new GetAllTutorialsByCategoryIdQuery(categoryId);
        var tutorials = await tutorialQueryService.Handle(getAllTutorialsByCategoryIdQuery);
        var resources = tutorials.Select(TutorialResourceFromEntityAssembler.ToResourceFromEntity);

        return Ok(resources);
    }
}