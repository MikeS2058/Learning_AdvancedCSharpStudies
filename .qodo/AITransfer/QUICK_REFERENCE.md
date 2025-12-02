# AITransfer Quick Reference

## What Is This?

A collection of AI configuration templates and coding standards for C# / .NET projects that can be copied to new repositories.

## Quick Start (3 Steps)

### 1. Copy AITransfer folder to your new repository root

### 2. Run Setup Command (PowerShell)

```powershell
New-Item -ItemType Directory -Path ".github" -Force; New-Item -ItemType Directory -Path ".junie" -Force; Copy-Item -Path "AITransfer\copilot-instructions.md" -Destination ".github\copilot-instructions.md" -Force; Copy-Item -Path "AITransfer\global-copilot-instructions.md" -Destination ".github\global-copilot-instructions.md" -Force; Copy-Item -Path "AITransfer\junie-guidelines.md" -Destination ".junie\guidelines.md" -Force; Copy-Item -Path "AITransfer\.editorconfig" -Destination ".editorconfig" -Force; Copy-Item -Path "AITransfer\.gitignore" -Destination ".gitignore" -Force; Copy-Item -Path "AITransfer\.gitattributes" -Destination ".gitattributes" -Force; Copy-Item -Path "AITransfer\global.json" -Destination "global.json" -Force
```

### 3. Customize Files (REQUIRED!)

Open `CUSTOMIZATION_CHECKLIST.md` and work through each item.

**Critical placeholders to replace**:
- `[PROJECT_NAME]`
- `[ProjectFolder]`
- `[TestFolder]`
- `[SolutionName]`
- `[version]`
- All others marked with `[...]`

## Files Overview

| File | Destination | Purpose |
|------|-------------|---------|
| copilot-instructions.md | `.github/` | GitHub Copilot coding standards |
| global-copilot-instructions.md | `.github/` | General app dev guidelines |
| junie-guidelines.md | `.junie/` | Junie AI assistant config |
| .editorconfig | Root | Code formatting rules |
| .gitignore | Root | Git ignore patterns |
| .gitattributes | Root | Git line ending config |
| global.json | Root | .NET SDK version |

## Supported Project Types

✅ Console Applications  
✅ Class Libraries  
✅ Web Applications (ASP.NET Core, Blazor)  
✅ Desktop Apps (WPF, WinForms, MAUI)  
✅ Azure Functions  
✅ Worker Services  
✅ Test Projects  

## Documentation Files

- **README.md** — Overview and detailed usage instructions
- **SETUP_GUIDE.md** — Step-by-step PowerShell commands
- **CUSTOMIZATION_CHECKLIST.md** — Complete checklist for customizing templates
- **QUICK_REFERENCE.md** — This file!

## Common Mistakes to Avoid

❌ Forgetting to replace `[PROJECT_NAME]` placeholders  
❌ Leaving version numbers as `[version]`  
❌ Not updating global.json SDK version  
❌ Not adjusting .editorconfig for team preferences  
❌ Copying files without customizing them  
❌ Using Bash commands (`&&`) instead of PowerShell (`;`)  

## Verification Commands

After setup and customization:

```powershell
# Verify files copied
Get-ChildItem -Path ".github" -Force
Get-ChildItem -Path ".junie" -Force

# Test build
dotnet build YourSolution.sln

# Run tests
dotnet test YourSolution.sln
```

## Need Help?

1. Read **README.md** for comprehensive overview
2. Follow **SETUP_GUIDE.md** for detailed steps
3. Use **CUSTOMIZATION_CHECKLIST.md** to ensure nothing is missed
4. Review template files for inline comments and guidance

## Update Schedule

Review and update these files when:
- Upgrading .NET SDK versions
- Changing project structure
- Updating team coding standards
- Adding new projects to solution

---

**Version**: 1.0  
**Last Updated**: December 2, 2025