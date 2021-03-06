// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Analyzer.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.NetCore.Analyzers.Security.Helpers;

namespace Microsoft.NetCore.Analyzers.Security
{
    /// <summary>
    /// For detecting deserialization with <see cref="T:System.Data.DataTable"/>.
    /// </summary>
    [SuppressMessage("Documentation", "CA1200:Avoid using cref tags with a prefix", Justification = "The comment references a type that is not referenced by this compilation.")]
    [DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
    internal class DoNotUseDataTableReadXml : DoNotUseInsecureDeserializerMethodsBase
    {
        internal static readonly DiagnosticDescriptor RealMethodUsedDescriptor =
            SecurityHelpers.CreateDiagnosticDescriptor(
                "CA2350",
                nameof(MicrosoftNetCoreAnalyzersResources.DataTableReadXmlTitle),
                nameof(MicrosoftNetCoreAnalyzersResources.DataTableReadXmlMessage),
                RuleLevel.Disabled,
                isPortedFxCopRule: false,
                isDataflowRule: false);

        protected override string DeserializerTypeMetadataName =>
            WellKnownTypeNames.SystemDataDataTable;

        protected override ImmutableHashSet<string> DeserializationMethodNames =>
            SecurityHelpers.DataTableDeserializationMethods;

        protected override DiagnosticDescriptor MethodUsedDescriptor => RealMethodUsedDescriptor;
    }
}
