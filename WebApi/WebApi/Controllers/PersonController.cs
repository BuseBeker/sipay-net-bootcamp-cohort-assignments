using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using WebApi.ValidationRules;
using WebApi.Model;

namespace WebApi.Controllers;

[ApiController]
[Route("webApi/api/[controller]")]
public class PersonController : ControllerBase
{

    public PersonController() { }


    [HttpPost]
    public ActionResult<Person> Post([FromBody] Person person)
    {
        PersonValidator validator = new PersonValidator();
        var validationResult = validator.Validate(person);

        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors.Select(ErrorEventArgs => ErrorEventArgs.ErrorMessage).ToList();
            return BadRequest(validationErrors);
        }

        return Ok(person);
    }
        
    
}
