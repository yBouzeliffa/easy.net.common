@echo off
REM Se placer dans le répertoire du fichier batch
cd /d "%~dp0"

REM Exécuter le script PowerShell en contournant la politique d'exécution
powershell.exe -NoProfile -ExecutionPolicy Bypass -File "PushNuGetPackage.ps1"

pause
