using CRUDUsingReact.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CRUDUsingReact.Controllers.Base_Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReadOnlyBaseController<T,C> : ControllerBase
		where T : PublicBaseClass
		where C : DbContext
	{
		protected C context;

		public ReadOnlyBaseController(C context)
		{
			this.context = context;
		}

		[HttpGet]
		public virtual object Get()
		{
			return context.Set<T>();
		}

		[HttpGet("{key}")]
		public virtual ActionResult<T> Get([FromRoute] Guid key)
		{
			var result = context.Set<T>().FirstOrDefault(p => p.ID == key);
			if (result == null) return NotFound();
			return result;
		}

		protected bool EntityExists(Guid key)
		{
			return context.Set<T>().Any(x => x.ID == key);
		}
	}
}
