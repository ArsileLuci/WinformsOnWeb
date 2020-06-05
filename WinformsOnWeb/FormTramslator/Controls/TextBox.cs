using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;

namespace System.Windows.Forms
{
    public class TextBox : System.Windows.Forms.Component
    {
        #region Events
        public event EventHandler TextChanged = delegate { };
        #endregion
        public override string Text 
        { 
            get => base.Text;
            set
            {
                base.Text = value;
                this.TextChanged.Invoke(this, EventArgs.Empty);
            }
        }
        public bool Multiline
        {
            get => this._multiline;
            set
            {
                if (this._multiline != value)
                {
                    this._multiline = value;
                    this.Redraw();
                }
            }
        }
        private bool _multiline;

        public void Clear()
        {
            this.Text = null;
        }



        protected override void BuildRenderTree(RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "input");
            __builder.AddAttribute(1, "style", this.GetStyle());
            __builder.AddAttribute(2, "value", BindConverter.FormatValue(base.Text, null));
            __builder.AddAttribute<ChangeEventArgs>(3, "oninput", EventCallback.Factory.CreateBinder(this, delegate (string __value)
            {
                base.Text = __value;
                this.TextChanged?.Invoke(this, EventArgs.Empty);
                if (this.Parent != null)
                {
                    this.Parent.Redraw();
                }
                else
                {
                    this.Redraw();
                }
            }, base.Text, null));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
        }
    }
}
