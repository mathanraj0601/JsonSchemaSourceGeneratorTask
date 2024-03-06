using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Immutable;
using System.Linq;


namespace JsonSchema.GSoC2024.ExistingLibrary
{
    [Generator]
    internal class AttributeGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var provider = context.SyntaxProvider.CreateSyntaxProvider(
                predicate: (c, _) => c is ArgumentListSyntax,
                transform: (n, _) => (ArgumentListSyntax)n.Node)
                .Where(m => m is not null);

            var compilation = context.CompilationProvider.Combine(provider.Collect());

            context.RegisterSourceOutput(compilation, (spc, source) => Execute(spc, source.Left));
        }
        private void Execute(SourceProductionContext context, Compilation compilation)
        {

            const string ATTRIBUTENAME = "GeneratedAttribute";
            bool isAttributeDeclared = false;
            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                var root = syntaxTree.GetRoot();
                var attributeNodes = root.DescendantNodes().OfType<AttributeSyntax>();

                foreach (var attributeNode in attributeNodes)
                {
                    // Get the type name of the attribute
                    var attributeName = attributeNode.Name.ToString();

                    if (attributeName == ATTRIBUTENAME)
                    {
                        isAttributeDeclared = true;
                        break;
                    }
                }
              
            }

            if (isAttributeDeclared)
            {
                var code = """

                        //auto-generated

                        using System;
                        namespace JsonSchema.GSoC2024.ExistingLibrary
                        {
                            [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
                            public class GeneratedAttributeAttribute : Attribute
                            {
                                public GeneratedAttributeAttribute(global::System.String filePath, global::System.String qualification)
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
                context.AddSource("GenerateAttribute.g.cs", code);
            }

        }
    }
}
