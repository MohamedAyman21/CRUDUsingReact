using CRUDUsingReact.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDUsingReact.Controllers.Base_Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReadWriteBaseController<T,C> : ReadOnlyBaseController<T,C>
		where T : PublicBaseClass
		where C : DbContext
	{
		public ReadWriteBaseController(C context) : base(context)
		{
		}

		[HttpPost]
		public virtual async Task<IActionResult> Post([FromBody] T entity)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await context.Set<T>().AddAsync(entity);
			try
			{
				await context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
			return Accepted(entity);
		}

		[HttpPut]
		public virtual async Task<IActionResult> Put(T update)
		{
			if (!EntityExists(update.ID))
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{

				context.Set<T>().Update(update);
				await context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!EntityExists(update.ID))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return Ok(update);
		}

		[HttpDelete("{key}")]
		public virtual async Task<IActionResult> Delete([FromRoute]Guid key)
		{
			var entity = await context.Set<T>().FindAsync(key);

			if (entity == null)
				return NotFound();

			context.Set<T>().Remove(entity);
			await context.SaveChangesAsync();
			return Ok();
		}
	}
}
