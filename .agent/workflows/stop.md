---
description: Terminate the IndustrialMonitor project immediately
---
// turbo
1. Find the PID of the IndustrialMonitor process and kill it.
```bash
pid=$(pgrep -f "dotnet run --project IndustrialMonitor.csproj")
if [ -n "$pid" ]; then
  kill -9 $pid
  echo "Process $pid (IndustrialMonitor) terminated."
else
  echo "IndustrialMonitor process not found."
fi
```
