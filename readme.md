## What is this?

This is an experiment to test how IIS handles environment variables in ASP.NET processes.

The IIS setup for this test is as follows:

1. 2 IIS sites (A & B)
2. Each in their own AppPool
3. Each AppPool is "Integrated" and on .NET 4.0
4. Each site is in its own directory under `c:\inetpub\wwwroot` (i.e. `.\EnvTestA` and `.\EnvTestB`)
5. There are environment _config_ files along side the IIS site folder. (i.e. `c:\inetpub\wwwroot\EnvTestA.envConfig.txt` for the `.\EnvTestA` site.)

## To reproduce

Follow the steps above.

There is a `./deploy.ps1` script you can run to copy the website to the IIS folders (after you've compiled).

## Results

So far this experiment has shown that the process environment variables are isolated between the **AppPools**.

If both sites share an AppPool then the environment variables are shared between them.

Bottom line? Keep your apps in separate pools and you can use environment variables for configuration.