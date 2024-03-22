using CRUDUsingReact.Context;
using CRUDUsingReact.Controllers.Base_Controllers;
using CRUDUsingReact.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDUsingReact.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ReadWriteBaseController<Employee,ApplicationDbContext>
	{
		public EmployeeController(ApplicationDbContext context):base(context) { }
		
	}
}
