# Customization Checklist

Use this checklist after copying files from AITransfer to ensure all templates are properly customized for your project.

## ✅ Required Customizations

### `.github/copilot-instructions.md`

- [ ] Replace `[PROJECT_NAME]` with your project name
- [ ] Replace `[ProjectFolder]` with your main project folder name
- [ ] Replace `[TestFolder]` with your test project folder name
- [ ] Replace `[SolutionName]` with your solution name (without .sln)
- [ ] Update .NET SDK `[version]` to match your `global.json`
- [ ] Update Target Framework `[version]` (e.g., `net8.0`, `net9.0`)
- [ ] Update C# Language `[version]` (e.g., `12.0`, `13.0`, `14.0`)
- [ ] Set Nullable Reference Types: `[Enabled/Disabled]`
- [ ] Set XML Documentation: `[Enabled/Disabled]`
- [ ] Update project description under Repository Overview
- [ ] Adjust Key Components list to match your actual folders
- [ ] Remove inapplicable sections (e.g., console-specific code for web apps)
- [ ] Update dependency list to match your actual NuGet packages
- [ ] Verify PowerShell commands match your solution/project names

### `.junie/guidelines.md`

- [ ] Update `[DATE]` with current date
- [ ] Replace `net[VERSION]` with actual target framework
- [ ] Replace C# `[VERSION]` with actual language version
- [ ] Replace `[Test framework name]` with actual test framework (xUnit, NUnit, MSTest)
- [ ] Replace `[Brief description]` with your project description
- [ ] Replace `[ProjectName]` with your main project name
- [ ] Replace `[TestProjectName]` with your test project name
- [ ] Replace `[SolutionName]` with your solution name
- [ ] Update test framework and assertion library references
- [ ] Verify PowerShell commands match your project structure

### `global.json`

- [ ] Update SDK version to your required .NET SDK version
- [ ] Remove the "comment" field (not part of standard global.json)
- [ ] Verify version matches what's documented in copilot-instructions.md

## 🔍 Review & Adjust

### `.editorconfig`

- [ ] Review style rules and adjust to match team preferences
- [ ] Verify severity levels (silent, suggestion, warning, error)
- [ ] Add project-specific rules if needed
- [ ] Remove rules that don't apply to your project type
- [ ] Test with your IDE to ensure rules are working correctly

### `.gitignore`

- [ ] Add project-specific ignore patterns
- [ ] Add framework-specific patterns (Blazor, MAUI, etc.)
- [ ] Remove unnecessary entries
- [ ] Verify build artifacts are properly ignored

### `.gitattributes`

- [ ] Generally works as-is for most projects
- [ ] Add custom merge strategies if your project needs them
- [ ] Review binary file patterns

### `.github/global-copilot-instructions.md`

- [ ] Optional: Customize mission/context sections if using this file
- [ ] Remove sections that don't apply to your project type
- [ ] Update example code to match your domain

### `.github/CSharpStudies.md`

- [ ] Optional: Only copy if this is a learning/training project
- [ ] Update lesson plans to match your learning objectives
- [ ] Remove if not applicable to your project

## 📝 Project-Specific Additions

### Consider Adding

- [ ] Project-specific code examples in copilot-instructions.md
- [ ] Architecture diagrams or links in documentation
- [ ] Team-specific coding standards
- [ ] CI/CD pipeline requirements
- [ ] Deployment instructions
- [ ] Environment-specific configuration notes

## ✔️ Verification Steps

### After Customization

- [ ] Build the solution: `dotnet build [SolutionName].sln`
- [ ] Run tests: `dotnet test [SolutionName].sln`
- [ ] Verify no warnings related to .editorconfig rules
- [ ] Test AI assistant responses with new instructions
- [ ] Commit all customized files to version control
- [ ] Share with team for review
- [ ] Update README.md to reference these AI configuration files

## 📌 Notes

- Keep placeholders like `[TypeName]` in sections meant to be examples/patterns
- Replace placeholders only where they refer to your specific project
- Review customizations when:
  - Upgrading .NET versions
  - Adding new projects to solution
  - Changing team coding standards
  - Adding new dependencies

## 🔄 Maintenance

Set a reminder to review and update these files:
- [ ] When .NET SDK version changes
- [ ] When project structure changes significantly
- [ ] When team coding standards change
- [ ] Quarterly or semi-annually

---

**Last Updated**: December 2, 2025