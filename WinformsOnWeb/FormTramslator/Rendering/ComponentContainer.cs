using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Windows.Forms
{
    public sealed class ComponentContainer : IComponent, IHandleEvent
    {
        private Component _renderComponent;
        public ComponentContainer()
        {
            this._renderFragment = delegate (RenderTreeBuilder builder)
            {
                this.BuildRenderTree(builder);
            };
        }
        private void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (this._renderComponent == null)
            {
                return;
            }
            this._renderComponent.Render(builder);
        }
        void IComponent.Attach(RenderHandle renderHandle)
        {
            this._renderHandle = renderHandle;
        }
        public Task SetParametersAsync(ParameterView parameters)
        {
            this._renderComponent = parameters.GetValueOrDefault<Component>(Component.ComponentKey, null);
            this._renderComponent.Parent = parameters.GetValueOrDefault<Component>(Component.ParentKey, null);
            this._renderComponent.Attach(this._renderHandle);
            if (!this._renderComponent.RenderedOnce)
            {
                this._renderComponent.Redraw();
            }
            return Task.CompletedTask;
        }
        Task IHandleEvent.HandleEventAsync(EventCallbackWorkItem callback, object arg)
        {
            return callback.InvokeAsync(arg);
        }


        private readonly RenderFragment _renderFragment;
        private RenderHandle _renderHandle;
    }
}
