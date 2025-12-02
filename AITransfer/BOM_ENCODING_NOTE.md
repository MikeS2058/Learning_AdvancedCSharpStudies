# BOM Encoding Issue - Important Note

**Date**: December 2, 2025

## Issue Description

The `global.json` file in this AITransfer folder contains a BOM (Byte Order Mark) at the beginning of the file. When this file is copied to a repository, it can cause JSON parsing errors in the .NET CLI.

## Symptoms

- `dotnet` commands may fail with JSON parsing errors
- Error messages about "JSON standard does not allow such tokens"
- IDE may show JSON validation errors

## Resolution

After copying files from AITransfer to your repository, recreate `global.json` without BOM using:

```powershell
@"
{
  "sdk": {
    "version": "10.0.100",
    "rollForward": "latestPatch"
  }
}
"@ | Out-File -FilePath "global.json" -Encoding utf8NoBOM
```

Replace `10.0.100` with your actual SDK version.

## Prevention

To fix the AITransfer template itself:

1. Delete the existing `AITransfer/global.json`
2. Create a new file with UTF-8 no BOM encoding
3. Add the JSON content

### PowerShell Command to Fix Template

```powershell
cd AITransfer
Remove-Item -Path "global.json" -Force
@"
{
  "sdk": {
    "version": "10.0.100",
    "comment": "UPDATE THIS: Set to your project's required .NET SDK version. Common versions: 8.0.x, 9.0.x, 10.0.x"
  }
}
"@ | Out-File -FilePath "global.json" -Encoding utf8NoBOM
cd ..
```

## Note for Users

Always verify `global.json` encoding after copying from AITransfer. If you encounter JSON parsing errors with the .NET CLI, this BOM issue is the likely cause.

---

**Documented By**: GitHub Copilot  
**Related Issue**: Repository setup for Learning_AdvancedCSharpStudies