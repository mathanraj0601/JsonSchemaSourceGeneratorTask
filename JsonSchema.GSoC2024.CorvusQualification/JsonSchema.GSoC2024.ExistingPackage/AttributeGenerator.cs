using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Immutable;
using System.Linq;


namespace JsonSchema.GSoC2024.ExistingPackage
{
    [Generator]
    internal class AttributeGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var provider = context.SyntaxProvider.CreateSyntaxProvider(
                predicate: (c, _) => c is AttributeSyntax,
                transform: (n, _) => (AttributeSyntax)n.Node)
                .Where(m => m is not null);

            var compilation = context.CompilationProvider.Combine(provider.Collect());

            context.RegisterSourceOutput(compilation, Execute);
        }

        private void Execute(SourceProductionContext context, (Compilation Left, ImmutableArray<AttributeSyntax> Right) tuple)
        {
            var (compilation, list) = tuple;

            foreach (var item in list)
            {
                if (item.Name.ToString() == "Generated")
                {
                    var code = """

                        //auto-generated

                        using System;
                        namespace JsonSchema.GSoC2024.ExistingPackage
                        {
                            [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
                            public class GeneratedAttribute : Attribute
                            {
                                public GeneratedAttribute(global::System.String filePath, global::System.String qualification)
                                {
                                    // Constructor logic, if any
                                    FilePath = filePath;
                                    Qualification = qualification;
                                }

                                public global::System.String FilePath { get; }
                                public global::System.String Qualification { get; }
                            }
                        }
             
                        """;
                    context.AddSource("GeneratedAttribute.g.cs", code);
                    return;
                }

            }

        }
    }
}

