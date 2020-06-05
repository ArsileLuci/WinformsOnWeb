using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.AspNetCore.Components.Rendering;

namespace System.Windows.Forms
{
    public partial class Form : Component
    {
        public Form()
        {
            this.Controls = new ControlCollection(this);
        }

        public AutoScaleMode AutoScaleMode { get; set; }

        protected ControlCollection Controls { get; set; }
        public SizeF AutoScaleDimensions { get; set; }
        public Size ClientSize { get; set; }
        public void SuspendLayout() { }
        public void ResumeLayout(bool flag) { }
        public void PerformLayout()
        {
            this.Redraw();
        }
    }
}
