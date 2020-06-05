using System;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace System.Windows.Forms
{
	public class Button : ButtonBase
	{
		public event EventHandler Click = delegate { };


		protected override void BuildRenderTree(RenderTreeBuilder __builder)
		{
			__builder.OpenElement(0, "input");
			__builder.AddAttribute(1, "type", "button");
			__builder.AddAttribute(2, "value", this.Text);
			__builder.AddAttribute(3, "style", this.GetStyle());
			__builder.AddAttribute(5, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<MouseEventArgs>(this, 
				(me_args) => 
				{
					this.Click.Invoke(this, me_args);
				}
				));
			__builder.CloseElement();
		}
	}
}
