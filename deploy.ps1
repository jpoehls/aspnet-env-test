Copy-Item -Path ./* -Destination c:\inetpub\wwwroot\EnvTestA -Force -Recurse -Exclude .git
Copy-Item -Path ./* -Destination c:\inetpub\wwwroot\EnvTestB -Force -Recurse -Exclude .git

"EnvTestA Value" | Out-File c:\inetpub\wwwroot\EnvTestA.envConfig.txt
"EnvTestB Value" | Out-File c:\inetpub\wwwroot\EnvTestB.envConfig.txt