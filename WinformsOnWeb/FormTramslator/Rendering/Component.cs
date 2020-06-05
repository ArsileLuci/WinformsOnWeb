using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Forms
{

    public abstract class Component : IComponent, IHandleEvent, IDisposable
    {
        public const string ComponentKey = "|Component|";
        public const string ParentKey = "|Parent|";

        public virtual Color BackColor
        {
            get => this._backColor;
            set 
            {
                if (this._backColor != value)
                {
                    this._backColor = value;
                    this.Redraw();
                }
            }
        }
        private Color _backColor;

        public System.Drawing.Font Font
        {
            get => this._font;
            set
            {
                if (this._font != value)
                {
                    this._font = value;
                    this.Redraw();
                }
            }
        }
        private Font _font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        public HorizontalAlignment TextAlign
        {
            get => this._textAlign;
            set
            {
                if(this._textAlign!=value)
                {
                    this._textAlign = value;
                    this.Redraw();
                }
            }
        }
        private HorizontalAlignment _textAlign;
        public virtual Point Location
        {
            get => this._location;
            set
            {
                if (this._location != value)
                {
                    this._location = value;
                    this.Redraw();
                }
            }
        }
        private Point _location;
        public virtual string Name
        {
            get => _name;
            set
            {
                if (this._name != value)
                {
                    this._name = value;
                    this.Redraw();
                }
            }
        }
        private string _name;
        public virtual string Text
        {
            get => this._text;
            set
            {
                if (this._text != value)
                {
                    this._text = value;
                    this.Redraw();
                }
            }
        }
        private string _text;
        public virtual Size Size
        {
            get => this._size;
            set
            {
                if (this._size != value)
                {
                    this._size = value;
                    this.Redraw();
                }
            }
        }
        private Size _size;
        public virtual int TabIndex
        {
            get => this._tabIndex;
            set
            {
                if (this._tabIndex != value)
                {
                    this._tabIndex = value;
                    this.Redraw();
                }
            }
        }
        private int _tabIndex;
        public virtual bool Visible
        {
            get => this._visible;
            set
            {
                if(this._visible != value)
                {
                    this._visible = value;
                    this.Redraw();
                }
            }
        }
        private bool _visible = true;
        public virtual bool AutoSize
        {
            get => this._autoSize;
            set
            {
                if (this._autoSize != value)
                {
                    this._autoSize = value;
                    this.Redraw();
                }
            }
        }
        private bool _autoSize;
        public Component Parent { get; set; }
        public Component()
        {
            this._renderFragment = delegate (RenderTreeBuilder builder)
            {
                this.BuildRenderTree(builder);
            };
        }
        internal void Render(RenderTreeBuilder builder)
        {
            this._renderFragment(builder);
        }


        protected abstract void BuildRenderTree(RenderTreeBuilder builder);

        public void Attach(RenderHandle renderHandle)
        {
            this._renderHandle = renderHandle;
            if (this._hasPostponedRender)
            {
                this.Redraw();
            }
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);
            return Task.CompletedTask;
        }

        public virtual Task HandleEventAsync(EventCallbackWorkItem item, object arg)
        {
            return item.InvokeAsync(arg);
        }

        public void Redraw()
        {
            if (this._renderHandle.IsInitialized)
            {
                this._hasPostponedRender = false;
                this._renderHandle.Render(this._renderFragment);
                this.RenderedOnce = true;
            }
            else
            {
                this._hasPostponedRender = true;
            }
        }
        private bool _hasPostponedRender;
        internal bool RenderedOnce = false;
        private readonly RenderFragment _renderFragment;
        private RenderHandle _renderHandle;

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Component()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        protected virtual string GetStyle()
        {
            var sb = new StringBuilder();
            sb.Append("position:absolute;");
            sb.Append($"top:{this.Location.Y}px;");
            sb.Append($"left:{this.Location.X}px;");
            sb.Append($"width:{this.Size.Width}px;");
            sb.Append($"height:{this.Size.Height}px;");
            string visibility = this.Visible ? "visible" : "hidden";
            sb.Append($"visibility:{visibility};");
            sb.Append($"font-family:{this.Font.FontFamily.Name};");

            sb.Append($"font-size:{this.Font.Size}{GetShortMeasuring(this.Font.Unit)}");
            return sb.ToString();
        }
        private static string GetShortMeasuring(System.Drawing.GraphicsUnit gu)
        {
            switch (gu)
            {
                case GraphicsUnit.Point:
                    return "pt";
                case GraphicsUnit.Pixel:
                    return "px";
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
