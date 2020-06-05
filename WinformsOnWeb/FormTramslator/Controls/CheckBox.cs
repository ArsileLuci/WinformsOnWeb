using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Forms
{
    public class CheckBox : ButtonBase
    {
		private bool _checked;
        public bool Checked 
		{ 
			get => _checked; 
			set
			{
				if (_checked != value) 
				{
					_checked = value;
					this.Redraw();
				}
			}	
		}
        #region Events
        public event EventHandler CheckedChanged = delegate { };
        #endregion
		protected override void BuildRenderTree(RenderTreeBuilder __builder)
		{
			__builder.OpenElement(0, "div");
			__builder.AddAttribute(1, "style", this.GetStyle());
			__builder.AddMarkupContent(2, "\r\n    ");
			__builder.OpenElement(3, "input");
			__builder.AddAttribute(4, "type", "checkbox");
			__builder.AddAttribute(5, "style", string.Concat(new string[]
			{
				"height: ",
				base.Size.Height.ToString(),
				"px; width: ",
				base.Size.Height.ToString(),
				"px"
			}));
			__builder.AddAttribute(6, "value", BindConverter.FormatValue(this.Checked, null));
			__builder.AddAttribute<ChangeEventArgs>(7, "oninput", EventCallback.Factory.CreateBinder(this, delegate (bool __value)
			{
				this.Checked = __value;
				this.CheckedChanged?.Invoke(this, EventArgs.Empty);

			}, this.Checked, null));
			__builder.SetUpdatesAttributeName("value");
			__builder.CloseElement();
			__builder.AddMarkupContent(8, "\r\n    ");
			__builder.OpenElement(9, "label");
			__builder.AddAttribute(10, "style", "position:inherit");
			__builder.AddMarkupContent(11, "\r\n        ");
			__builder.AddContent(12, base.Text);
			__builder.AddMarkupContent(13, "\r\n    ");
			__builder.CloseElement();
			__builder.AddMarkupContent(14, "\r\n");
			__builder.CloseElement();
		}
	}
}
