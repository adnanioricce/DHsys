using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Settings
{
	public interface IWritableOptions<out T> : IOptionsSnapshot<T> where T : class, new()
	{
		void Update(Action<T> applyChanges);
	}
}
