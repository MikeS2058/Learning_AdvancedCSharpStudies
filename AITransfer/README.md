# AITransfer Directory

This directory contains AI-related configuration files and coding standards that can be copied to new C# / .NET repositories. These files help maintain consistent AI assistant behavior, code quality, and development practices across projects.

## Files Included

### GitHub Copilot Configuration
- **copilot-instructions.md** — Main GitHub Copilot instructions template for C# / .NET projects
  - Provides coding standards, build commands, and best practices
  - **Customization required**: Update project names, namespaces, and specific requirements
  
- **global-copilot-instructions.md** — Global Copilot instructions template for general app development
  - Framework-agnostic development guidelines
  - Mission canvas, architecture patterns, and operational standards
  
- **CSharpStudies.md** — C# learning and lesson planning template
  - Useful for educational or training projects
  - Can be adapted for documenting C# feature usage

### AI Assistant Configuration
- **junie-guidelines.md** — Generic guidelines template for Junie AI assistant
  - Covers project overview, testing, build instructions, and code style
  - **Customization required**: Update project names, frameworks, and specific conventions

### Code Style & Standards
- **.editorconfig** — Editor configuration for code formatting and style rules
  - Enforces consistent C# coding standards
  - Includes rules for `this.` qualifiers, file-scoped namespaces, one type per file
  - **Review and adjust** based on team preferences

- **.gitignore** — Git ignore patterns for .NET projects
  - Standard Visual Studio and .NET build artifacts
  - **Extend as needed** for project-specific files

- **.gitattributes** — Git attributes for line endings and file handling
  - Ensures consistent line endings across platforms

### Project Configuration
- **global.json** — .NET SDK version specification template
  - **Update required**: Set appropriate SDK version for your project

## How to Use

### 1. Copy Files to New Repository

Use the commands in `SETUP_GUIDE.md` or manually copy files:

```powershell
# From new repository root (after placing AITransfer folder)
New-Item -ItemType Directory -Path ".github" -Force
New-Item -ItemType Directory -Path ".junie" -Force

Copy-Item -Path "AITransfer\copilot-instructions.md" -Destination ".github\copilot-instructions.md" -Force
Copy-Item -Path "AITransfer\global-copilot-instructions.md" -Destination ".github\global-copilot-instructions.md" -Force
Copy-Item -Path "AITransfer\junie-guidelines.md" -Destination ".junie\guidelines.md" -Force
Copy-Item -Path "AITransfer\.editorconfig" -Destination ".editorconfig" -Force
Copy-Item -Path "AITransfer\.gitignore" -Destination ".gitignore" -Force
Copy-Item -Path "AITransfer\.gitattributes" -Destination ".gitattributes" -Force
Copy-Item -Path "AITransfer\global.json" -Destination "global.json" -Force
```

### 2. Customize for Your Project

**Critical**: These are templates. You must customize them for each project.

#### copilot-instructions.md
- Replace `[PROJECT_NAME]` with your actual project name
- Replace `[ProjectFolder]`, `[TestFolder]` with actual folder names
- Update `[SolutionName]`, `[version]` placeholders
- Adjust coding patterns to match your project type (console, web, library, etc.)
- Remove sections that don't apply (e.g., extension methods if not used)

#### junie-guidelines.md
- Update `[DATE]` with current date
- Replace `[ProjectName]`, `[TestProjectName]` with actual names
- Specify test framework and assertion libraries
- Add project-specific requirements

#### global.json
- Set actual .NET SDK version required for your project

#### .editorconfig
- Review and adjust style rules based on team preferences
- Add project-specific formatting rules

#### .gitignore
- Add project-specific ignore patterns
- Remove unnecessary entries

### 3. File Locations in Target Repository

| Source File | Destination | Required |
|------------|-------------|----------|
| copilot-instructions.md | `.github/copilot-instructions.md` | Recommended |
| global-copilot-instructions.md | `.github/global-copilot-instructions.md` | Optional |
| CSharpStudies.md | `.github/CSharpStudies.md` | Optional |
| junie-guidelines.md | `.junie/guidelines.md` | If using Junie |
| .editorconfig | `.editorconfig` | Recommended |
| .gitignore | `.gitignore` | Recommended |
| .gitattributes | `.gitattributes` | Recommended |
| global.json | `global.json` | Required for .NET |

## Project Type Compatibility

These templates work with various C# / .NET project types:

- ✅ Console Applications
- ✅ Class Libraries
- ✅ Web Applications (ASP.NET Core, Blazor, etc.)
- ✅ Desktop Applications (WPF, WinForms, MAUI)
- ✅ Test Projects
- ✅ Azure Functions / Serverless
- ✅ Worker Services

**Note**: Adjust content based on your specific project type. Not all sections apply to all project types.

## Important Notes

- **DO NOT MOVE** these files from the AITransfer directory in the source repository
- These are **COPIES/TEMPLATES** — the originals remain for future use
- **Customization is required** — placeholders must be replaced with actual values
- Commit customized files to version control in new repositories
- Share with team members to ensure consistent AI assistance
- Update as project requirements evolve

## Additional Resources

### Documentation Files in This Directory

- **DIRECTORY_MAP.md** — Visual directory structure with file categories and quick setup
- **QUICK_REFERENCE.md** — Quick start guide with essential commands and tips
- **SETUP_GUIDE.md** — Detailed PowerShell commands and step-by-step setup instructions
- **CUSTOMIZATION_CHECKLIST.md** — Complete checklist for customizing all template files
- **INDEX.md** — Navigation guide to help you find what you need
- **REVIEW_SUMMARY.md** — Summary of genericization changes and improvements

**Start here**: If you're new to this, read `QUICK_REFERENCE.md` first for a fast overview, or check `DIRECTORY_MAP.md` for a visual guide.

## Last Updated

December 2, 2025