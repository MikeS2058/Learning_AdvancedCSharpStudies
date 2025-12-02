# Quick Setup Guide for New Repositories

This guide provides PowerShell commands to copy AI configuration files from the AITransfer directory to a new C# / .NET repository.

**Prerequisites**:
- Place the `AITransfer` folder in the root of your new repository
- Open PowerShell in the repository root directory
- Review files before copying to understand what will be added

**Important**: These are template files with placeholders. After copying, you **must** customize them for your specific project.

**Project Type Compatibility**: These templates work with various C# / .NET projects:
- Console Applications
- Class Libraries  
- Web Applications (ASP.NET Core, Blazor, MVC)
- Desktop Applications (WPF, WinForms, MAUI)
- Azure Functions / Serverless
- Worker Services
- Test Projects

Adjust the content based on your specific project type. Not all sections apply to all project types.

---

## PowerShell Commands to Copy Files

Run these commands from the root of your new repository after placing the AITransfer folder in it:

```powershell
# Create necessary directories
New-Item -ItemType Directory -Path ".github" -Force
New-Item -ItemType Directory -Path ".junie" -Force

# Copy GitHub Copilot files
Copy-Item -Path "AITransfer\copilot-instructions.md" -Destination ".github\copilot-instructions.md" -Force
Copy-Item -Path "AITransfer\global-copilot-instructions.md" -Destination ".github\global-copilot-instructions.md" -Force

# Optional: Copy CSharpStudies.md if relevant to your project (learning/training projects)
# Copy-Item -Path "AITransfer\CSharpStudies.md" -Destination ".github\CSharpStudies.md" -Force

# Copy Junie AI files
Copy-Item -Path "AITransfer\junie-guidelines.md" -Destination ".junie\guidelines.md" -Force

# Copy root configuration files
Copy-Item -Path "AITransfer\.editorconfig" -Destination ".editorconfig" -Force
Copy-Item -Path "AITransfer\.gitignore" -Destination ".gitignore" -Force
Copy-Item -Path "AITransfer\.gitattributes" -Destination ".gitattributes" -Force
Copy-Item -Path "AITransfer\global.json" -Destination "global.json" -Force
```

## All-in-One Command

```powershell
# Create directories and copy all files
New-Item -ItemType Directory -Path ".github" -Force; New-Item -ItemType Directory -Path ".junie" -Force; Copy-Item -Path "AITransfer\copilot-instructions.md" -Destination ".github\copilot-instructions.md" -Force; Copy-Item -Path "AITransfer\global-copilot-instructions.md" -Destination ".github\global-copilot-instructions.md" -Force; Copy-Item -Path "AITransfer\CSharpStudies.md" -Destination ".github\CSharpStudies.md" -Force; Copy-Item -Path "AITransfer\junie-guidelines.md" -Destination ".junie\guidelines.md" -Force; Copy-Item -Path "AITransfer\.editorconfig" -Destination ".editorconfig" -Force; Copy-Item -Path "AITransfer\.gitignore" -Destination ".gitignore" -Force; Copy-Item -Path "AITransfer\.gitattributes" -Destination ".gitattributes" -Force; Copy-Item -Path "AITransfer\global.json" -Destination "global.json" -Force
```

## Verification

After copying, verify the files exist:

```powershell
# Check .github files
Get-ChildItem -Path ".github" -Force

# Check .junie files
Get-ChildItem -Path ".junie" -Force

# Check root files
Get-ChildItem -Path "." -Force | Where-Object { $_.Name -match "^\.(editorconfig|gitignore|gitattributes)$|^global\.json$" }
```

## Post-Setup Customization

**Critical**: After copying the files, you **must** customize them for your project. These are templates with placeholders.

### 1. Edit `.github/copilot-instructions.md`

Replace all placeholders:
- `[PROJECT_NAME]` → Your project name
- `[ProjectFolder]` → Your main project folder name
- `[TestFolder]` → Your test project folder name
- `[SolutionName]` → Your solution file name (without .sln extension)
- `[version]` → Actual .NET SDK version, framework version, C# version
- `[Enabled/Disabled]` → Actual settings

Adjust content based on project type:
- Remove sections that don't apply (e.g., "Build & Run" for class libraries)
- Add project-specific patterns and conventions
- Update dependency lists
- Modify forbidden patterns based on your standards

### 2. Edit `.junie/guidelines.md`

Replace placeholders:
- `[DATE]` → Current date
- `[VERSION]` → Actual .NET and C# versions
- `[ProjectName]` → Your main project name
- `[TestProjectName]` → Your test project name
- `[SolutionName]` → Your solution name
- `[Test framework name]` → Actual test framework (xUnit, NUnit, MSTest)
- `[Brief description]` → What your project does

Adjust testing and build commands to match your project structure.

### 3. Update `global.json`

Set the actual .NET SDK version:
```json
{
  "sdk": {
    "version": "9.0.100"  // Replace with your version
  }
}
```

### 4. Review `.editorconfig`

- Verify code style rules match team preferences
- Add project-specific formatting rules
- Adjust severity levels (silent, suggestion, warning, error)
- Remove rules that don't apply to your project

### 5. Check `.gitignore`

- Add project-specific ignore patterns
- Remove unnecessary entries
- Consider framework-specific patterns (e.g., Blazor, MAUI)

### 6. Review `.gitattributes`

- Generally works as-is for most .NET projects
- Add custom merge strategies if needed

### 7. Verify Project Structure

Ensure your actual project structure matches the patterns described in the customized files.

## Important Reminders

- ✅ These are configuration files - customize them for each project
- ✅ Commit these files to version control
- ✅ Share with team members to ensure consistent AI assistance
- ✅ Update as project requirements evolve