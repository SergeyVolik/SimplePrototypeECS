using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerV112.UtilityAIEditor
{
    public class HLSLCosineCurveFunction : HLSLFunction
    {

        private const string k_Name = "CosineCurve";
        HLSL_PI m_PI;
        public string Execute(string x, string steepness, string offset)
        {
            Declare();
            return $"{Name}({x}, {steepness}, {offset})";
        }

        public HLSLCosineCurveFunction(StringBuilder decl, HLSL_PI pi, GPUPrecision pres) : base(decl, pres)
        {
            Name = k_Name;
            m_PI = pi;

        }

        protected override string InternalDeclare()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{m_GPUPrecision} CosineCurve({m_GPUPrecision} x, {m_GPUPrecision} steepness, {m_GPUPrecision} offset)");
            builder.AppendLine("{");
            builder.AppendLine($"    return clamp(1 - cos(x * {m_PI.Get()} * steepness) + offset, 0, 1);");
            builder.AppendLine("}");
            return builder.ToString();
        }
    }
}
