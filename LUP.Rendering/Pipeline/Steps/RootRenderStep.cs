using LUP.Rendering.Pipeline.Steps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Pipeline
{
    public abstract class RootRenderStep : RenderStep
    {
        private readonly List<SubRenderStep> steps;

        public IEnumerable<SubRenderStep> Steps { get; }

        public RootRenderStep()
        {
            steps = new();
            Steps = new ReadOnlyCollection<SubRenderStep>(steps);
        }
    }
}
