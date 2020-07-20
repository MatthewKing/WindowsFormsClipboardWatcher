$root = Resolve-Path (Join-Path $PSScriptRoot "..")
$project = "$root/src/WindowsFormsClipboardWatcher"
$output = "$root/artifacts"
dotnet pack "$project" --configuration Release --output "$output"
